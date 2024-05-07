using test_1.Module;

namespace test_1.Repository;

public interface IProjectRepository
{
    public IEnumerable<Project> GetProjectsAssigned(List<int> idProjectsAssigned);
    public IEnumerable<Project> GetProjectsCreated(List<int> idProjectsCreated);

}