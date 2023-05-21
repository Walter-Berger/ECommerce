namespace UserService.API.Exceptions;

public class DuplicationException : Exception
{
    public DuplicationException(string message) : base(message)
    {
    }
}
