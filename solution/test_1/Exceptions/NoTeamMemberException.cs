namespace test_1.Exceptions;

public class NoTeamMemberException : Exception
{
    public NoTeamMemberException() : base("there is no team member with this id")
    {
        
    }
}