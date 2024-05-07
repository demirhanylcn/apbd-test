using System.Data.SqlClient;
using test_1.Exceptions;
using test_1.Module;

namespace test_1.Repository;

public class TeamMemberRepository :  ITeamMemberRepository
{
    private readonly string _connectionString;

    public TeamMemberRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string is null");
    }
    
    public TeamMember? GetTeamMember(int idTeamMember)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        connection.Open();
        command.CommandText = "SELECT * FROM TeamMember WHERE IdTeamMember = @IdTeamMember";
        command.Parameters.AddWithValue("@IdTeamMember", idTeamMember);
        command.Connection = connection;
        
        var reader = command.ExecuteReader();
        if (!reader.Read()) throw new NoTeamMemberException();
        
        
        return new TeamMember
        {
            IdTeamMember = (int)reader["IdTeamMember"],
            FirstName = reader["FirstName"].ToString() ?? throw new NullReferenceException(),
            LastName = reader["LastName"].ToString() ?? throw new NullReferenceException(),
            Email = reader["Email"].ToString() ?? throw new NullReferenceException(),
        };
    }
}