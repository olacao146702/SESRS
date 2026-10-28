using System.Data;
using MySqlConnector;

namespace SESRS.Data;

/// <summary>Small helpers so services can run parameterized queries without repeating boilerplate.</summary>
public static class Sql
{
    public static DataTable Table(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string query,
        params (string Name, object? Value)[] parameters)
    {
        using var command = Build(connection, transaction, query, parameters);
        using var adapter = new MySqlDataAdapter(command);

        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public static object? Scalar(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string query,
        params (string Name, object? Value)[] parameters)
    {
        using var command = Build(connection, transaction, query, parameters);
        object? value = command.ExecuteScalar();
        return value == DBNull.Value ? null : value;
    }

    public static int Int(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string query,
        params (string Name, object? Value)[] parameters)
    {
        object? value = Scalar(connection, transaction, query, parameters);
        return value == null ? 0 : Convert.ToInt32(value);
    }

    public static int Exec(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string query,
        params (string Name, object? Value)[] parameters)
    {
        using var command = Build(connection, transaction, query, parameters);
        return command.ExecuteNonQuery();
    }

    /// <summary>Runs an INSERT and returns the new auto-increment id.</summary>
    public static long Insert(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string query,
        params (string Name, object? Value)[] parameters)
    {
        using var command = Build(connection, transaction, query, parameters);
        command.ExecuteNonQuery();
        return command.LastInsertedId;
    }

    private static MySqlCommand Build(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string query,
        (string Name, object? Value)[] parameters)
    {
        var command = new MySqlCommand(query, connection, transaction);

        foreach (var (name, value) in parameters)
        {
            command.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }

        return command;
    }
}
