using System.Data;
using SESRS.Helpers;

namespace SESRS.Forms;

/// <summary>Read-only viewer for a table (class lists, enrollment details, histories) with CSV export.</summary>
public partial class TableDialog : Form
{
    private readonly DataTable _table;
    private readonly string[] _hidden;
    private readonly string _fileName;

    public TableDialog(string title, string? summary, DataTable table, string fileName, params string[] hiddenColumns)
    {
        InitializeComponent();

        _table = table;
        _hidden = hiddenColumns;
        _fileName = fileName;

        Text = title;
        lblSummary.Text = summary ?? title;
        dgv.DataSource = table;
        lblEmpty.Text = "No records to show.";
        lblEmpty.Visible = table.Rows.Count == 0;

        dgv.DataBindingComplete += (_, _) =>
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.HeaderText = CsvExport.Humanize(column.Name);
                column.Visible = !_hidden.Contains(column.Name);
            }
        };
    }

    private void btnExport_Click(object? sender, EventArgs e)
    {
        if (_table.Rows.Count == 0)
        {
            MessageBox.Show("There is nothing to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "CSV file (*.csv)|*.csv",
            FileName = _fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            CsvExport.Write(dialog.FileName, _table, _hidden);
            MessageBox.Show("Exported to " + dialog.FileName, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorHandler.Friendly(ex), "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
