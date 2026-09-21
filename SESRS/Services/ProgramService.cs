using MySqlConnector;
using SESRS.Data;
using SESRS.Models;

namespace SESRS.Services;

public class ProgramService
{
    private readonly DatabaseConnection databaseConnection = new();

    public List<AcademicProgram> GetAllPrograms()
    {
        List<AcademicProgram> programs = new();

        using MySqlConnection connection = databaseConnection.GetConnection();

        connection.Open();

        string query = @"
            SELECT program_id, program_code, program_name,
                   duration_years, status
            FROM programs
            ORDER BY program_code;
        ";

        using MySqlCommand command = new(query, connection);
        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            AcademicProgram program = new()
            {
                ProgramId = reader.GetInt32("program_id"),
                ProgramCode = reader.GetString("program_code"),
                ProgramName = reader.GetString("program_name"),
                DurationYears = reader.GetInt32("duration_years"),
                Status = reader.GetString("status")
            };

            programs.Add(program);
        }

        return programs;
    }
}