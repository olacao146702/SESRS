using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class CurriculumAddDialog : Form
{
    private readonly CurriculumService _service = new();
    private readonly int _programId;

    public CurriculumAddDialog(int programId)
    {
        InitializeComponent();
        _programId = programId;
        Text = "Add Subject to Curriculum";

        DialogHelper.Fill(cmbSubject, _service.GetSubjectsNotInCurriculum(programId)
            .Select(s => new ChoiceItem(s.Id, s.Label)));

        cmbYear.SelectedIndex = 0;
        cmbSemester.SelectedItem = Academic.Semesters[0];
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (!DialogHelper.HasSelection(cmbSubject) || cmbYear.SelectedIndex < 0 ||
                cmbSemester.SelectedItem is not string semester)
            {
                return "Please choose a subject, year level and semester.";
            }

            _service.AddEntry(_programId, DialogHelper.Value<int>(cmbSubject), cmbYear.SelectedIndex + 1, semester);
            return null;
        });
    }
}
