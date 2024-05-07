namespace test_1.Exceptions;

public class NoProjectException : Exception
{
    public NoProjectException() : base("There is no project with this id.")
    {
        
    }
}