
using System.Data;
using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>The student's weekly class timetable for the current term.</summary>
public partial class MyScheduleForm : Form
{
    private readonly int _studentId;
    private readonly StudentPortalService _portal = new();
    private readonly PeriodService _periods = new();
    private List<TimetableEntry> _entries = new();

    public MyScheduleForm(int studentId)
    {
        InitializeComponent();
        _studentId = studentId;
    }

    private void Safe(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ErrorHandler.Friendly(ex),
                "Schedule",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void MyScheduleForm_Load(object? sender, EventArgs e)
        => Safe(LoadPage);

    private void btnPrint_Click(object? sender, EventArgs e)
        => Safe(Print);

    private void LoadPage()
    {
        _entries = _portal.GetTimetable(_studentId);
        AcademicPeriod? period = _periods.GetCurrent();

        // Keep individual weekday entries for the visual calendar.
        timetable.SetEntries(_entries);

        // Group matching weekdays only for the table.
        List<ScheduleDisplayRow> groupedEntries = GetGroupedEntries();

        var table = new DataTable();

        foreach (string column in new[]
        {
            "day", "time", "subject_code", "subject_name",
            "section_code", "room", "instructor", "status"
        })
        {
            table.Columns.Add(column);
        }

        foreach (ScheduleDisplayRow entry in groupedEntries)
        {
            table.Rows.Add(
                entry.Day,
                $"{Academic.FormatTime(entry.Start)} - {Academic.FormatTime(entry.End)}",
                entry.SubjectCode,
                entry.SubjectName,
                entry.SectionCode,
                entry.Room,
                entry.Instructor,
                entry.EnrollmentStatus);
        }

        dgvSchedule.DataSource = table;

        foreach (DataGridViewColumn column in dgvSchedule.Columns)
        {
            column.HeaderText = CsvExport.Humanize(column.Name);
        }

        string term = period?.Label ?? "No current term";

        if (_entries.Count == 0)
        {
            lblStatus.ForeColor = UiStyle.Muted;
            lblStatus.Text =
                $"{term}\nYou have no enrolled subjects yet. Open Enrollment to choose your subjects.";
        }
        else if (_entries.All(x => x.EnrollmentStatus == "Approved"))
        {
            lblStatus.ForeColor = UiStyle.Brand;
            lblStatus.Text = $"{term}\nApproved schedule.";
        }
        else
        {
            lblStatus.ForeColor = Color.DarkOrange;
            lblStatus.Text =
                $"{term}\nPending approval. Dashed blocks are not final until the registrar approves your enrollment.";
        }

        btnPrint.Enabled = _entries.Count > 0;
    }

    private List<ScheduleDisplayRow> GetGroupedEntries()
    {
        return _entries
            .GroupBy(e => new
            {
                e.SubjectCode,
                e.SubjectName,
                e.SectionCode,
                e.Start,
                e.End,
                e.Room,
                e.Instructor,
                e.EnrollmentStatus
            })
            .Select(group =>
            {
                var days = group
                    .Select(e => e.Day)
                    .Distinct()
                    .OrderBy(day => Array.IndexOf(Academic.Days, day))
                    .ToList();

                return new ScheduleDisplayRow(
                    FormatDays(days),
                    group.Key.Start,
                    group.Key.End,
                    group.Key.SubjectCode,
                    group.Key.SubjectName,
                    group.Key.SectionCode,
                    group.Key.Room,
                    group.Key.Instructor,
                    group.Key.EnrollmentStatus,
                    days.Min(day => Array.IndexOf(Academic.Days, day)));
            })
            .OrderBy(e => e.DayOrder)
            .ThenBy(e => e.Start)
            .ToList();
    }

    private static string FormatDays(List<string> days)
    {
        if (days.SequenceEqual(new[]
            { "Monday", "Wednesday", "Friday" }))
            return "MWF";

        if (days.SequenceEqual(new[]
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" }))
            return "Monday-Friday";

        if (days.SequenceEqual(new[]
            { "Monday", "Tuesday", "Wednesday" }))
            return "MSAT1";

        if (days.SequenceEqual(new[]
            { "Thursday", "Friday", "Saturday" }))
            return "MSAT2";

        return string.Join("", days.Select(day => day switch
        {
            "Monday" => "M",
            "Tuesday" => "T",
            "Wednesday" => "W",
            "Thursday" => "TH",
            "Friday" => "F",
            "Saturday" => "SAT",
            "Sunday" => "SUN",
            _ => day
        }));
    }

    private void Print()
    {
        StudentProfile profile = _portal.GetProfile(_studentId);
        AcademicPeriod? period = _periods.GetCurrent();

        var document = new ReportDocument
        {
            Title = "Class Schedule",
            Subtitle = period?.Label,
            Landscape = true
        };

        document.Header.Add(("Student No.", profile.StudentNumber));
        document.Header.Add(("Name", profile.FullName));
        document.Header.Add(("Program", profile.ProgramCode));
        document.Header.Add(("Year level", Academic.YearLabel(profile.YearLevel)));

        document.AddColumn("Day", 1f);
        document.AddColumn("Time", 1.6f);
        document.AddColumn("Code", 0.9f);
        document.AddColumn("Subject", 2.4f);
        document.AddColumn("Section", 0.9f);
        document.AddColumn("Room", 0.9f);
        document.AddColumn("Instructor", 1.5f);

        // Print the same grouped rows shown in the table.
        foreach (ScheduleDisplayRow e in GetGroupedEntries())
        {
            document.Rows.Add(new[]
            {
                e.Day,
                $"{Academic.FormatTime(e.Start)} - {Academic.FormatTime(e.End)}",
                e.SubjectCode,
                e.SubjectName,
                e.SectionCode,
                e.Room,
                e.Instructor
            });
        }

        if (_entries.Any(x => x.EnrollmentStatus == "Pending"))
        {
            document.Footer.Add(
                "Not final: this schedule is pending approval.");
        }

        PrintReport.Preview(this, document);
    }

    private sealed record ScheduleDisplayRow(
        string Day,
        TimeSpan Start,
        TimeSpan End,
        string SubjectCode,
        string SubjectName,
        string SectionCode,
        string Room,
        string Instructor,
        string EnrollmentStatus,
        int DayOrder);
}
