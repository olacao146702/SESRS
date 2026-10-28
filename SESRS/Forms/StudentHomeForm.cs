using System.Data;
using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>The student dashboard: profile, term, enrollment status, deadlines, announcements, notifications.</summary>
public partial class StudentHomeForm : Form
{
    private readonly int _studentId;
    private readonly Action<string> _navigate;
    private readonly StudentPortalService _portal = new();
    private DataTable _announcementRows = new();

    public StudentHomeForm(int studentId, Action<string> navigate)
    {
        InitializeComponent();
        _studentId = studentId;
        _navigate = navigate;
    }

    private void cardStatus_Click(object? sender, EventArgs e) => _navigate("enrollment");
    private void cardUnits_Click(object? sender, EventArgs e) => _navigate("schedule");
    private void cardNotifications_Click(object? sender, EventArgs e) => _navigate("notifications");
    private void lnkAnnouncements_Click(object? sender, EventArgs e) => _navigate("announcements");
    private void lnkNotifications_Click(object? sender, EventArgs e) => _navigate("notifications");
    private void lstNotifications_DoubleClick(object? sender, EventArgs e) => _navigate("notifications");

    private void StudentHomeForm_Load(object? sender, EventArgs e)
    {
        try
        {
            HomeSummary home = _portal.GetHomeSummary(_studentId);
            StudentProfile p = home.Profile;

            lblWelcome.Text = "Welcome, " + p.FullName + "!";
            lblIdentity.Text =
                $"Student No. {(p.StudentNumber.Length == 0 ? "pending" : p.StudentNumber)}   |   " +
                $"{p.ProgramCode} - {p.ProgramName}   |   {Academic.YearLabel(p.YearLevel)}   |   {p.Status}";

            lblTermValue.Text = home.Period?.Label ?? "Not set";

            lblStatusValue.Text = home.EnrollmentStatus;
            lblStatusValue.ForeColor = home.EnrollmentStatus switch
            {
                "Approved" => UiStyle.Brand,
                "Pending" => Color.DarkOrange,
                "Rejected" or "Returned" => Color.Firebrick,
                _ => UiStyle.Muted
            };

            lblUnitsValue.Text = home.EnrolledUnits + " units";
            lblNotificationsValue.Text = home.UnreadNotifications.ToString();

            int percent = home.TotalUnits == 0 ? 0 : home.CompletedUnits * 100 / home.TotalUnits;
            prgCurriculum.Value = Math.Min(100, Math.Max(0, percent));
            lblProgressText.Text =
                $"Curriculum progress: {home.CompletedUnits} of {home.TotalUnits} units completed ({percent}%)";

            rtbAlerts.Clear();

            foreach (string alert in home.Alerts)
            {
                rtbAlerts.SelectionColor = alert.Contains("rejected") || alert.Contains("missing") || alert.Contains("returned")
                    ? Color.Firebrick
                    : Color.Black;
                rtbAlerts.AppendText("• " + alert + Environment.NewLine + Environment.NewLine);
            }

            _announcementRows = home.Announcements;
            lstAnnouncements.Items.Clear();

            foreach (DataRow row in home.Announcements.Rows)
            {
                lstAnnouncements.Items.Add($"{Convert.ToDateTime(row["created_at"]):MMM d}  -  {row["title"]}");
            }

            if (lstAnnouncements.Items.Count == 0)
            {
                lstAnnouncements.Items.Add("No announcements.");
            }

            lstNotifications.Items.Clear();

            foreach (DataRow row in home.RecentNotifications.Rows)
            {
                bool unread = Convert.ToInt32(row["is_read"]) == 0;
                lstNotifications.Items.Add((unread ? "● " : "   ") + row["title"]);
            }

            if (lstNotifications.Items.Count == 0)
            {
                lstNotifications.Items.Add("No notifications.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorHandler.Friendly(ex), "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void lstAnnouncements_DoubleClick(object? sender, EventArgs e)
    {
        int index = lstAnnouncements.SelectedIndex;

        if (index < 0 || index >= _announcementRows.Rows.Count)
        {
            return;
        }

        DataRow row = _announcementRows.Rows[index];
        string meta = $"Posted by {row["posted_by"]} on {Convert.ToDateTime(row["created_at"]):MMM d, yyyy}";

        using var dialog = new TextDialog(Convert.ToString(row["title"]) ?? "", meta, Convert.ToString(row["body"]) ?? "");
        dialog.ShowDialog(this);
    }
}
