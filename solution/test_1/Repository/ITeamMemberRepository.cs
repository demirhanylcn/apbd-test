using test_1.Module;

namespace test_1.Repository;

public interface ITeamMemberRepository
{
    public TeamMember? GetTeamMember(int idTeamMember);
}