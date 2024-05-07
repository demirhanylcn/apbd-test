using test_1.Module;

namespace test_1.Repository;

public interface ITaskTypeRepository
{
    public TaskType? GetTaskType(int idTaskType);
}