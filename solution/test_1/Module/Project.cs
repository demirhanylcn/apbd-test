using System.ComponentModel.DataAnnotations;

namespace test_1.Module;

public class Project
{
    [Required] [MaxLength(100)] public DateTime Deadline { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }
    [Required] public int IdProject { get; set; }
}