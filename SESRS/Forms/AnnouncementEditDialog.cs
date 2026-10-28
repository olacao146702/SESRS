using System.Data;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class AnnouncementEditDialog : Form
{
    private readonly AnnouncementService _service = new();
    private readonly AnnouncementDraft? _existing;

    /// <summary>How many students were notified when a new announcement was published.</summary>
    public int Notified { get; private set; }

    public AnnouncementEditDialog(AnnouncementDraft? existing = null)
    {
        InitializeComponent();
        _existing = existing;

        Text = existing == null ? "New Announcement" : "Edit Announcement";
        btnSave.Text = existing == null ? "PUBLISH" : "SAVE";
        lblIntro.Text = existing == null
            ? "Each targeted student receives a notification when you publish."
            : "Editing does not notify students again.";

        var programs = new List<ChoiceItem> { new(0, "All programs") };
        programs.AddRange(new ProgramService().GetAllPrograms().Rows.Cast<DataRow>()
            .Select(r => new ChoiceItem(Convert.ToInt32(r["program_id"]), Convert.ToString(r["program_code"]) ?? "")));

        var years = new List<ChoiceItem> { new(0, "All year levels") };
        years.AddRange(Enumerable.Range(1, 6).Select(y => new ChoiceItem(y, Academic.YearLabel(y))));

        var sections = new List<ChoiceItem> { new(0, "All sections") };
        sections.AddRange(new ScheduleService().GetSectionChoices().Rows.Cast<DataRow>()
            .Select(r => new ChoiceItem(Convert.ToInt32(r["section_id"]), Convert.ToString(r["label"]) ?? "")));

        DialogHelper.Fill(cmbProgram, programs, existing?.ProgramId ?? 0);
        DialogHelper.Fill(cmbYear, years, existing?.YearLevel ?? 0);
        DialogHelper.Fill(cmbSection, sections, existing?.SectionId ?? 0);

        txtTitle.Text = existing?.Title ?? "";
        txtBody.Text = existing?.Body ?? "";
        chkHasExpiry.Checked = existing?.ExpiresAt != null;
        dtpExpiry.Value = existing?.ExpiresAt ?? DateTime.Today.AddDays(14);
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            int program = DialogHelper.Value<int>(cmbProgram);
            int year = DialogHelper.Value<int>(cmbYear);
            int section = DialogHelper.Value<int>(cmbSection);

            var draft = new AnnouncementDraft(
                _existing?.AnnouncementId ?? 0, txtTitle.Text.Trim(), txtBody.Text.Trim(),
                program == 0 ? null : program, year == 0 ? null : year, section == 0 ? null : section,
                chkHasExpiry.Checked ? dtpExpiry.Value.Date : null);

            if (_existing == null)
            {
                Notified = _service.Publish(draft);
            }
            else
            {
                _service.Update(draft);
            }
        });
    }
}
