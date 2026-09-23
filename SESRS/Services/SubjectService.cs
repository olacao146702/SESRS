using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class SubjectService
    {
        private readonly DatabaseConnection _database = new();

        public DataTable GetAllSubjects()
        {
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
    }
}