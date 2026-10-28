using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class ScheduleMeetingDialog : Form
{
    private readonly ScheduleService _service = new();
    private readonly int _sectionId;
    private readonly ScheduleEntry? _existing;

    public ScheduleMeetingDialog(int sectionId, ScheduleEntry? existing = null)
    {
        InitializeComponent();
        _sectionId = sectionId;
        _existing = existing;
        Text = existing == null ? "Add Class Meeting" : "Edit Class Meeting";

        DialogHelper.Fill(cmbSubject, _service.GetSubjectChoices(sectionId).Select(s => new ChoiceItem(s.Id, s.Label)),
            existing?.SubjectId);

        cmbDay.SelectedItem = existing?.Day ?? "Monday";
        dtpStart.Value = DateTime.Today.Add(existing?.Start ?? TimeSpan.FromHours(8));
        dtpEnd.Value = DateTime.Today.Add(existing?.End ?? TimeSpan.FromHours(9.5));
        txtRoom.Text = existing?.Room ?? "";
        txtInstructor.Text = existing?.Instructor ?? "";
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (!DialogHelper.HasSelection(cmbSubject) || cmbDay.SelectedItem is not string day)
            {
                return "Please choose a subject and a day.";
            }

            _service.Save(new ScheduleEntry(_existing?.ScheduleId ?? 0, _sectionId,
                DialogHelper.Value<int>(cmbSubject), txtInstructor.Text.Trim(), txtRoom.Text.Trim(), day,
                dtpStart.Value.TimeOfDay, dtpEnd.Value.TimeOfDay));

            return null;
        });
    }
}
