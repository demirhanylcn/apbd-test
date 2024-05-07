using System.Data.SqlClient;
using test_1.Exceptions;
using test_1.Module;

namespace test_1.Repository;

public class ProjectRepository : IProjectRepository
{
    private readonly string _connectionString;

    public ProjectRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string is null");
    }

    public IEnumerable<Project> GetProjectsAssigned(List<int> idProjectsAssigned)
    {
        var projects = new List<Project>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        connection.Open();
        command.CommandText = "SELECT * FROM Project WHERE IdProject = @IdProject";
        command.Parameters.AddWithValue("@IdProject", idProjectsAssigned[0]);
        command.Connection = connection;
        
        var reader = command.ExecuteReader();
        if (!reader.Read()) throw new NoProjectException();
        int count = 1;
        while (reader.Read())
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@IdProject", idProjectsAssigned[count++]);
            var project = new Project
            {
                IdProject = (int)reader["IdProject"],
                Name = reader["Name"].ToString() ?? throw new NullReferenceException(),
                Deadline = (DateTime)reader["Deadline"]
            };
            projects.Add(project);
        }

        return projects;
    }
    

    public IEnumerable<Project> GetProjectsCreated(List<int> idProjectsCreated)
    {
        var projects = new List<Project>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        connection.Open();
        command.CommandText = "SELECT * FROM Project WHERE IdProject = @IdProject";
        command.Parameters.AddWithValue("@IdProject", idProjectsCreated[0]);
        command.Connection = connection;
        
        var reader = command.ExecuteReader();
        if (!reader.Read()) throw new NoProjectException();
        int count = 1;
        while (reader.Read())
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@IdProject", idProjectsCreated[count++]);
            var project = new Project
            {
                IdProject = (int)reader["IdProject"],
                Name = reader["Name"].ToString() ?? throw new NullReferenceException(),
                Deadline = (DateTime)reader["Deadline"]
            };
            projects.Add(project);
        }

        return projects;
    }
}