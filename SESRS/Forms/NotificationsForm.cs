using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Notification history with read/unread state and links to the related page.</summary>
public partial class NotificationsForm : Form
{
    private readonly NotificationService _service = new();
    private readonly Action<string>? _navigate;
    private readonly Action? _changed;
    private readonly ListGrid _list;

    public NotificationsForm(Action<string>? navigate = null, Action? changed = null)
    {
        InitializeComponent();
        _navigate = navigate;
        _changed = changed;

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "You have no notifications yet."
        };
        _list.RowActivated += (_, _) => _list.Run(OpenSelected);
    }

    private void NotificationsForm_Load(object? sender, EventArgs e) => ReloadData();

    private void ReloadData()
    {
        _list.Run(() =>
        {
            _list.SetData(_service.GetMine(), "notification_id", "is_read", "link");
            _changed?.Invoke();
        });
    }

    private void btnOpen_Click(object? sender, EventArgs e) => _list.Run(OpenSelected);
    private void btnMarkRead_Click(object? sender, EventArgs e) => _list.Run(MarkRead);
    private void btnMarkAll_Click(object? sender, EventArgs e) => _list.Run(MarkAllRead);

    private void OpenSelected()
    {
        DataRow? row = _list.RequireRow("notification");

        if (row == null)
        {
            return;
        }

        _service.MarkRead(Convert.ToInt32(row["notification_id"]));

        string? link = row["link"] as string;

        if (!string.IsNullOrEmpty(link) && _navigate != null)
        {
            _changed?.Invoke();
            _navigate(link);
            return;
        }

        MessageBox.Show(Convert.ToString(row["message"]), Convert.ToString(row["title"]),
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        ReloadData();
    }

    private void MarkRead()
    {
        DataRow? row = _list.RequireRow("notification");

        if (row == null)
        {
            return;
        }

        _service.MarkRead(Convert.ToInt32(row["notification_id"]));
        ReloadData();
    }

    private void MarkAllRead()
    {
        _service.MarkAllRead();
        _list.Success("All notifications marked as read.");
        ReloadData();
    }
}
