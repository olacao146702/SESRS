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

            using var command =
                new MySqlCommand(query, connection);

            using var adapter =
                new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public DataTable SearchSections(string keyword)
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
                WHERE
                    s.section_code LIKE @keyword
                    OR s.section_name LIKE @keyword
                    OR p.program_code LIKE @keyword
                    OR p.program_name LIKE @keyword
                ORDER BY s.section_code;
                """;

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@keyword",
                "%" + keyword + "%"
            );

            using var adapter =
                new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public DataTable GetActivePrograms()
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    program_id,
                    program_code,
                    program_name
                FROM programs
                WHERE status = 'Active'
                ORDER BY program_code;
                """;

            using var command =
                new MySqlCommand(query, connection);

            using var adapter =
                new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public bool AddSection(
            string sectionCode,
            string sectionName,
            int programId,
            int yearLevel,
            string semester,
            string schoolYear,
            int capacity)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                INSERT INTO sections
                    (
                        section_code,
                        section_name,
                        program_id,
                        year_level,
                        semester,
                        school_year,
                        capacity,
                        status
                    )
                VALUES
                    (
                        @sectionCode,
                        @sectionName,
                        @programId,
                        @yearLevel,
                        @semester,
                        @schoolYear,
                        @capacity,
                        'Active'
                    );
                """;

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@sectionCode",
                sectionCode
            );

            command.Parameters.AddWithValue(
                "@sectionName",
                sectionName
            );

            command.Parameters.AddWithValue(
                "@programId",
                programId
            );

            command.Parameters.AddWithValue(
                "@yearLevel",
                yearLevel
            );

            command.Parameters.AddWithValue(
                "@semester",
                semester
            );

            command.Parameters.AddWithValue(
                "@schoolYear",
                schoolYear
            );

            command.Parameters.AddWithValue(
                "@capacity",
                capacity
            );

            int rowsAffected =
                command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public DataTable GetSectionById(int sectionId)
        {
            DataTable table = new DataTable();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                SELECT
                    section_id,
                    section_code,
                    section_name,
                    program_id,
                    year_level,
                    semester,
                    school_year,
                    capacity,
                    status
                FROM sections
                WHERE section_id = @sectionId;
                """;

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@sectionId",
                sectionId
            );

            using var adapter =
                new MySqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public bool UpdateSection(
            int sectionId,
            string sectionCode,
            string sectionName,
            int programId,
            int yearLevel,
            string semester,
            string schoolYear,
            int capacity)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                UPDATE sections
                SET
                    section_code = @sectionCode,
                    section_name = @sectionName,
                    program_id = @programId,
                    year_level = @yearLevel,
                    semester = @semester,
                    school_year = @schoolYear,
                    capacity = @capacity
                WHERE section_id = @sectionId;
                """;

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@sectionId",
                sectionId
            );

            command.Parameters.AddWithValue(
                "@sectionCode",
                sectionCode
            );

            command.Parameters.AddWithValue(
                "@sectionName",
                sectionName
            );

            command.Parameters.AddWithValue(
                "@programId",
                programId
            );

            command.Parameters.AddWithValue(
                "@yearLevel",
                yearLevel
            );

            command.Parameters.AddWithValue(
                "@semester",
                semester
            );

            command.Parameters.AddWithValue(
                "@schoolYear",
                schoolYear
            );

            command.Parameters.AddWithValue(
                "@capacity",
                capacity
            );

            int rowsAffected =
                command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public bool ToggleSectionStatus(int sectionId)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            string query = """
                UPDATE sections
                SET status =
                    CASE
                        WHEN status = 'Active'
                            THEN 'Inactive'
                        ELSE 'Active'
                    END
                WHERE section_id = @sectionId;
                """;

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@sectionId",
                sectionId
            );

            int rowsAffected =
                command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public int GetTotalSections()
        {
            using var connection = _database.GetConnection();
            connection.Open();

            string query = "SELECT COUNT(*) FROM sections;";

            using var command = new MySqlCommand(query, connection);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}