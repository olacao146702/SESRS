using MySqlConnector;

namespace SESRS.Helpers;

/// <summary>
/// Turns exceptions into messages that are safe to show to users and writes
/// the full details to a log file instead.
/// </summary>
public static class ErrorHandler
{
    public static string Friendly(Exception ex)
    {
        Log(ex);

        return ex switch
        {
            BusinessRuleException => ex.Message,
            UnauthorizedAccessException => ex.Message,
            MySqlException m when m.ErrorCode == MySqlErrorCode.DuplicateKeyEntry =>
                "A record with the same unique value (such as a student number or username) already exists.",
            MySqlException =>
                "The database could not complete the request. Please make sure the database server is running and try again.",
            _ =>
                "An unexpected error occurred. The details were saved to the error log."
        };
    }

    public static void Log(Exception ex)
    {
        try
        {
            string directory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SESRS",
                "logs");

            Directory.CreateDirectory(directory);

            File.AppendAllText(
                Path.Combine(directory, "errors.log"),
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex}{Environment.NewLine}{Environment.NewLine}");
        }
        catch
        {
            // Logging must never crash the application.
        }
    }
}
