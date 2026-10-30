
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class ScheduleMeetingDialog : Form
{
    private readonly ScheduleService _service = new();
    private readonly int _sectionId;
    private readonly ScheduleEntry? _existing;

    private static readonly string[] Days =
    {
        "Monday", "Tuesday", "Wednesday", "Thursday",
        "Friday", "Saturday", "Sunday"
    };

    private static readonly Dictionary<string, string[]> Patterns = new()
    {
        ["MWF"] = new[] { "Monday", "Wednesday", "Friday" },
        ["Monday-Friday"] = new[]
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"
        },
        ["MSAT1"] = new[] { "Monday", "Tuesday", "Wednesday" },
        ["MSAT2"] = new[] { "Thursday", "Friday", "Saturday" }
    };

    public ScheduleMeetingDialog(int sectionId, ScheduleEntry? existing = null)
    {
        InitializeComponent();

        _sectionId = sectionId;
        _existing = existing;

        Text = existing == null
            ? "Add Class Meeting"
            : "Edit Class Meeting";

        DialogHelper.Fill(
            cmbSubject,
            _service.GetSubjectChoices(sectionId)
                .Select(s => new ChoiceItem(s.Id, s.Label)),
            existing?.SubjectId);

        // Keep editing behavior unchanged: edit one day at a time.
        cmbDay.Items.Clear();

        if (existing != null)
        {
            cmbDay.Items.AddRange(Days);
            cmbDay.SelectedItem = existing.Day;
            lblDay.Text = "Day *";
        }
        else
        {
            cmbDay.Items.AddRange(new object[]
            {
                "Monday", "Tuesday", "Wednesday", "Thursday",
                "Friday", "Saturday", "Sunday",
                "MWF", "Monday-Friday", "MSAT1", "MSAT2"
            });

            cmbDay.SelectedItem = "Monday";
            lblDay.Text = "Day / Schedule Pattern *";
        }

        dtpStart.Value =
            DateTime.Today.Add(existing?.Start ?? TimeSpan.FromHours(8));

        dtpEnd.Value =
            DateTime.Today.Add(existing?.End ?? TimeSpan.FromHours(9.5));

        txtRoom.Text = existing?.Room ?? "";
        txtInstructor.Text = existing?.Instructor ?? "";
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (!DialogHelper.HasSelection(cmbSubject) ||
                cmbDay.SelectedItem is not string selection)
            {
                return "Please choose a subject and a day or schedule pattern.";
            }

            if (dtpEnd.Value.TimeOfDay <= dtpStart.Value.TimeOfDay)
            {
                return "The end time must be after the start time.";
            }

            int subjectId = DialogHelper.Value<int>(cmbSubject);
            string instructor = txtInstructor.Text.Trim();
            string room = txtRoom.Text.Trim();

            if (_existing != null)
            {
                // Preserve the original single-meeting edit behavior.
                _service.Save(new ScheduleEntry(
                    _existing.ScheduleId,
                    _sectionId,
                    subjectId,
                    instructor,
                    room,
                    selection,
                    dtpStart.Value.TimeOfDay,
                    dtpEnd.Value.TimeOfDay));
            }
            else
            {
                string[] selectedDays = Patterns.TryGetValue(
                    selection, out string[]? pattern)
                    ? pattern
                    : new[] { selection };

                // Save every day as one atomic operation.
                _service.SavePattern(
                    _sectionId,
                    subjectId,
                    instructor,
                    room,
                    selectedDays,
                    dtpStart.Value.TimeOfDay,
                    dtpEnd.Value.TimeOfDay);
            }

            return null;
        });
    }
}
