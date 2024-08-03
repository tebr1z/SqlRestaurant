namespace Restaurant.Service.Exceptions;

public class InvalidPriceException:Exception
{
    public InvalidPriceException() : base() { }
    public InvalidPriceException(string message) : base(message) { }
    public InvalidPriceException(string message, Exception exception) : base(message, exception) { }
}
