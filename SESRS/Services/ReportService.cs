using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class ReportService
    {
        private readonly DatabaseConnection _database = new();

        public DataTable GetStudentReport()
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    s.student_number,
                    CONCAT(
                        s.first_name, ' ',
                        IFNULL(s.middle_name, ''), ' ',
                        s.last_name
                    ) AS student_name,
                    p.program_code,
                    s.year_level,
                    s.gender,
                    s.status
                FROM students s
                LEFT JOIN programs p
                    ON s.program_id = p.program_id
                ORDER BY s.student_number;
                """;

            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public DataTable GetEnrollmentReport()
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
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

        public DataTable GetProgramReport()
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    p.program_code,
                    p.program_name,
                    p.duration_years,
                    COUNT(s.student_id) AS student_count,
                    p.status
                FROM programs p
                LEFT JOIN students s
                    ON p.program_id = s.program_id
                GROUP BY
                    p.program_id,
                    p.program_code,
                    p.program_name,
                    p.duration_years,
                    p.status
                ORDER BY p.program_code;
                """;

            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }
    }
}