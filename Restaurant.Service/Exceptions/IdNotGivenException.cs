namespace Restaurant.Service.Exceptions;

public class IdNotGivenException:Exception
{
    public IdNotGivenException() : base() { }
    public IdNotGivenException(string message) : base(message) { }
    public IdNotGivenException(string message, Exception exception) : base(message, exception) { }
}
