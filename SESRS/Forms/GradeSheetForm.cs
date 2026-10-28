using System.Data;
using System.Globalization;
using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Administrator grade entry: scores per component, review, publish and revisions.</summary>
public partial class GradeSheetForm : Form
{
    private readonly GradeService _service = new();
    private readonly PeriodService _periods = new();
    private readonly System.Windows.Forms.Timer _statusTimer = new() { Interval = 5000 };

    private GradeSheet? _sheet;
    private bool _loading;
    private bool _dirty;

    public GradeSheetForm()
    {
        InitializeComponent();

        _statusTimer.Tick += (_, _) => { lblStatus.Text = ""; _statusTimer.Stop(); };

        dgvGrades.CellValidating += Grid_CellValidating;
        dgvGrades.CellEndEdit += Grid_CellEndEdit;
        dgvGrades.CurrentCellDirtyStateChanged += (_, _) =>
        {
            if (dgvGrades.IsCurrentCellDirty)
            {
                dgvGrades.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        };
        dgvGrades.DataError += (_, e) => e.ThrowException = false;
    }

    private void GradeSheetForm_Load(object? sender, EventArgs e) => Safe(LoadTerms);

    private void cmbTerm_SelectedIndexChanged(object? sender, EventArgs e) { if (!_loading) Safe(OnTermChanged); }
    private void cmbClass_SelectedIndexChanged(object? sender, EventArgs e) { if (!_loading) Safe(OnClassChanged); }

    private void btnSave_Click(object? sender, EventArgs e) => Safe(Save);
    private void btnReview_Click(object? sender, EventArgs e) => Safe(Review);
    private void btnPublish_Click(object? sender, EventArgs e) => Safe(Publish);
    private void btnUnpublish_Click(object? sender, EventArgs e) => Safe(Unpublish);
    private void btnHistory_Click(object? sender, EventArgs e) => Safe(ShowHistory);
    private void btnPrior_Click(object? sender, EventArgs e) => Safe(AddPriorRecord);
    private void btnPrint_Click(object? sender, EventArgs e) => Safe(Print);

    private void Safe(Action action)
    {
        try
        {
            UseWaitCursor = true;
            action();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorHandler.Friendly(ex), "Grades", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            UseWaitCursor = false;
        }
    }

    private void Success(string message)
    {
        lblStatus.ForeColor = UiStyle.Brand;
        lblStatus.Text = "✔ " + message;
        _statusTimer.Stop();
        _statusTimer.Start();
    }

    // ------------------------------------------------------------ loading

    private void LoadTerms()
    {
        _loading = true;
        cmbTerm.Items.Clear();

        AcademicPeriod? current = _periods.GetCurrent();
        ChoiceItem? toSelect = null;

        foreach (DataRow row in _periods.GetAll().Rows)
        {
            string sy = Convert.ToString(row["school_year"]) ?? "";
            string sem = Convert.ToString(row["semester"]) ?? "";
            var item = new ChoiceItem((sy, sem), $"{sy}, {sem}");
            cmbTerm.Items.Add(item);

            if (current != null && current.SchoolYear == sy && current.Semester == sem)
            {
                toSelect = item;
            }
        }

        _loading = false;

        if (cmbTerm.Items.Count == 0)
        {
            ShowEmpty("No academic periods exist yet. Create one under Academics > Academic Periods.");
            return;
        }

        cmbTerm.SelectedItem = toSelect ?? cmbTerm.Items[0];
    }

    private bool ConfirmDiscard()
    {
        return !_dirty ||
               MessageBox.Show("You have unsaved scores. Discard them?", "Unsaved changes",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
    }

    private void OnTermChanged()
    {
        if (!ConfirmDiscard())
        {
            return;
        }

        _loading = true;
        cmbClass.Items.Clear();

        if (cmbTerm.SelectedItem is ChoiceItem { Value: ValueTuple<string, string> term })
        {
            foreach (DataRow row in _service.GetClasses(term.Item1, term.Item2).Rows)
            {
                cmbClass.Items.Add(new ChoiceItem(
                    (Convert.ToInt32(row["section_id"]), Convert.ToInt32(row["subject_id"])),
                    Convert.ToString(row["label"]) ?? ""));
            }
        }

        _loading = false;

        if (cmbClass.Items.Count == 0)
        {
            ShowEmpty("No classes have approved students in this term yet.");
            return;
        }

        cmbClass.SelectedIndex = 0;
    }

    private void OnClassChanged()
    {
        if (cmbClass.SelectedItem is ChoiceItem { Value: ValueTuple<int, int> key })
        {
            LoadSheet(key.Item1, key.Item2);
        }
    }

    private void ShowEmpty(string message)
    {
        _sheet = null;
        _dirty = false;
        dgvGrades.Columns.Clear();
        dgvGrades.Rows.Clear();
        lblInfo.ForeColor = UiStyle.Muted;
        lblInfo.Text = message;
    }

    private void LoadSheet(int sectionId, int subjectId)
    {
        _sheet = _service.GetSheet(sectionId, subjectId);
        _dirty = false;
        _loading = true;

        dgvGrades.Columns.Clear();
        dgvGrades.Rows.Clear();

        dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "student_number", HeaderText = "Student No.", ReadOnly = true, FillWeight = 70 });
        dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "student_name", HeaderText = "Student", ReadOnly = true, FillWeight = 150 });

        foreach (GradeComponent c in _sheet.Components)
        {
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "c_" + c.ComponentId,
                HeaderText = $"{c.Name} ({c.Weight:0.##}%)",
                FillWeight = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        var special = new DataGridViewComboBoxColumn { Name = "special", HeaderText = "Special mark", FillWeight = 80 };
        special.Items.AddRange("", "Incomplete", "Dropped");
        dgvGrades.Columns.Add(special);

        dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "percent", HeaderText = "Percent", ReadOnly = true, FillWeight = 55 });
        dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "final_grade", HeaderText = "Grade", ReadOnly = true, FillWeight = 50 });
        dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "result", HeaderText = "Result", ReadOnly = true, FillWeight = 60 });
        dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "grade_status", HeaderText = "Status", ReadOnly = true, FillWeight = 60 });

        foreach (DataRow r in _sheet.Rows.Rows)
        {
            int index = dgvGrades.Rows.Add();
            DataGridViewRow row = dgvGrades.Rows[index];
            row.Tag = Convert.ToInt32(r["student_id"]);

            row.Cells["student_number"].Value = r["student_number"];
            row.Cells["student_name"].Value = r["student_name"];

            foreach (GradeComponent c in _sheet.Components)
            {
                object value = r["c_" + c.ComponentId];
                row.Cells["c_" + c.ComponentId].Value = value == DBNull.Value ? "" : Convert.ToDecimal(value).ToString("0.##");
            }

            row.Cells["special"].Value = Convert.ToString(r["special"]) ?? "";
            ShowComputed(row, r["percent"], r["final_grade"], Convert.ToString(r["result"]) ?? "",
                Convert.ToString(r["grade_status"]) ?? "");
        }

        _loading = false;

        string? problem = GradeCalculator.ValidateWeights(_sheet.Components);
        int published = _sheet.Rows.Rows.Cast<DataRow>().Count(r => (string)r["grade_status"] == "Published");
        int reviewed = _sheet.Rows.Rows.Cast<DataRow>().Count(r => (string)r["grade_status"] == "Reviewed");

        if (problem != null)
        {
            lblInfo.ForeColor = Color.Firebrick;
            lblInfo.Text = problem + " Fix it under Academics > Grading Setup before entering scores.";
        }
        else
        {
            lblInfo.ForeColor = UiStyle.Muted;
            lblInfo.Text = $"{_sheet.Rows.Rows.Count} student(s)   |   {reviewed} reviewed   |   {published} published   |   " +
                           "Scores are 0-100. Use a special mark for Incomplete or Dropped.";
        }
    }

    private static Color ResultColor(string result) => result switch
    {
        "Passed" => Color.DarkGreen,
        "Failed" => Color.Firebrick,
        "Pending" => Color.DarkOrange,
        _ => Color.Black
    };

    private static void ShowComputed(DataGridViewRow row, object percent, object grade, string result, string status)
    {
        row.Cells["percent"].Value = percent == DBNull.Value ? "" : Convert.ToDecimal(percent).ToString("0.00");
        row.Cells["final_grade"].Value = grade == DBNull.Value ? "" : Convert.ToDecimal(grade).ToString("0.00");
        row.Cells["result"].Value = result;
        row.Cells["grade_status"].Value = status;
        row.Cells["result"].Style.ForeColor = ResultColor(result);
    }

    // ------------------------------------------------------------ editing

    private void Grid_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
    {
        if (!dgvGrades.Columns[e.ColumnIndex].Name.StartsWith("c_"))
        {
            return;
        }

        string text = Convert.ToString(e.FormattedValue)?.Trim() ?? "";

        if (text.Length == 0)
        {
            return;
        }

        if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value) ||
            value < 0 || value > 100)
        {
            e.Cancel = true;
            MessageBox.Show("Enter a score between 0 and 100 (or leave it blank).", "Invalid score",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void Grid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
    {
        if (_loading || _sheet == null || e.RowIndex < 0)
        {
            return;
        }

        string name = dgvGrades.Columns[e.ColumnIndex].Name;

        if (!(name.StartsWith("c_") || name == "special"))
        {
            return;
        }

        DataGridViewRow row = dgvGrades.Rows[e.RowIndex];
        _dirty = true;
        row.DefaultCellStyle.BackColor = Color.LightYellow;

        GradeEntry entry = ReadEntry(row);
        GradeComputation computed = GradeCalculator.Compute(_sheet.Components, _sheet.Scale, entry.Scores, entry.Special);

        row.Cells["percent"].Value = computed.Percent?.ToString("0.00") ?? "";
        row.Cells["final_grade"].Value = computed.GradePoint?.ToString("0.00") ?? "";
        row.Cells["result"].Value = computed.Result;
        row.Cells["result"].Style.ForeColor = ResultColor(computed.Result);
    }

    private GradeEntry ReadEntry(DataGridViewRow row)
    {
        var scores = new Dictionary<int, decimal?>();

        foreach (GradeComponent c in _sheet!.Components)
        {
            string text = Convert.ToString(row.Cells["c_" + c.ComponentId].Value)?.Trim() ?? "";

            scores[c.ComponentId] = text.Length == 0
                ? null
                : decimal.Parse(text, NumberStyles.Number, CultureInfo.CurrentCulture);
        }

        string special = Convert.ToString(row.Cells["special"].Value) ?? "";

        return new GradeEntry((int)row.Tag!, scores, special.Length == 0 ? null : special);
    }

    // ------------------------------------------------------------ actions

    private bool RequireSheet()
    {
        if (_sheet == null)
        {
            MessageBox.Show("Select a term and a class first.", "Grades", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        return true;
    }

    private bool CheckSaved()
    {
        if (!_dirty)
        {
            return true;
        }

        MessageBox.Show("Save your changes first.", "Unsaved changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }

    private void Save()
    {
        if (!RequireSheet())
        {
            return;
        }

        dgvGrades.EndEdit();

        var changedRows = dgvGrades.Rows.Cast<DataGridViewRow>()
            .Where(r => r.DefaultCellStyle.BackColor == Color.LightYellow)
            .ToList();

        if (changedRows.Count == 0)
        {
            MessageBox.Show("There are no changes to save.", "Grades", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var entries = changedRows.Select(ReadEntry).ToList();
        bool touchesPublished = changedRows.Any(r => Convert.ToString(r.Cells["grade_status"].Value) == "Published");

        if (touchesPublished)
        {
            int savedWithReason = 0;

            using var dialog = new ReasonDialog("Revise published grades",
                "You are changing grades students can already see. Enter the reason; students are notified.",
                "SAVE REVISION", true,
                reason => savedWithReason = _service.SaveSheet(_sheet!.SectionId, _sheet.SubjectId, entries, reason));

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            Success($"{savedWithReason} grade(s) saved.");
        }
        else
        {
            Success($"{_service.SaveSheet(_sheet!.SectionId, _sheet.SubjectId, entries, null)} grade(s) saved.");
        }

        LoadSheet(_sheet!.SectionId, _sheet.SubjectId);
    }

    private void Review()
    {
        if (!RequireSheet() || !CheckSaved())
        {
            return;
        }

        Success($"{_service.Review(_sheet!.SectionId, _sheet.SubjectId)} grade(s) marked as reviewed.");
        LoadSheet(_sheet.SectionId, _sheet.SubjectId);
    }

    private void Publish()
    {
        if (!RequireSheet() || !CheckSaved())
        {
            return;
        }

        if (MessageBox.Show("Publish the reviewed grades of this class?\n\nStudents will be able to see them immediately and will be notified.",
                "Publish grades", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        Success($"{_service.Publish(_sheet!.SectionId, _sheet.SubjectId)} grade(s) published.");
        LoadSheet(_sheet.SectionId, _sheet.SubjectId);
    }

    private void Unpublish()
    {
        if (!RequireSheet() || !CheckSaved())
        {
            return;
        }

        int count = 0;

        using var dialog = new ReasonDialog("Withdraw published grades",
            "Students will no longer see these grades and will be told why.", "WITHDRAW", true,
            reason => count = _service.Unpublish(_sheet!.SectionId, _sheet.SubjectId, reason!));

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        Success($"{count} grade(s) withdrawn.");
        LoadSheet(_sheet!.SectionId, _sheet.SubjectId);
    }

    private void ShowHistory()
    {
        if (!RequireSheet())
        {
            return;
        }

        if (dgvGrades.CurrentRow?.Tag is not int studentId)
        {
            MessageBox.Show("Select a student row first.", "History", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new TableDialog("Grade History",
            $"{dgvGrades.CurrentRow.Cells["student_name"].Value}  |  {_sheet!.ClassLabel}",
            _service.GetGradeAudit(studentId, _sheet.SubjectId), "grade_history");

        dialog.ShowDialog(this);
    }

    private void AddPriorRecord()
    {
        if (_service.GetStudentChoices().Count == 0 || new CurriculumService().GetAllSubjects().Count == 0)
        {
            MessageBox.Show("There must be active students and subjects first.", "Prior record",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new PriorRecordDialog();

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            Success("Prior record added.");
        }
    }

    private void Print()
    {
        if (!RequireSheet())
        {
            return;
        }

        var document = new ReportDocument
        {
            Title = "Grade Sheet",
            Subtitle = _sheet!.ClassLabel + "   (" + _sheet.SchoolYear + ", " + _sheet.Semester + ")",
            Landscape = true
        };

        document.AddColumn("Student No.", 1f);
        document.AddColumn("Student", 2.2f);

        foreach (GradeComponent c in _sheet.Components)
        {
            document.AddColumn($"{c.Name} ({c.Weight:0.##}%)", 1f);
        }

        document.AddColumn("Percent", 0.8f);
        document.AddColumn("Grade", 0.7f);
        document.AddColumn("Result", 0.9f);
        document.AddColumn("Status", 0.9f);

        foreach (DataGridViewRow row in dgvGrades.Rows)
        {
            var cells = new List<string>
            {
                Convert.ToString(row.Cells["student_number"].Value) ?? "",
                Convert.ToString(row.Cells["student_name"].Value) ?? ""
            };

            cells.AddRange(_sheet.Components.Select(c => Convert.ToString(row.Cells["c_" + c.ComponentId].Value) ?? ""));

            string special = Convert.ToString(row.Cells["special"].Value) ?? "";

            cells.Add(Convert.ToString(row.Cells["percent"].Value) ?? "");
            cells.Add(Convert.ToString(row.Cells["final_grade"].Value) ?? "");
            cells.Add(special.Length > 0 ? special : Convert.ToString(row.Cells["result"].Value) ?? "");
            cells.Add(Convert.ToString(row.Cells["grade_status"].Value) ?? "");

            document.Rows.Add(cells.ToArray());
        }

        if (_dirty)
        {
            document.Footer.Add("Contains unsaved changes.");
        }

        PrintReport.Preview(this, document);
    }
}
