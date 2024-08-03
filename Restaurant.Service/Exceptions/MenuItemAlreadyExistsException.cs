namespace Restaurant.Service.Exceptions;

public class MenuItemAlreadyExistsException:Exception
{
    public MenuItemAlreadyExistsException():base() { }
    public MenuItemAlreadyExistsException(string message):base(message) { }
    public MenuItemAlreadyExistsException(string message, Exception exception):base(message, exception) { }

}
