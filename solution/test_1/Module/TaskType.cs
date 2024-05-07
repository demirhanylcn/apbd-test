using System.ComponentModel.DataAnnotations;

namespace test_1.Module;

public class TaskType
{
    [Required] [MaxLength(100)] public string Name { get; set; }
    [Required] public int IdTaskType { get; set; }
    
}