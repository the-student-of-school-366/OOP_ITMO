using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public User? GetUserByID(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var command = new NpgsqlCommand("SELECT ID, password, balance, history FROM users WHERE ID = @id", connection);
        command.Parameters.AddWithValue("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();
        if (!reader.Read()) return null;

        var user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3).Split('|').ToList());

        return user;
    }

    public void SaveUser(User user)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var command = new NpgsqlCommand("UPDATE users, SET balance = @balance, history = @history WHERE ID = @id", connection);

        command.Parameters.AddWithValue("balance", user.Balance);
        command.Parameters.AddWithValue("history", string.Join("|", user.History));
        command.Parameters.AddWithValue("id", user.ID);

        command.ExecuteNonQuery();
    }
}