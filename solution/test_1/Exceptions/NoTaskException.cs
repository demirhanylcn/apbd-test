namespace test_1.Exceptions;

public class NoTaskException : Exception
{
    public NoTaskException() : base("there is no task with this id.")
    {
        
    }
}