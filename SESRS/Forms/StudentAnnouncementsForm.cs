using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>School announcements that apply to the signed-in student.</summary>
public partial class StudentAnnouncementsForm : Form
{
    private readonly StudentPortalService _service = new();
    private readonly int _studentId;
    private readonly ListGrid _list;

    public StudentAnnouncementsForm(int studentId)
    {
        InitializeComponent();
        _studentId = studentId;

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "There are no announcements right now."
        };
        _list.RowActivated += (_, _) => _list.Run(Read);
    }

    private void StudentAnnouncementsForm_Load(object? sender, EventArgs e) =>
        _list.Run(() => _list.SetData(_service.GetAnnouncements(_studentId), "announcement_id", "body"));

    private void btnRead_Click(object? sender, EventArgs e) => _list.Run(Read);

    private void Read()
    {
        DataRow? row = _list.RequireRow("announcement");

        if (row == null)
        {
            return;
        }

        string meta = $"Posted by {row["posted_by"]} on {Convert.ToDateTime(row["created_at"]):MMM d, yyyy}";

        using var dialog = new TextDialog(Convert.ToString(row["title"]) ?? "", meta, Convert.ToString(row["body"]) ?? "");
        dialog.ShowDialog(this);
    }
}
