using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

public partial class CurriculumManagementForm : Form
{
    private readonly CurriculumService _service = new();
    private readonly StudentService _students = new();
    private readonly ListGrid _list;
    private bool _ready;

    public CurriculumManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "This program has no curriculum yet. Click ADD SUBJECT to build it."
        };
    }

    private int? ProgramId => (cmbProgram.SelectedItem as ChoiceItem)?.Value as int?;

    private void CurriculumManagementForm_Load(object? sender, EventArgs e)
    {
        _list.Run(() =>
        {
            DialogHelper.Fill(cmbProgram, _students.GetActivePrograms().Select(p => new ChoiceItem(p.Id, p.Name)));

            if (cmbProgram.Items.Count > 0)
            {
                cmbProgram.SelectedIndex = 0;
            }
        });

        _ready = true;
        ReloadData();
    }

    private void cmbProgram_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_ready)
        {
            ReloadData();
        }
    }

    private void ReloadData()
    {
        _list.Run(() =>
        {
            if (ProgramId is not int programId)
            {
                _list.EmptyMessage = "There are no active programs. Add a program first.";
                _list.SetData(new DataTable());
                return;
            }

            _list.SetData(_service.GetCurriculum(programId), "curriculum_id");
        });
    }

    private void btnAdd_Click(object? sender, EventArgs e) => _list.Run(AddEntry);
    private void btnPrerequisites_Click(object? sender, EventArgs e) => _list.Run(EditPrerequisites);
    private void btnRemove_Click(object? sender, EventArgs e) => _list.Run(Remove);
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("curriculum"));

    private void AddEntry()
    {
        if (ProgramId is not int programId)
        {
            return;
        }

        if (_service.GetSubjectsNotInCurriculum(programId).Count == 0)
        {
            MessageBox.Show(
                "Every active subject is already in this curriculum. Add new subjects under Academics > Subjects first.",
                "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new CurriculumAddDialog(programId);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success("Subject added to the curriculum.");
            ReloadData();
        }
    }

    private void Remove()
    {
        DataRow? row = _list.RequireRow("curriculum entry");

        if (row == null || !_list.Confirm($"Remove {row["subject_code"]} from this curriculum?\n\n" +
                                          "Existing enrollments and grades are not affected."))
        {
            return;
        }

        _service.RemoveEntry(Convert.ToInt32(row["curriculum_id"]));
        _list.Success("Subject removed.");
        ReloadData();
    }

    private void EditPrerequisites()
    {
        DataRow? row = _list.RequireRow("subject");

        if (row == null)
        {
            return;
        }

        int subjectId = _service.GetSubjectIdForEntry(Convert.ToInt32(row["curriculum_id"]));

        using var dialog = new PrerequisiteDialog(subjectId, Convert.ToString(row["subject_code"]) ?? "");

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success("Prerequisites saved.");
            ReloadData();
        }
    }
}
