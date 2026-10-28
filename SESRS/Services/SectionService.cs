using SESRS.Helpers;
using System.Data;
using MySqlConnector;
using SESRS.Data;

namespace SESRS.Services
{
    public class SectionService
    {
        private readonly DatabaseConnection _database = new();
        private readonly AuditService _audit = new();

        public DataTable GetAllSections()
        {
            Session.RequireAdmin();

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
            Session.RequireAdmin();

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
            Session.RequireAdmin();

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
            Session.RequireAdmin();

            Validate.Section(sectionCode, sectionName, programId, yearLevel, semester, schoolYear, capacity);

            using var connection = _database.GetConnection();
            connection.Open();

            EnsureSectionRules(connection, 0, sectionCode, programId, semester, schoolYear, capacity);

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

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "SECTION_CREATED", "section", command.LastInsertedId.ToString(), sectionCode);
            }

            return rowsAffected > 0;
        }

        public DataTable GetSectionById(int sectionId)
        {
            Session.RequireAdmin();

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
            Session.RequireAdmin();

            Validate.Section(sectionCode, sectionName, programId, yearLevel, semester, schoolYear, capacity);

            using var connection = _database.GetConnection();
            connection.Open();

            EnsureSectionRules(connection, sectionId, sectionCode, programId, semester, schoolYear, capacity);

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

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "SECTION_UPDATED", "section", sectionId.ToString(), sectionCode);
            }

            return rowsAffected > 0;
        }

        public bool ToggleSectionStatus(int sectionId)
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            if (Sql.Int(connection, null,
                    "SELECT COUNT(*) FROM sections WHERE section_id = @id AND status = 'Active';",
                    ("@id", sectionId)) > 0 &&
                Sql.Int(connection, null, """
                    SELECT COUNT(*) FROM enrollment_details d
                    JOIN enrollments e ON e.enrollment_id = d.enrollment_id
                    WHERE d.section_id = @id AND e.status IN ('Pending', 'Approved');
                    """, ("@id", sectionId)) > 0)
            {
                throw new BusinessRuleException(
                    "Students are enrolled in this section. Cancel or move their enrollments before deactivating it.");
            }

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

            if (rowsAffected > 0)
            {
                _audit.Log(connection, null, "SECTION_STATUS_CHANGED", "section", sectionId.ToString(), null);
            }

            return rowsAffected > 0;
        }

        public int GetTotalSections()
        {
            Session.RequireAdmin();

            using var connection = _database.GetConnection();
            connection.Open();

            string query = "SELECT COUNT(*) FROM sections;";

            using var command = new MySqlCommand(query, connection);

            return Convert.ToInt32(command.ExecuteScalar());
        }
            private static void EnsureSectionRules(
            MySqlConnection connection,
            int sectionId,
            string sectionCode,
            int programId,
            string semester,
            string schoolYear,
            int capacity)
        {
            if (Sql.Int(connection, null, """
                    SELECT COUNT(*) FROM sections
                    WHERE section_code = @c AND school_year = @sy AND semester = @sem AND section_id <> @id;
                    """, ("@c", sectionCode), ("@sy", schoolYear), ("@sem", semester), ("@id", sectionId)) > 0)
            {
                throw new BusinessRuleException(
                    $"Section {sectionCode} already exists for {schoolYear}, {semester}.");
            }

            if (Sql.Int(connection, null,
                    "SELECT COUNT(*) FROM programs WHERE program_id = @p AND status = 'Active';",
                    ("@p", programId)) == 0)
            {
                throw new BusinessRuleException("The selected program is not available.");
            }

            if (sectionId == 0)
            {
                return;
            }

            DataTable current = Sql.Table(connection, null,
                "SELECT program_id, semester, school_year FROM sections WHERE section_id = @id;",
                ("@id", sectionId));

            if (current.Rows.Count == 0)
            {
                throw new BusinessRuleException("That section no longer exists.");
            }

            bool hasEnrollments = Sql.Int(connection, null, """
                SELECT COUNT(*) FROM enrollment_details d
                JOIN enrollments e ON e.enrollment_id = d.enrollment_id
                WHERE d.section_id = @id AND e.status IN ('Pending', 'Approved');
                """, ("@id", sectionId)) > 0;

            DataRow row = current.Rows[0];

            if (hasEnrollments &&
                (Convert.ToInt32(row["program_id"]) != programId ||
                 Convert.ToString(row["semester"]) != semester ||
                 Convert.ToString(row["school_year"]) != schoolYear))
            {
                throw new BusinessRuleException(
                    "Students are enrolled in this section, so its program and term cannot be changed.");
            }

            int mostTaken = Sql.Int(connection, null, """
                SELECT COALESCE(MAX(c), 0) FROM (
                    SELECT COUNT(*) AS c
                    FROM enrollment_details d
                    JOIN enrollments e ON e.enrollment_id = d.enrollment_id
                    WHERE d.section_id = @id AND e.status IN ('Pending', 'Approved')
                    GROUP BY d.subject_id) t;
                """, ("@id", sectionId));

            if (capacity < mostTaken)
            {
                throw new BusinessRuleException(
                    $"Capacity cannot be lower than the {mostTaken} students already enrolled in one of its subjects.");
            }
        }
    }
}