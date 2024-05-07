using test_1.DTOs;

namespace test_1.Service;

public interface ITaskService
{
    public  TeamMemberWithTasks GetDataAboutTeamMemberWithTasks(int idTeamMember);
}