using test_1.Module;

namespace test_1.Repository;

public interface ITaskRepository
{
    public task? GetTask(int idTask);
    public IEnumerable<task> GetTasksAssigned(int idTeamMember);
    public IEnumerable<task> GetTasksCreated(int idTeamMember);
}