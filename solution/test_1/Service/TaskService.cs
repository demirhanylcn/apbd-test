using test_1.DTOs;
using test_1.Repository;

namespace test_1.Service;

public class TaskService : ITaskService
{
    public ITaskRepository _TaskRepository;
    public ITaskTypeRepository _TaskTypeRepository;
    public ITeamMemberRepository _TeamMemberRepository;
    public IProjectRepository _ProjectRepository;

    public TaskService(ITaskRepository taskRepository, ITaskTypeRepository taskTypeRepository,
        IProjectRepository projectRepository, ITeamMemberRepository teamMemberRepository)
    {
        _TaskRepository = taskRepository;
        _ProjectRepository = projectRepository;
        _TaskTypeRepository = taskTypeRepository;
        _TeamMemberRepository = teamMemberRepository;

    }

    public TeamMemberWithTasks GetDataAboutTeamMemberWithTasks(int idTeamMember)
    {

        
            var tasksAssigned = _TaskRepository.GetTasksAssigned(idTeamMember);
            var tasksCreated = _TaskRepository.GetTasksCreated(idTeamMember);

            tasksAssigned = tasksAssigned.OrderByDescending(task => task.Deadline);
            tasksCreated = tasksCreated.OrderByDescending(task => task.Deadline);

            var TeamMemberWithTasks = new TeamMemberWithTasks()
            {
                TeamMember = _TeamMemberRepository.GetTeamMember(idTeamMember),
                TasksAssigned = tasksAssigned,
                TasksCreated = tasksCreated
            };

            return TeamMemberWithTasks;

    }
}