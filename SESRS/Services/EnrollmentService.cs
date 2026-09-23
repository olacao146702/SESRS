using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class EnrollmentService
    {
        private readonly DatabaseConnection _database = new();

        public DataTable GetAllEnrollments()
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    e.enrollment_id,
                    s.student_number,
                    CONCAT(
                        s.first_name, ' ',
                        IFNULL(s.middle_name, ''), ' ',
                        s.last_name
                    ) AS student_name,
                    e.school_year,
                    e.semester,
                    e.enrollment_date,
                    e.status
                FROM enrollments e
                INNER JOIN students s
                    ON e.student_id = s.student_id
                ORDER BY e.enrollment_date DESC;
                """;

            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }
    }
}