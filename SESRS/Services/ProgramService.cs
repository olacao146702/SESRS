using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class ProgramService
    {
        private readonly DatabaseConnection _database = new();

        public DataTable GetAllPrograms()
        {
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

            return rowsAffected > 0;
        }

        public DataTable GetProgramById(int programId)
        {
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

            return rowsAffected > 0;
        }

        public bool ToggleProgramStatus(int programId)
        {
            using var connection = _database.GetConnection();
            connection.Open();

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

            return rowsAffected > 0;
        }
    }
}