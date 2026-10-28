using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Completed, current and remaining subjects of the student's curriculum.</summary>
public partial class MyCurriculumForm : Form
{
    private readonly StudentPortalService _service = new();
    private readonly int _studentId;
    private readonly ListGrid _list;

    public MyCurriculumForm(int studentId)
    {
        InitializeComponent();
        _studentId = studentId;

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "Your program does not have a curriculum yet. Please contact the registrar."
        };
    }

    private void MyCurriculumForm_Load(object? sender, EventArgs e)
    {
        _list.Run(() =>
        {
            CurriculumProgress progress = _service.GetCurriculumProgress(_studentId);
            int percent = progress.TotalUnits == 0 ? 0 : progress.CompletedUnits * 100 / progress.TotalUnits;

            _list.SetSubtitle(
                $"{progress.CompletedUnits} of {progress.TotalUnits} units completed ({percent}%)   |   " +
                $"{progress.RemainingSubjects} subject(s) remaining   |   {progress.Deficiencies} deficiency(ies)");

            _list.SetData(progress.Subjects);
        });
    }

    private void btnPrint_Click(object? sender, EventArgs e) => _list.Run(() => _list.Print("Curriculum Progress"));
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("curriculum_progress"));
}
