namespace Restaurant.Service.Exceptions;

public class InvalidDateException:Exception
{
    public InvalidDateException() : base() { }
    public InvalidDateException(string message) : base(message) { }
    public InvalidDateException(string message, Exception exception) : base(message, exception) { }

}
