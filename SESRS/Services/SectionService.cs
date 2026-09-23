using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class SectionService
    {
        private readonly DatabaseConnection _database = new();

        public DataTable GetAllSections()
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    s.section_id,
                    s.section_code,
                    s.section_name,
                    p.program_code,
                    p.program_name,
                    s.year_level,
                    s.semester,
                    s.school_year,
                    s.capacity,
                    s.status
                FROM sections s
                LEFT JOIN programs p
                    ON s.program_id = p.program_id
                ORDER BY s.section_code;
                """;

            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }
    }
}