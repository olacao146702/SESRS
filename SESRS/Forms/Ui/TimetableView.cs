using SESRS.Models;

namespace SESRS.Forms;

/// <summary>Weekly timetable drawn as colored blocks on a day/hour grid.</summary>
public sealed class TimetableView : Control
{
    private static readonly string[] WeekDays =
        { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    private static readonly Color[] Palette =
    {
        Color.FromArgb(198, 226, 208), Color.FromArgb(200, 220, 240), Color.FromArgb(250, 224, 190),
        Color.FromArgb(232, 208, 236), Color.FromArgb(240, 214, 214), Color.FromArgb(220, 232, 190),
        Color.FromArgb(205, 235, 235), Color.FromArgb(245, 235, 180)
    };

    private List<TimetableEntry> _entries = new();

    public TimetableView()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BackColor = Color.White;
        Font = new Font("Segoe UI", 8.5F);
    }

    public void SetEntries(IEnumerable<TimetableEntry> entries)
    {
        _entries = entries.ToList();
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.Clear(BackColor);

        bool showSunday = _entries.Any(x => x.Day == "Sunday");
        string[] days = showSunday ? WeekDays : WeekDays.Take(6).ToArray();

        int startHour = 7;
        int endHour = 18;

        if (_entries.Count > 0)
        {
            startHour = Math.Min(startHour, (int)_entries.Min(x => x.Start.TotalHours));
            endHour = Math.Max(endHour, (int)Math.Ceiling(_entries.Max(x => x.End.TotalHours)));
        }

        const int gutter = 64;
        const int headerHeight = 32;

        float columnWidth = (Width - gutter - 1) / (float)days.Length;
        float hourHeight = (Height - headerHeight - 1) / (float)(endHour - startHour);

        using var headerBrush = new SolidBrush(UiStyle.Sidebar);
        using var gridPen = new Pen(Color.Gainsboro);
        using var boldFont = new Font(Font, FontStyle.Bold);
        var center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        g.FillRectangle(headerBrush, 0, 0, Width, headerHeight);

        for (int d = 0; d < days.Length; d++)
        {
            g.DrawString(days[d], boldFont, Brushes.White,
                new RectangleF(gutter + d * columnWidth, 0, columnWidth, headerHeight), center);
        }

        for (int h = startHour; h <= endHour; h++)
        {
            float y = headerHeight + (h - startHour) * hourHeight;
            g.DrawLine(gridPen, gutter, y, Width, y);

            if (h < endHour)
            {
                string label = DateTime.Today.AddHours(h).ToString("h tt");
                g.DrawString(label, Font, Brushes.Gray, 8, y + 2);
            }
        }

        for (int d = 0; d <= days.Length; d++)
        {
            float x = gutter + d * columnWidth;
            g.DrawLine(gridPen, x, headerHeight, x, Height);
        }

        var colors = _entries
            .Select(x => x.SubjectCode)
            .Distinct()
            .Select((code, index) => (code, index))
            .ToDictionary(t => t.code, t => Palette[t.index % Palette.Length]);

        foreach (TimetableEntry entry in _entries)
        {
            int dayIndex = Array.IndexOf(days, entry.Day);

            if (dayIndex < 0)
            {
                continue;
            }

            float top = headerHeight + ((float)entry.Start.TotalHours - startHour) * hourHeight;
            float bottom = headerHeight + ((float)entry.End.TotalHours - startHour) * hourHeight;
            var block = new RectangleF(gutter + dayIndex * columnWidth + 2, top + 1, columnWidth - 4, bottom - top - 2);

            using var fill = new SolidBrush(colors[entry.SubjectCode]);
            using var border = new Pen(entry.EnrollmentStatus == "Pending" ? Color.DarkOrange : UiStyle.Brand,
                entry.EnrollmentStatus == "Pending" ? 2f : 1f)
            {
                DashStyle = entry.EnrollmentStatus == "Pending"
                    ? System.Drawing.Drawing2D.DashStyle.Dash
                    : System.Drawing.Drawing2D.DashStyle.Solid
            };

            g.FillRectangle(fill, block);
            g.DrawRectangle(border, block.X, block.Y, block.Width, block.Height);

            string text = entry.SubjectCode + "\n" +
                          (entry.Room.Length > 0 ? entry.Room + "\n" : "") +
                          $"{Academic.FormatTime(entry.Start)}-{Academic.FormatTime(entry.End)}" +
                          (entry.EnrollmentStatus == "Pending" ? "\n(pending)" : "");

            g.DrawString(text, Font, Brushes.Black,
                new RectangleF(block.X + 4, block.Y + 3, block.Width - 8, block.Height - 6));
        }
    }
}
