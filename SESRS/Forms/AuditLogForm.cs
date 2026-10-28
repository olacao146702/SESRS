using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Searchable record of sensitive actions (logins, account changes, enrollment and grade decisions).</summary>
public partial class AuditLogForm : Form
{
    private readonly AuditService _service = new();
    private readonly ListGrid _list;
    private bool _ready;

    public AuditLogForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No activity was recorded in this date range."
        };
    }

    private void AuditLogForm_Load(object? sender, EventArgs e)
    {
        dtpFrom.Value = DateTime.Today.AddDays(-7);
        dtpTo.Value = DateTime.Today;
        _ready = true;
        ReloadData();
    }

    private void dtpFrom_ValueChanged(object? sender, EventArgs e) { if (_ready) ReloadData(); }
    private void dtpTo_ValueChanged(object? sender, EventArgs e) { if (_ready) ReloadData(); }

    private void ReloadData() =>
        _list.Run(() => _list.SetData(_service.Search(dtpFrom.Value, dtpTo.Value), "audit_id"));

    private void btnPrint_Click(object? sender, EventArgs e) => _list.Run(() => _list.Print("Audit Log"));
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("audit_log"));
}
