using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Publish announcements to all students or to a program, year level or section.</summary>
public partial class AnnouncementManagementForm : Form
{
    private readonly AnnouncementService _service = new();
    private readonly ListGrid _list;

    public AnnouncementManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No announcements yet. Click NEW ANNOUNCEMENT to publish one."
        };
        _list.RowActivated += (_, _) => _list.Run(View);
    }

    private void AnnouncementManagementForm_Load(object? sender, EventArgs e) => ReloadData();

    private void ReloadData() =>
        _list.Run(() => _list.SetData(_service.GetAll(), "announcement_id", "body"));

    private void btnNew_Click(object? sender, EventArgs e) => _list.Run(() => ShowEditor(null));
    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);
    private void btnToggle_Click(object? sender, EventArgs e) => _list.Run(ToggleActive);
    private void btnDelete_Click(object? sender, EventArgs e) => _list.Run(Delete);
    private void btnView_Click(object? sender, EventArgs e) => _list.Run(View);

    private void View()
    {
        DataRow? row = _list.RequireRow("announcement");

        if (row == null)
        {
            return;
        }

        string meta = $"{row["audience"]}   |   posted by {row["posted_by"]} on {Convert.ToDateTime(row["created_at"]):MMM d, yyyy}";

        using var dialog = new TextDialog(Convert.ToString(row["title"]) ?? "", meta, Convert.ToString(row["body"]) ?? "");
        dialog.ShowDialog(this);
    }

    private void Edit()
    {
        DataRow? row = _list.RequireRow("announcement");

        if (row == null)
        {
            return;
        }

        AnnouncementDraft? draft = _service.Get(Convert.ToInt32(row["announcement_id"]));

        if (draft == null)
        {
            ReloadData();
            return;
        }

        ShowEditor(draft);
    }

    private void ToggleActive()
    {
        DataRow? row = _list.RequireRow("announcement");

        if (row == null)
        {
            return;
        }

        bool withdrawn = Convert.ToString(row["status"]) == "Withdrawn";

        if (!_list.Confirm(withdrawn
                ? "Restore this announcement so students can see it again?"
                : "Withdraw this announcement? Students will no longer see it."))
        {
            return;
        }

        _service.SetActive(Convert.ToInt32(row["announcement_id"]), withdrawn);
        _list.Success(withdrawn ? "Announcement restored." : "Announcement withdrawn.");
        ReloadData();
    }

    private void Delete()
    {
        DataRow? row = _list.RequireRow("announcement");

        if (row == null || !_list.Confirm("Delete this announcement permanently?"))
        {
            return;
        }

        _service.Delete(Convert.ToInt32(row["announcement_id"]));
        _list.Success("Announcement deleted.");
        ReloadData();
    }

    private void ShowEditor(AnnouncementDraft? existing)
    {
        using var dialog = new AnnouncementEditDialog(existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success(existing == null
                ? $"Announcement published. {dialog.Notified} student(s) notified."
                : "Announcement updated.");
            ReloadData();
        }
    }
}
