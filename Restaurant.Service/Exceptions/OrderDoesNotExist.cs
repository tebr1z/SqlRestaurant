namespace Restaurant.Service.Exceptions;

public class OrderDoesNotExist:Exception
{
    public OrderDoesNotExist() : base() { }
    public OrderDoesNotExist(string message) : base(message) { }
    public OrderDoesNotExist(string message, Exception exception) : base(message, exception) { }
}
