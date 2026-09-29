using System;
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

        public DataTable GetActiveStudents()
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    student_id,
                    student_number,
                    CONCAT(
                        first_name, ' ',
                        IFNULL(middle_name, ''), ' ',
                        last_name
                    ) AS student_name
                FROM students
                WHERE status = 'Active'
                ORDER BY last_name, first_name;
                """;

            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public bool CreateEnrollment(
            int studentId,
            string schoolYear,
            string semester)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            string checkQuery = """
                SELECT COUNT(*)
                FROM enrollments
                WHERE student_id = @student_id
                AND school_year = @school_year
                AND semester = @semester
                AND status <> 'Cancelled';
                """;

            using var checkCommand = new MySqlCommand(
                checkQuery,
                connection
            );

            checkCommand.Parameters.AddWithValue(
                "@student_id",
                studentId
            );

            checkCommand.Parameters.AddWithValue(
                "@school_year",
                schoolYear
            );

            checkCommand.Parameters.AddWithValue(
                "@semester",
                semester
            );

            int existingEnrollment =
                Convert.ToInt32(checkCommand.ExecuteScalar());

            if (existingEnrollment > 0)
            {
                return false;
            }

            string insertQuery = """
                INSERT INTO enrollments
                    (student_id, school_year, semester, status)
                VALUES
                    (@student_id, @school_year, @semester, 'Pending');
                """;

            using var insertCommand = new MySqlCommand(
                insertQuery,
                connection
            );

            insertCommand.Parameters.AddWithValue(
                "@student_id",
                studentId
            );

            insertCommand.Parameters.AddWithValue(
                "@school_year",
                schoolYear
            );

            insertCommand.Parameters.AddWithValue(
                "@semester",
                semester
            );

            insertCommand.ExecuteNonQuery();

            return true;
        }

        public bool CancelEnrollment(int enrollmentId)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                UPDATE enrollments
                SET status = 'Cancelled'
                WHERE enrollment_id = @enrollment_id;
                """;

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@enrollment_id",
                enrollmentId
            );

            return command.ExecuteNonQuery() > 0;
        }
    }
}