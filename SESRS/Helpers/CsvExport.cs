using System.Data;
using System.Text;

namespace SESRS.Helpers;

public static class CsvExport
{
    /// <summary>Writes the visible columns of a table to a UTF-8 CSV (Excel opens it directly).</summary>
    public static void Write(string path, DataTable table, IEnumerable<string>? hiddenColumns = null)
    {
        var hidden = new HashSet<string>(hiddenColumns ?? Array.Empty<string>());

        var columns = table.Columns.Cast<DataColumn>()
            .Where(c => !hidden.Contains(c.ColumnName))
            .ToList();

        var builder = new StringBuilder();

        builder.AppendLine(string.Join(",", columns.Select(c => Escape(Humanize(c.ColumnName)))));

        foreach (DataRow row in table.Rows)
        {
            builder.AppendLine(string.Join(",", columns.Select(c => Escape(Format(row[c])))));
        }

        File.WriteAllText(path, builder.ToString(), new UTF8Encoding(true));
    }

    public static string Humanize(string columnName)
    {
        string[] words = columnName.Split('_', StringSplitOptions.RemoveEmptyEntries);

        return string.Join(" ", words.Select(w =>
            w.Length == 0 ? w : char.ToUpper(w[0]) + w[1..]));
    }

    public static string Format(object? value)
    {
        return value switch
        {
            null or DBNull => "",
            TimeSpan t => SESRS.Models.Academic.FormatTime(t),
            DateTime d => d.TimeOfDay == TimeSpan.Zero
                ? d.ToString("yyyy-MM-dd")
                : d.ToString("yyyy-MM-dd HH:mm"),
            bool b => b ? "Yes" : "No",
            _ => Convert.ToString(value) ?? ""
        };
    }

    private static string Escape(string value)
    {
        // Guard against spreadsheet formula injection from user-entered text.
        if (value.Length > 0 && "=+-@".Contains(value[0]) && !double.TryParse(value, out _))
        {
            value = "'" + value;
        }

        if (value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r'))
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        return value;
    }
}
