using System.Data;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class SectionEditDialog : Form
{
    private readonly SectionService _service = new();
    private readonly DataRow? _existing;

    public SectionEditDialog(DataRow? existing = null)
    {
        InitializeComponent();
        _existing = existing;
        Text = existing == null ? "Add Section" : "Edit Section";

        DialogHelper.Fill(cmbProgram,
            _service.GetActivePrograms().Rows.Cast<DataRow>().Select(r =>
                new ChoiceItem(Convert.ToInt32(r["program_id"]), $"{r["program_code"]} - {r["program_name"]}")),
            existing == null ? null : Convert.ToInt32(existing["program_id"]));

        cmbYear.SelectedIndex = existing == null ? 0 : Convert.ToInt32(existing["year_level"]) - 1;
        cmbSemester.SelectedItem = existing?["semester"] as string ?? Academic.Semesters[0];
        txtSchoolYear.Text = existing?["school_year"] as string ?? new PeriodService().GetCurrent()?.SchoolYear ?? "";

        if (existing != null)
        {
            txtCode.Text = existing["section_code"] as string ?? "";
            txtName.Text = existing["section_name"] as string ?? "";
            nudCapacity.Value = Convert.ToInt32(existing["capacity"]);
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (!DialogHelper.HasSelection(cmbProgram))
            {
                return "Please select a program.";
            }

            int programId = DialogHelper.Value<int>(cmbProgram);
            int year = cmbYear.SelectedIndex + 1;
            string semester = cmbSemester.SelectedItem as string ?? "";
            string code = txtCode.Text.Trim(), name = txtName.Text.Trim(), schoolYear = txtSchoolYear.Text.Trim();
            int capacity = (int)nudCapacity.Value;

            if (_existing == null)
            {
                _service.AddSection(code, name, programId, year, semester, schoolYear, capacity);
            }
            else
            {
                _service.UpdateSection(Convert.ToInt32(_existing["section_id"]), code, name, programId, year,
                    semester, schoolYear, capacity);
            }

            return null;
        });
    }
}
