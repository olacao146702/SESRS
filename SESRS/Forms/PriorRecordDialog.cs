using System.Globalization;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Credits a result earned before the system was used.</summary>
public partial class PriorRecordDialog : Form
{
    private readonly GradeService _service = new();

    public PriorRecordDialog()
    {
        InitializeComponent();
        Text = "Add Prior Record";

        DialogHelper.Fill(cmbStudent, _service.GetStudentChoices().Select(s => new ChoiceItem(s.Id, s.Label)));
        DialogHelper.Fill(cmbSubject, new CurriculumService().GetAllSubjects().Select(s => new ChoiceItem(s.Id, s.Label)));

        int startYear = DateTime.Today.Month >= 6 ? DateTime.Today.Year - 1 : DateTime.Today.Year - 2;
        txtYear.Text = $"{startYear}-{startYear + 1}";
        cmbSemester.SelectedItem = Academic.Semesters[0];
        cmbResult.SelectedItem = "Passed";
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (!DialogHelper.HasSelection(cmbStudent) || !DialogHelper.HasSelection(cmbSubject))
            {
                return "Please choose a student and a subject.";
            }

            if (!decimal.TryParse(txtGrade.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal grade))
            {
                return "Enter the grade as a number, for example 1.75.";
            }

            if (cmbSemester.SelectedItem is not string semester || cmbResult.SelectedItem is not string result)
            {
                return "Please choose a semester and a result.";
            }

            _service.RecordPriorGrade(DialogHelper.Value<int>(cmbStudent), DialogHelper.Value<int>(cmbSubject),
                txtYear.Text.Trim(), semester, grade, result);

            return null;
        });
    }
}
