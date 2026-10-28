using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class PeriodEditDialog : Form
{
    private readonly PeriodService _service = new();
    private readonly AcademicPeriod? _existing;

    public PeriodEditDialog(AcademicPeriod? existing = null)
    {
        InitializeComponent();
        _existing = existing;
        Text = existing == null ? "Add Academic Period" : "Edit Academic Period";

        int startYear = DateTime.Today.Month >= 6 ? DateTime.Today.Year : DateTime.Today.Year - 1;

        txtYear.Text = existing?.SchoolYear ?? $"{startYear}-{startYear + 1}";
        cmbSemester.SelectedItem = existing?.Semester ?? Academic.Semesters[0];
        dtpStart.Value = existing?.EnrollmentStart ?? DateTime.Today;
        dtpEnd.Value = existing?.EnrollmentEnd ?? DateTime.Today.AddDays(14);
        nudMin.Value = existing?.MinUnits ?? 12;
        nudMax.Value = existing?.MaxUnits ?? 24;
        chkCurrent.Checked = existing?.IsCurrent ?? false;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (cmbSemester.SelectedItem is not string semester)
            {
                return "Please choose a semester.";
            }

            _service.Save(new AcademicPeriod(_existing?.PeriodId ?? 0, txtYear.Text.Trim(), semester,
                dtpStart.Value.Date, dtpEnd.Value.Date, (int)nudMin.Value, (int)nudMax.Value, chkCurrent.Checked));

            return null;
        });
    }
}
