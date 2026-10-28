using System.Data;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>All administrator reports in one place, with filters, printing and CSV export.</summary>
public partial class ReportCenterForm : Form
{
    private readonly ReportService _service = new();
    private readonly PeriodService _periods = new();
    private readonly ListGrid _list;

    private bool _ready;
    private string _title = "Report";

    public ReportCenterForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "This report has no records for the chosen filters."
        };
    }

    private ReportDefinition? Definition => (cmbReport.SelectedItem as ChoiceItem)?.Value as ReportDefinition;

    private void ReportCenterForm_Load(object? sender, EventArgs e)
    {
        _list.Run(Populate);
        _ready = true;
        ReloadData();
    }

    private void Filter_Changed(object? sender, EventArgs e)
    {
        if (_ready)
        {
            UpdateFilterAvailability();
            ReloadData();
        }
    }

    private void Populate()
    {
        DialogHelper.Fill(cmbReport, ReportService.Definitions.Select(d => new ChoiceItem(d, d.Name)));

        DialogHelper.Fill(cmbTerm, new[] { new ChoiceItem(("", ""), "Current term") }
            .Concat(_periods.GetAll().Rows.Cast<DataRow>().Select(r => new ChoiceItem(
                (Convert.ToString(r["school_year"]) ?? "", Convert.ToString(r["semester"]) ?? ""),
                $"{r["school_year"]}, {r["semester"]}"))));

        DialogHelper.Fill(cmbProgram, new[] { new ChoiceItem(0, "All programs") }
            .Concat(new ProgramService().GetAllPrograms().Rows.Cast<DataRow>().Select(r =>
                new ChoiceItem(Convert.ToInt32(r["program_id"]), Convert.ToString(r["program_code"]) ?? ""))));

        DialogHelper.Fill(cmbYear, new[] { new ChoiceItem(0, "All years") }
            .Concat(Enumerable.Range(1, 6).Select(y => new ChoiceItem(y, Academic.YearLabel(y)))));

        DialogHelper.Fill(cmbSection, new[] { new ChoiceItem(0, "All sections") }
            .Concat(new ScheduleService().GetSectionChoices().Rows.Cast<DataRow>().Select(r =>
                new ChoiceItem(Convert.ToInt32(r["section_id"]), Convert.ToString(r["label"]) ?? ""))));

        foreach (ComboBox box in new[] { cmbReport, cmbTerm, cmbProgram, cmbYear, cmbSection })
        {
            box.SelectedIndex = 0;
        }

        UpdateFilterAvailability();
    }

    private void UpdateFilterAvailability()
    {
        ReportDefinition? d = Definition;

        cmbTerm.Enabled = d?.UsesTerm ?? false;
        cmbProgram.Enabled = d?.UsesProgram ?? false;
        cmbYear.Enabled = d?.UsesYear ?? false;
        cmbSection.Enabled = d?.UsesSection ?? false;
    }

    private static int? Id(ComboBox box) => box.SelectedItem is ChoiceItem { Value: int id } && id > 0 ? id : null;

    private void ReloadData()
    {
        _list.Run(() =>
        {
            ReportDefinition? definition = Definition;

            if (definition == null)
            {
                return;
            }

            string? schoolYear = null, semester = null;

            if (cmbTerm.SelectedItem is ChoiceItem { Value: ValueTuple<string, string> t } && t.Item1.Length > 0)
            {
                schoolYear = t.Item1;
                semester = t.Item2;
            }

            ReportResult result = _service.Run(definition.Key,
                new ReportFilter(schoolYear, semester, Id(cmbProgram), Id(cmbYear), Id(cmbSection)));

            _title = result.Title;
            _list.SetSubtitle($"{definition.Description}   |   {result.Subtitle}");
            _list.SetData(result.Table);
        });
    }

    private void btnPrint_Click(object? sender, EventArgs e) => _list.Run(() => _list.Print(_title));
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("report"));
}
