using System.Data.SqlClient;
using test_1.Exceptions;
using test_1.Module;


namespace test_1.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly string _connectionString;

    public TaskRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string is null");
    }

    public task? GetTask(int idTask)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        connection.Open();
        command.CommandText = "SELECT * FROM Task WHERE IdTask = @IdTask";
        command.Parameters.AddWithValue("@IdTask", idTask);
        command.Connection = connection;
        
        var reader = command.ExecuteReader();
        if (!reader.Read()) throw new NoTaskException();
        
        return new task
        {
            IdTask = (int)reader["IdTask"],
            Name = reader["Name"].ToString() ?? throw new NullReferenceException(),
            Description = reader["Description"].ToString() ?? throw new NullReferenceException(),
            Deadline = (DateTime)reader["Deadline"],
            IdProject = (int)reader["IdProject"],
            IdTaskType = (int)reader["IdTaskType"],
            IdAssignedTo = (int)reader["IdAssignedTo"],
            IdCreator = (int)reader["IdCreator"]
        };
    }
    public IEnumerable<task> GetTasksAssigned(int idTeamMember)
    {
        var tasks = new List<task>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        connection.Open();
        command.CommandText = "SELECT * FROM Task WHERE IdAssignedTo = @IdTeamMember";
        command.Parameters.AddWithValue("@IdTeamMember", idTeamMember);
        command.Connection = connection;
        
        var reader = command.ExecuteReader();
        if (!reader.Read()) throw new NoProjectException();
        
        while (reader.Read())
        {
            var task = new task
            {
                IdTask = (int)reader["IdTask"],
                Name = reader["Name"].ToString() ?? throw new NullReferenceException(),
                Description = reader["Description"].ToString() ?? throw new NullReferenceException(),
                Deadline = (DateTime)reader["Deadline"],
                IdProject = (int)reader["IdProject"],
                IdTaskType = (int)reader["IdTaskType"],
                IdAssignedTo = (int)reader["IdAssignedTo"],
                IdCreator = (int)reader["IdCreator"]
            };
            tasks.Add(task);

        }
        return tasks;
    }
    public IEnumerable<task> GetTasksCreated(int idTeamMember)
    {
        var tasks = new List<task>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        connection.Open();
        command.CommandText = "SELECT * FROM Task WHERE IdCreator = @IdTeamMember";
        command.Parameters.AddWithValue("@IdTeamMember", idTeamMember);
        command.Connection = connection;
        
        var reader = command.ExecuteReader();
        if (!reader.Read()) throw new NoProjectException();
        
        while (reader.Read())
        {
            var task = new task
            {
                IdTask = (int)reader["IdTask"],
                Name = reader["Name"].ToString() ?? throw new NullReferenceException(),
                Description = reader["Description"].ToString() ?? throw new NullReferenceException(),
                Deadline = (DateTime)reader["Deadline"],
                IdProject = (int)reader["IdProject"],
                IdTaskType = (int)reader["IdTaskType"],
                IdAssignedTo = (int)reader["IdAssignedTo"],
                IdCreator = (int)reader["IdCreator"]
            };
            tasks.Add(task);

        }
        return tasks;
    }
}