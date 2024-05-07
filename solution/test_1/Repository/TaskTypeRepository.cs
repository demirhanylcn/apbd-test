using System.Data.SqlClient;
using test_1.Exceptions;
using test_1.Module;

namespace test_1.Repository;

public class TaskTypeRepository : ITaskTypeRepository
{
    private readonly string _connectionString;

    public TaskTypeRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string is null");
    }

    public TaskType? GetTaskType(int idTaskType)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        connection.Open();
        command.CommandText = "SELECT * FROM TaskType WHERE IdTaskType = @IdTaskType";
        command.Parameters.AddWithValue("@IdTaskType", idTaskType);
        command.Connection = connection;
        
        var reader = command.ExecuteReader();
        if (!reader.Read()) throw new NoTaskTypeException();
        
        return new TaskType
        {
            IdTaskType = (int)reader["IdTaskType"],
            Name = reader["Name"].ToString() ?? throw new NullReferenceException(),
        };
    }
}