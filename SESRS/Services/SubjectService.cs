using SESRS.Helpers;
using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class SubjectService
    {
        private readonly DatabaseConnection _database = new();
        private readonly AuditService _audit = new();

        public DataTable GetAllSubjects()
        {
            Session.RequireAdmin();

            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    subject_id,
                    subject_code,
                    subject_name,
                    units,
                    status
                FROM subjects
                ORDER BY subject_code;
                """;

            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public DataTable SearchSubjects(string keyword)
        {
            Session.RequireAdmin();

            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        SELECT
            subject_id,
            subject_code,
            subject_name,
            units,
            status
        FROM subjects
        WHERE
            subject_code LIKE @keyword
            OR subject_name LIKE @keyword
        ORDER BY subject_code;
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@keyword",
                "%" + keyword + "%"
            );

            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public bool AddSubject(
    string subjectCode,
    string subjectName,
    string description,
    int units)
        {
            Session.RequireAdmin();

            Validate.Subject(subjectCode, subjectName, description, units);

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        INSERT INTO subjects
            (subject_code, subject_name, description, units, status)
        VALUES
            (@subjectCode, @subjectName, @description, @units, 'Active');
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@subjectCode",
                subjectCode
            );

            command.Parameters.AddWithValue(
                "@subjectName",
                subjectName
            );

            command.Parameters.AddWithValue(
                "@description",
                string.IsNullOrWhiteSpace(description)
                    ? DBNull.Value
                    : description
            );

            command.Parameters.AddWithValue(
                "@units",
                units
            );

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "SUBJECT_CREATED", "subject", command.LastInsertedId.ToString(), subjectCode);
            }

            return rowsAffected > 0;
        }

        public DataTable GetSubjectById(int subjectId)
        {
            Session.RequireAdmin();

            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        SELECT
            subject_id,
            subject_code,
            subject_name,
            description,
            units,
            status
        FROM subjects
        WHERE subject_id = @subjectId;
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@subjectId",
                subjectId
            );

            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public bool UpdateSubject(
            int subjectId,
            string subjectCode,
            string subjectName,
            string description,
            int units)
        {
            Session.RequireAdmin();

            Validate.Subject(subjectCode, subjectName, description, units);

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        UPDATE subjects
        SET
            subject_code = @subjectCode,
            subject_name = @subjectName,
            description = @description,
            units = @units
        WHERE subject_id = @subjectId;
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@subjectId",
                subjectId
            );

            command.Parameters.AddWithValue(
                "@subjectCode",
                subjectCode
            );

            command.Parameters.AddWithValue(
                "@subjectName",
                subjectName
            );

            command.Parameters.AddWithValue(
                "@description",
                string.IsNullOrWhiteSpace(description)
                    ? DBNull.Value
                    : description
            );

            command.Parameters.AddWithValue(
                "@units",
                units
            );

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "SUBJECT_UPDATED", "subject", subjectId.ToString(), subjectCode);
            }

            return rowsAffected > 0;
        }

        public bool ToggleSubjectStatus(int subjectId)
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
        UPDATE subjects
        SET status =
            CASE
                WHEN status = 'Active' THEN 'Inactive'
                ELSE 'Active'
            END
        WHERE subject_id = @subjectId;
        """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@subjectId",
                subjectId
            );

            int rowsAffected =
                command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "SUBJECT_STATUS_CHANGED", "subject", subjectId.ToString(), null);
            }

            return rowsAffected > 0;
        }

        public int GetTotalSubjects()
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = "SELECT COUNT(*) FROM subjects;";

            using var command = new MySqlCommand(query, connection);

            return Convert.ToInt32(command.ExecuteScalar());
        }


    }
}