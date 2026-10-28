using SESRS.Helpers;
using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class ProgramService
    {
        private readonly DatabaseConnection _database = new();
        private readonly AuditService _audit = new();

        public DataTable GetAllPrograms()
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    program_id,
                    program_code,
                    program_name,
                    duration_years,
                    status
                FROM programs
                ORDER BY program_code;
                """;

            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);

            DataTable table = new();
            adapter.Fill(table);

            return table;
        }

        public DataTable SearchPrograms(string keyword)
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        SELECT
            program_id,
            program_code,
            program_name,
            duration_years,
            status
        FROM programs
        WHERE
            program_code LIKE @keyword
            OR program_name LIKE @keyword
        ORDER BY program_code;
        """;

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@keyword",
                "%" + keyword + "%"
            );

            using var adapter =
                new MySqlDataAdapter(command);

            DataTable table = new();
            adapter.Fill(table);

            return table;
        }

        public bool AddProgram(
    string programCode,
    string programName,
    int durationYears)
        {
            Session.RequireAdmin();

            Validate.Program(programCode, programName, durationYears);

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        INSERT INTO programs
            (program_code, program_name, duration_years, status)
        VALUES
            (@programCode, @programName, @durationYears, 'Active');
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@programCode",
                programCode
            );

            command.Parameters.AddWithValue(
                "@programName",
                programName
            );

            command.Parameters.AddWithValue(
                "@durationYears",
                durationYears
            );

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "PROGRAM_CREATED", "program", command.LastInsertedId.ToString(), programCode);
            }

            return rowsAffected > 0;
        }

        public DataTable GetProgramById(int programId)
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        SELECT
            program_id,
            program_code,
            program_name,
            duration_years,
            status
        FROM programs
        WHERE program_id = @programId;
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@programId",
                programId
            );

            using var adapter = new MySqlDataAdapter(command);

            DataTable table = new();
            adapter.Fill(table);

            return table;
        }

        public bool UpdateProgram(
            int programId,
            string programCode,
            string programName,
            int durationYears)
        {
            Session.RequireAdmin();

            Validate.Program(programCode, programName, durationYears);

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        UPDATE programs
        SET
            program_code = @programCode,
            program_name = @programName,
            duration_years = @durationYears
        WHERE program_id = @programId;
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@programId",
                programId
            );

            command.Parameters.AddWithValue(
                "@programCode",
                programCode
            );

            command.Parameters.AddWithValue(
                "@programName",
                programName
            );

            command.Parameters.AddWithValue(
                "@durationYears",
                durationYears
            );

            int rowsAffected =
                command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "PROGRAM_UPDATED", "program", programId.ToString(), programCode);
            }

            return rowsAffected > 0;
        }

        public bool ToggleProgramStatus(int programId)
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            if (Sql.Int(connection, null,
                    "SELECT COUNT(*) FROM programs WHERE program_id = @id AND status = 'Active';",
                    ("@id", programId)) > 0 &&
                Sql.Int(connection, null,
                    "SELECT COUNT(*) FROM students WHERE program_id = @id AND status = 'Active';",
                    ("@id", programId)) > 0)
            {
                throw new BusinessRuleException(
                    "This program still has active students. Move or deactivate them before deactivating the program.");
            }

            string query = """
        UPDATE programs
        SET status =
            CASE
                WHEN status = 'Active' THEN 'Inactive'
                ELSE 'Active'
            END
        WHERE program_id = @programId;
        """;

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@programId",
                programId
            );

            int rowsAffected =
                command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "PROGRAM_STATUS_CHANGED", "program", programId.ToString(), null);
            }

            return rowsAffected > 0;
        }
    }
}