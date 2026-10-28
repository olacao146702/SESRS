using System.Data;
using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>
/// The student's enrollment page: pick subjects and sections, see live validation, submit,
/// then track the request (pending / approved / returned / rejected).
/// </summary>
public partial class StudentEnrollmentForm : Form
{
    private sealed record SectionChoice(int SectionId, string Text);

    private const int ColSelect = 0;
    private const int ColSection = 6;

    private readonly int _studentId;
    private readonly EnrollmentService _service = new();

    private EnrollmentContext? _context;
    private AcademicPeriod? _period;
    private bool _loading;

    public StudentEnrollmentForm(int studentId)
    {
        InitializeComponent();
        _studentId = studentId;

        dgvOfferings.CurrentCellDirtyStateChanged += (_, _) =>
        {
            if (dgvOfferings.IsCurrentCellDirty)
            {
                dgvOfferings.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        };

        dgvOfferings.CellValueChanged += (_, _) =>
        {
            if (!_loading)
            {
                UpdateUnits();
            }
        };

        dgvOfferings.DataError += (_, e) => e.ThrowException = false;
    }

    private void StudentEnrollmentForm_Load(object? sender, EventArgs e) => LoadPage();

    private void btnCheck_Click(object? sender, EventArgs e) => RunSafe(CheckSelection);
    private void btnSubmit_Click(object? sender, EventArgs e) => RunSafe(SubmitEnrollment);
    private void btnWaitlist_Click(object? sender, EventArgs e) => RunSafe(JoinWaitlist);
    private void btnCancelRequest_Click(object? sender, EventArgs e) => RunSafe(CancelRequest);

    private void RunSafe(Action action)
    {
        try
        {
            UseWaitCursor = true;
            action();
        }
        catch (EnrollmentBlockedException ex)
        {
            ShowIssues(ex.Result);
            MessageBox.Show("Your enrollment cannot be submitted yet. Please review the notes below the table.",
                "Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorHandler.Friendly(ex), "Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            UseWaitCursor = false;
        }
    }

    // ------------------------------------------------------------ loading

    private void LoadPage()
    {
        RunSafe(() =>
        {
            _context = _service.GetContext(_studentId);
            _period = _context.Period;

            lblBanner.ForeColor = _context.IsOpen ? UiStyle.Brand : Color.Firebrick;
            lblBanner.Text = _context.StatusMessage;

            ShowWaitlist();

            if (_period == null)
            {
                pnlBuilder.Visible = false;
                pnlSummary.Visible = false;
                return;
            }

            string? status = _context.EnrollmentStatus;

            if (status is "Pending" or "Approved")
            {
                ShowSummary(status);
                return;
            }

            if (status == "Returned")
            {
                lblBanner.Text += $"\nReturned for correction: {_context.ReviewRemarks}";
                lblBanner.ForeColor = Color.SteelBlue;
            }
            else if (status == "Rejected")
            {
                lblBanner.Text += $"\nYour previous request was rejected. Remarks: {_context.ReviewRemarks}. You may submit a new request.";
                lblBanner.ForeColor = Color.Firebrick;
            }

            ShowBuilder();
        });
    }

    private void ShowWaitlist()
    {
        DataTable waiting = _service.GetMyWaitlist(_studentId);

        lblWaitlist.Text = waiting.Rows.Count == 0
            ? ""
            : "On waitlist: " + string.Join(", ", waiting.Rows.Cast<DataRow>().Select(r =>
                $"{r["subject_code"]} ({r["section_code"]}{(Convert.ToString(r["status"]) == "Notified" ? " - slot open!" : "")})"));
    }

    private void ShowSummary(string status)
    {
        pnlBuilder.Visible = false;
        pnlSummary.Visible = true;

        DataTable lines = _service.GetEnrollmentLines(_context!.EnrollmentId!.Value);

        dgvSummary.DataSource = lines;

        foreach (DataGridViewColumn column in dgvSummary.Columns)
        {
            column.HeaderText = CsvExport.Humanize(column.Name);
            column.Visible = column.Name != "enrollment_detail_id";
        }

        int units = lines.Rows.Cast<DataRow>().Sum(r => Convert.ToInt32(r["units"]));

        lblSummaryInfo.ForeColor = status == "Approved" ? UiStyle.Brand : Color.DarkOrange;
        lblSummaryInfo.Text = status == "Approved"
            ? $"Approved - {lines.Rows.Count} subjects, {units} units. To change subjects, contact the registrar's office."
            : $"Pending review - {lines.Rows.Count} subjects, {units} units. You will be notified when the registrar decides.";

        btnCancelRequest.Visible = status == "Pending";
    }

    private void ShowBuilder()
    {
        pnlSummary.Visible = false;
        pnlBuilder.Visible = true;

        List<SubjectOffering> offerings = _service.GetOfferings(_studentId);

        var preselected = _context!.EnrollmentStatus == "Returned"
            ? _service.GetSelections(_context.EnrollmentId!.Value).ToDictionary(s => s.SubjectId, s => s.SectionId)
            : new Dictionary<int, int>();

        _loading = true;
        dgvOfferings.Rows.Clear();

        foreach (SubjectOffering offering in offerings)
        {
            int index = dgvOfferings.Rows.Add();
            DataGridViewRow row = dgvOfferings.Rows[index];
            row.Tag = offering;

            row.Cells[colCode.Index].Value = offering.SubjectCode;
            row.Cells[colSubject.Index].Value = offering.SubjectName;
            row.Cells[colUnits.Index].Value = offering.Units;
            row.Cells[colPrerequisites.Index].Value = offering.Prerequisites.Length == 0 ? "None" : offering.Prerequisites;

            var choices = offering.Sections
                .Select(s => new SectionChoice(s.SectionId,
                    $"{s.SectionCode}  |  {s.ScheduleText}  |  " +
                    (s.Available == 0 ? "FULL" : $"{s.Available} of {s.Capacity} slots")))
                .ToList();

            var cell = new DataGridViewComboBoxCell
            {
                DataSource = choices,
                DisplayMember = "Text",
                ValueMember = "SectionId"
            };

            row.Cells[ColSection] = cell;

            bool selectable = offering.Status == OfferingStatus.Available;

            row.Cells[colAvailability.Index].Value = selectable
                ? $"{offering.Sections.Count} section(s)"
                : offering.StatusMessage;

            if (!selectable)
            {
                row.ReadOnly = true;
                row.DefaultCellStyle.ForeColor = Color.Gray;
                row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            }
            else if (preselected.TryGetValue(offering.SubjectId, out int sectionId))
            {
                row.Cells[ColSelect].Value = true;
                cell.Value = sectionId;
            }
            else if (offering.Sections.Count == 1)
            {
                cell.Value = offering.Sections[0].SectionId;
            }
        }

        _loading = false;

        rtbIssues.Clear();

        if (offerings.Count == 0)
        {
            AppendLine("No subjects are available for your program and year level this term. " +
                       "Please contact the registrar's office.", Color.Firebrick);
        }

        btnSubmit.Enabled = _context.IsOpen;
        UpdateUnits();
    }

    // ------------------------------------------------------------ selection

    private void UpdateUnits()
    {
        int total = 0;

        foreach (DataGridViewRow row in dgvOfferings.Rows)
        {
            if (row.Cells[ColSelect].Value is true && row.Tag is SubjectOffering offering)
            {
                total += offering.Units;
            }
        }

        string limits = _period == null ? "" : $"\nAllowed: {_period.MinUnits}-{_period.MaxUnits}";
        lblUnits.Text = $"Selected: {total} units{limits}";
    }

    private List<Selection>? CollectSelections()
    {
        var selections = new List<Selection>();

        foreach (DataGridViewRow row in dgvOfferings.Rows)
        {
            if (row.Cells[ColSelect].Value is not true || row.Tag is not SubjectOffering offering)
            {
                continue;
            }

            if (row.Cells[ColSection].Value == null)
            {
                rtbIssues.Clear();
                AppendLine($"Choose a section for {offering.SubjectCode} before continuing.", Color.Firebrick);
                return null;
            }

            selections.Add(new Selection(offering.SubjectId, Convert.ToInt32(row.Cells[ColSection].Value)));
        }

        return selections;
    }

    private void CheckSelection()
    {
        List<Selection>? selections = CollectSelections();

        if (selections != null)
        {
            ShowIssues(_service.Validate(_studentId, selections));
        }
    }

    private void SubmitEnrollment()
    {
        List<Selection>? selections = CollectSelections();

        if (selections == null)
        {
            return;
        }

        ValidationResult result = _service.Validate(_studentId, selections);

        if (!result.IsValid)
        {
            ShowIssues(result);
            return;
        }

        if (MessageBox.Show(
                $"Submit your enrollment for {_period!.Label}?\n\n{selections.Count} subjects, {result.TotalUnits} units.\n" +
                "The registrar will review it, and you will be notified of the decision.",
                "Submit Enrollment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        _service.Submit(_studentId, selections);

        MessageBox.Show("Your enrollment was submitted and is waiting for review.",
            "Enrollment Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

        LoadPage();
    }

    private void JoinWaitlist()
    {
        if (dgvOfferings.CurrentRow?.Tag is not SubjectOffering offering ||
            dgvOfferings.CurrentRow.Cells[ColSection].Value == null)
        {
            MessageBox.Show("Select a subject row and choose its (full) section first.",
                "Waitlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _service.JoinWaitlist(_studentId, Convert.ToInt32(dgvOfferings.CurrentRow.Cells[ColSection].Value),
            offering.SubjectId);

        MessageBox.Show($"You joined the waitlist for {offering.SubjectCode}. You will be notified if a slot opens.",
            "Waitlist", MessageBoxButtons.OK, MessageBoxIcon.Information);

        ShowWaitlist();
    }

    private void CancelRequest()
    {
        if (MessageBox.Show("Cancel your pending enrollment request? Your reserved slots will be released.",
                "Cancel Request", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        {
            return;
        }

        _service.Cancel(_context!.EnrollmentId!.Value);
        LoadPage();
    }

    // ------------------------------------------------------------ feedback

    private void ShowIssues(ValidationResult result)
    {
        rtbIssues.Clear();

        if (result.IsValid)
        {
            AppendLine($"All checks passed. {result.TotalUnits} units selected. You can submit your enrollment.", UiStyle.Brand);
            return;
        }

        foreach (ValidationIssue issue in result.Issues)
        {
            AppendLine("• " + issue.Message, Color.Firebrick);

            if (issue.Suggestions != null)
            {
                foreach (string suggestion in issue.Suggestions)
                {
                    AppendLine("      → " + suggestion, Color.SteelBlue);
                }
            }
        }
    }

    private void AppendLine(string text, Color color)
    {
        rtbIssues.SelectionStart = rtbIssues.TextLength;
        rtbIssues.SelectionColor = color;
        rtbIssues.AppendText(text + Environment.NewLine);
    }
}
