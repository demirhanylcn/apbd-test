using test_1.Module;

namespace test_1.DTOs;

public class TeamMemberWithTasks
{
    public TeamMember TeamMember { get; set; }
    public IEnumerable<task> TasksCreated { get; set; }
    public IEnumerable<task> TasksAssigned { get; set; }
}