using System.ComponentModel.DataAnnotations;

namespace test_1.Module;

public class TeamMember
{
    [Required] [MaxLength(100)] public string FirstName { get; set; }
    [Required] [MaxLength(100)] public string LastName { get; set; }
    [Required] [EmailAddress] [MaxLength(100)] public string Email { get; set; }
    [Required] public int IdTeamMember { get; set; }
}