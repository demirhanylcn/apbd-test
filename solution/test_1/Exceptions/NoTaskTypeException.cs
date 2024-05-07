namespace test_1.Exceptions;

public class NoTaskTypeException : Exception
{
    public NoTaskTypeException() : base("there is no tasktype with this id")
    {
        
    }
}