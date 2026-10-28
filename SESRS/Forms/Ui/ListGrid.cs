using System.Data;
using SESRS.Helpers;

namespace SESRS.Forms;

/// <summary>
/// Gives a list screen search, column sorting, paging, an empty state, status messages and consistent
/// error handling. The screen's controls live in its designer file; this class only adds behavior.
/// </summary>
public sealed class ListGrid
{
    private const int PageSize = 15;

    private readonly Form _owner;
    private readonly DataGridView _grid;
    private readonly TextBox _search;
    private readonly Label _empty;
    private readonly Label _pageInfo;
    private readonly Button _prev;
    private readonly Button _next;
    private readonly Label _status;
    private readonly Label? _subtitle;
    private readonly System.Windows.Forms.Timer _statusTimer = new() { Interval = 5000 };

    private DataTable _source = new();
    private List<DataRow> _filtered = new();
    private string[] _hidden = Array.Empty<string>();
    private string? _sortColumn;
    private bool _sortAscending = true;
    private int _page;

    public string EmptyMessage { get; set; } = "No records to show.";

    /// <summary>Raised when a row is double-clicked.</summary>
    public event EventHandler? RowActivated;

    public ListGrid(Form owner, DataGridView grid, TextBox search, Label empty, Label pageInfo,
        Button prev, Button next, Label status, Label? subtitle = null)
    {
        _owner = owner;
        _grid = grid;
        _search = search;
        _empty = empty;
        _pageInfo = pageInfo;
        _prev = prev;
        _next = next;
        _status = status;
        _subtitle = subtitle;

        _search.TextChanged += (_, _) => { _page = 0; ApplyView(); };
        _prev.Click += (_, _) => { _page--; ApplyView(); };
        _next.Click += (_, _) => { _page++; ApplyView(); };
        _grid.CellFormatting += Grid_CellFormatting;
        _grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
        _grid.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0)
            {
                RowActivated?.Invoke(this, EventArgs.Empty);
            }
        };
        _statusTimer.Tick += (_, _) => { _status.Text = ""; _statusTimer.Stop(); };
    }

    public void SetSubtitle(string text)
    {
        if (_subtitle != null)
        {
            _subtitle.Text = text;
        }
    }

    public void SetData(DataTable table, params string[] hiddenColumns)
    {
        _source = table;
        _hidden = hiddenColumns;
        _page = 0;
        ApplyView();
    }

    // ------------------------------------------------------------ selection

    public DataRow? SelectedRow()
    {
        return _grid.CurrentRow?.DataBoundItem is DataRowView view ? view.Row : null;
    }

    public DataRow? RequireRow(string what = "record")
    {
        DataRow? row = SelectedRow();

        if (row == null)
        {
            MessageBox.Show($"Please select a {what} first.", "Select a row",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return row;
    }

    public int? SelectedId(string column)
    {
        DataRow? row = SelectedRow();
        return row == null ? null : Convert.ToInt32(row[column]);
    }

    // ------------------------------------------------------------ feedback

    /// <summary>Runs an action with a busy cursor and friendly error reporting.</summary>
    public void Run(Action action)
    {
        try
        {
            _owner.UseWaitCursor = true;
            action();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
        finally
        {
            _owner.UseWaitCursor = false;
        }
    }

    public void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorHandler.Friendly(ex), "SESRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public bool Confirm(string message, string title = "Please confirm")
    {
        return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
    }

    public void Success(string message)
    {
        _status.ForeColor = UiStyle.Brand;
        _status.Text = "✔ " + message;
        _statusTimer.Stop();
        _statusTimer.Start();
    }

    // ------------------------------------------------------------ export / print

    public void ExportCsv(string fileName)
    {
        if (_filtered.Count == 0)
        {
            MessageBox.Show("There is nothing to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "CSV file (*.csv)|*.csv",
            FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
        };

        if (dialog.ShowDialog(_owner) != DialogResult.OK)
        {
            return;
        }

        CsvExport.Write(dialog.FileName, FilteredTable(), _hidden);
        Success("Exported " + _filtered.Count + " records.");
    }

    public void Print(string title, bool landscape = true)
    {
        if (_filtered.Count == 0)
        {
            MessageBox.Show("There is nothing to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        PrintReport.Preview(_owner,
            ReportDocument.FromTable(title, _subtitle?.Text, FilteredTable(), landscape, _hidden));
    }

    private DataTable FilteredTable()
    {
        DataTable all = _source.Clone();

        foreach (DataRow row in _filtered)
        {
            all.ImportRow(row);
        }

        return all;
    }

    // ------------------------------------------------------------ filtering, sorting, paging

    private void ApplyView()
    {
        string text = _search.Text.Trim();

        IEnumerable<DataRow> rows = _source.Rows.Cast<DataRow>();

        if (text.Length > 0)
        {
            var visible = _source.Columns.Cast<DataColumn>().Where(c => !_hidden.Contains(c.ColumnName)).ToList();

            rows = rows.Where(r => visible.Any(c =>
                CsvExport.Format(r[c]).Contains(text, StringComparison.OrdinalIgnoreCase)));
        }

        if (_sortColumn != null && _source.Columns.Contains(_sortColumn))
        {
            rows = _sortAscending
                ? rows.OrderBy(r => SortKey(r[_sortColumn]), Comparer<object>.Create(CompareKeys))
                : rows.OrderByDescending(r => SortKey(r[_sortColumn]), Comparer<object>.Create(CompareKeys));
        }

        _filtered = rows.ToList();

        int pages = Math.Max(1, (int)Math.Ceiling(_filtered.Count / (double)PageSize));
        _page = Math.Min(Math.Max(0, _page), pages - 1);

        DataTable view = _source.Clone();

        foreach (DataRow row in _filtered.Skip(_page * PageSize).Take(PageSize))
        {
            view.ImportRow(row);
        }

        _grid.DataSource = view;

        foreach (DataGridViewColumn column in _grid.Columns)
        {
            column.HeaderText = CsvExport.Humanize(column.Name);
            column.Visible = !_hidden.Contains(column.Name);
            column.SortMode = DataGridViewColumnSortMode.Programmatic;

            column.HeaderCell.SortGlyphDirection = column.Name == _sortColumn
                ? (_sortAscending ? SortOrder.Ascending : SortOrder.Descending)
                : SortOrder.None;
        }

        bool hasRows = _filtered.Count > 0;

        _empty.Text = text.Length > 0 ? "No records match your search." : EmptyMessage;
        _empty.Visible = !hasRows;

        _prev.Enabled = _page > 0;
        _next.Enabled = _page < pages - 1;
        _pageInfo.Text = hasRows
            ? $"Page {_page + 1} of {pages}  ({_filtered.Count} records)"
            : "0 records";
    }

    private static object SortKey(object value) => value is DBNull ? "" : value;

    private static int CompareKeys(object? a, object? b)
    {
        if (a is IComparable ca && b != null && a.GetType() == b.GetType())
        {
            return ca.CompareTo(b);
        }

        return string.Compare(CsvExport.Format(a), CsvExport.Format(b), StringComparison.OrdinalIgnoreCase);
    }

    private void Grid_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
    {
        string name = _grid.Columns[e.ColumnIndex].Name;

        if (_sortColumn == name)
        {
            _sortAscending = !_sortAscending;
        }
        else
        {
            _sortColumn = name;
            _sortAscending = true;
        }

        ApplyView();
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value is TimeSpan time)
        {
            e.Value = SESRS.Models.Academic.FormatTime(time);
            e.FormattingApplied = true;
        }
        else if (e.Value is DateTime date)
        {
            e.Value = date.TimeOfDay == TimeSpan.Zero
                ? date.ToString("MMM d, yyyy")
                : date.ToString("MMM d, yyyy h:mm tt");
            e.FormattingApplied = true;
        }
        else if (e.Value is string status && _grid.Columns[e.ColumnIndex].Name == "status")
        {
            e.CellStyle.ForeColor = status switch
            {
                "Approved" or "Active" or "Completed" or "Enrolled" or "Passed" or "Published" => Color.DarkGreen,
                "Pending" or "Pending approval" or "Draft" => Color.DarkOrange,
                "Rejected" or "Cancelled" or "Inactive" or "Failed - retake" or "Failed"
                    or "Prerequisite needed" => Color.Firebrick,
                "Returned" => Color.SteelBlue,
                "Withdrawn" or "Expired" => Color.Gray,
                _ => e.CellStyle.ForeColor
            };

            e.CellStyle.Font = UiStyle.Bold;
        }
    }
}
