using System.Data;
using System.Drawing.Printing;

namespace SESRS.Helpers;

/// <summary>A simple printable document: title, header facts, a table, and footer notes.</summary>
public sealed class ReportDocument
{
    public string Title { get; init; } = "";
    public string? Subtitle { get; init; }
    public bool Landscape { get; init; }

    public List<(string Label, string Value)> Header { get; } = new();
    public List<string> Columns { get; } = new();
    public List<float> Weights { get; } = new();
    public List<string[]> Rows { get; } = new();
    public List<string> Footer { get; } = new();

    public void AddColumn(string title, float weight = 1f)
    {
        Columns.Add(title);
        Weights.Add(weight);
    }

    /// <summary>Builds a document from a DataTable, skipping hidden columns.</summary>
    public static ReportDocument FromTable(
        string title, string? subtitle, DataTable table, bool landscape, params string[] hiddenColumns)
    {
        var document = new ReportDocument { Title = title, Subtitle = subtitle, Landscape = landscape };

        var visible = table.Columns.Cast<DataColumn>()
            .Where(c => !hiddenColumns.Contains(c.ColumnName))
            .ToList();

        foreach (DataColumn column in visible)
        {
            document.AddColumn(CsvExport.Humanize(column.ColumnName));
        }

        foreach (DataRow row in table.Rows)
        {
            document.Rows.Add(visible.Select(c => CsvExport.Format(row[c])).ToArray());
        }

        return document;
    }
}

public static class PrintReport
{
    /// <summary>Shows a print preview (which has its own Print button).</summary>
    public static void Preview(IWin32Window owner, ReportDocument document)
    {
        using var printDocument = new PrintDocument();
        printDocument.DefaultPageSettings.Landscape = document.Landscape;
        printDocument.DocumentName = document.Title;

        var printer = new Printer(document);
        printDocument.BeginPrint += (_, _) => printer.Reset();
        printDocument.PrintPage += printer.PrintPage;

        using var dialog = new PrintPreviewDialog
        {
            Document = printDocument,
            Width = 1000,
            Height = 800,
            StartPosition = FormStartPosition.CenterParent
        };

        dialog.ShowDialog(owner);
    }

    private sealed class Printer
    {
        private readonly ReportDocument _document;
        private int _row;
        private int _page;

        public Printer(ReportDocument document)
        {
            _document = document;
        }

        public void Reset()
        {
            _row = 0;
            _page = 0;
        }

        public void PrintPage(object? sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;
            Rectangle area = e.MarginBounds;
            float y = area.Top;

            using var small = new Font("Segoe UI", 8F);
            using var normal = new Font("Segoe UI", 9.5F);
            using var bold = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            using var title = new Font("Segoe UI", 16F, FontStyle.Bold);
            using var subtitle = new Font("Segoe UI", 10F);
            using var green = new SolidBrush(Color.DarkGreen);
            using var headerFill = new SolidBrush(Color.FromArgb(24, 82, 58));
            using var stripe = new SolidBrush(Color.FromArgb(244, 248, 245));
            using var grid = new Pen(Color.Silver);

            var wrap = new StringFormat { Trimming = StringTrimming.Word };

            if (_page == 0)
            {
                g.DrawString("SESRS - Student Enrollment and Records System", small, Brushes.Gray, area.Left, y);
                y += 18;
                g.DrawString(_document.Title, title, green, area.Left, y);
                y += 34;

                if (!string.IsNullOrWhiteSpace(_document.Subtitle))
                {
                    g.DrawString(_document.Subtitle, subtitle, Brushes.Black, area.Left, y);
                    y += 24;
                }

                // Header facts in two columns.
                float half = area.Width / 2f;

                for (int i = 0; i < _document.Header.Count; i += 2)
                {
                    for (int side = 0; side < 2 && i + side < _document.Header.Count; side++)
                    {
                        var (label, value) = _document.Header[i + side];
                        float x = area.Left + side * half;

                        g.DrawString(label + ":", bold, Brushes.Black, x, y);
                        g.DrawString(value, normal, Brushes.Black,
                            new RectangleF(x + 110, y, half - 115, 20), wrap);
                    }

                    y += 22;
                }

                y += 8;
            }
            else
            {
                g.DrawString(_document.Title + " (continued)", small, Brushes.Gray, area.Left, y);
                y += 22;
            }

            // ---- table ----
            float totalWeight = _document.Weights.Sum();
            var widths = _document.Weights.Select(w => area.Width * w / totalWeight).ToArray();

            if (_document.Columns.Count > 0)
            {
                float headerHeight = 26;
                g.FillRectangle(headerFill, area.Left, y, area.Width, headerHeight);

                float x = area.Left;

                for (int c = 0; c < _document.Columns.Count; c++)
                {
                    g.DrawString(_document.Columns[c], bold, Brushes.White,
                        new RectangleF(x + 3, y + 5, widths[c] - 6, headerHeight), wrap);
                    x += widths[c];
                }

                y += headerHeight;

                float footerSpace = 24 + _document.Footer.Count * 20;

                while (_row < _document.Rows.Count)
                {
                    string[] cells = _document.Rows[_row];
                    float rowHeight = 22;

                    for (int c = 0; c < cells.Length && c < widths.Length; c++)
                    {
                        float needed = g.MeasureString(cells[c], normal, (int)(widths[c] - 6), wrap).Height + 6;
                        rowHeight = Math.Max(rowHeight, needed);
                    }

                    bool lastRow = _row == _document.Rows.Count - 1;
                    float reserve = lastRow ? footerSpace : 0;

                    if (y + rowHeight + reserve > area.Bottom - 20)
                    {
                        _page++;
                        e.HasMorePages = true;
                        DrawPageNumber(g, small, area);
                        return;
                    }

                    if (_row % 2 == 1)
                    {
                        g.FillRectangle(stripe, area.Left, y, area.Width, rowHeight);
                    }

                    x = area.Left;

                    for (int c = 0; c < cells.Length && c < widths.Length; c++)
                    {
                        g.DrawString(cells[c], normal, Brushes.Black,
                            new RectangleF(x + 3, y + 3, widths[c] - 6, rowHeight), wrap);
                        x += widths[c];
                    }

                    g.DrawLine(grid, area.Left, y + rowHeight, area.Right, y + rowHeight);
                    y += rowHeight;
                    _row++;
                }

                if (_document.Rows.Count == 0)
                {
                    g.DrawString("No records.", normal, Brushes.Gray, area.Left + 4, y + 4);
                    y += 26;
                }
            }

            y += 14;

            foreach (string line in _document.Footer)
            {
                g.DrawString(line, bold, Brushes.Black, new RectangleF(area.Left, y, area.Width, 40), wrap);
                y += 20;
            }

            DrawPageNumber(g, small, area);
            e.HasMorePages = false;
        }

        private void DrawPageNumber(Graphics g, Font font, Rectangle area)
        {
            string text = $"Printed {DateTime.Now:MMM d, yyyy h:mm tt}   |   Page {_page + 1}";
            g.DrawString(text, font, Brushes.Gray, area.Left, area.Bottom);
        }
    }
}
