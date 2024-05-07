using System.ComponentModel.DataAnnotations;

namespace test_1.Module;

public class task
{
    [Required] public DateTime Deadline { get; set; }
    [Required] [MaxLength(100)] public string Description { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }
    [Required] public int IdTask { get; set; }
    [Required] public int IdProject { get; set; }
    [Required] public int IdTaskType { get; set; }
    [Required] public int IdAssignedTo { get; set; }
    [Required] public int IdCreator { get; set; }
}