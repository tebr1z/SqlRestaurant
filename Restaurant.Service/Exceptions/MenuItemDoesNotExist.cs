namespace Restaurant.Service.Exceptions;

public class MenuItemDoesNotExist:Exception
{
    public MenuItemDoesNotExist() : base() { }
    public MenuItemDoesNotExist(string message) : base(message) { }
    public MenuItemDoesNotExist(string message, Exception exception) : base(message, exception) { }
}
