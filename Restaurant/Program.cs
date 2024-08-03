using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Enums;
using Restaurant.Service.Services;

MenuItemService menuItemService = new();
OrderService orderService = new();

bool isRunning = true;
MenuEnum menu = MenuEnum.MainMenu;

while (isRunning)
{
    switch (menu)
    {
        case MenuEnum.MainMenu:
            MainMenu();
            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) isRunning = false;
                menu = choice switch
                {
                    1 => MenuEnum.MenuMenu,
                    2 => MenuEnum.OrderMenu,
                    _ => MenuEnum.MainMenu
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case MenuEnum.MenuMenu:
            MenuMenu();
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMenuItem();
                        break;
                    case 2:
                        UpdateMenuItem();
                        break;
                    case 3:
                        DeleteMenuItem();
                        break;
                    case 4:
                        ShowAllMenuItems();
                        break;
                    case 5:
                        ShowItemsByCategory();
                        break;
                    case 6:
                        ShowItemsByPriceInterval();
                        break;
                    case 7:
                        SearchItemsByName();
                        break;
                    case 0:
                        menu = MenuEnum.MainMenu;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case MenuEnum.OrderMenu:
            OrderMenu();
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        menu = MenuEnum.MainMenu;
                        break;
                    case 1:
                        AddNewOrder();
                        break;
                    case 2:
                        CancelOrder();
                        break;
                    case 3:
                        ShowAllOrders();
                        break;
                    case 4:
                        ShowOrdersByDateInterval();
                        break;
                    case 5:
                        ShowOrdersByPriceInterval();
                        break;
                    case 6:
                        ShowOrdersBySpecificDate();
                        break;
                    case 7:
                        ShowOrderByIdNumber();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        default:
            break;
    }
}

void MainMenu()
{
    Console.WriteLine("1. Operations on the Menu");
    Console.WriteLine("2. Operations on the Orders");
    Console.WriteLine("0. Quit");
}

void MenuMenu()
{
    Console.WriteLine("1. Add Item");
    Console.WriteLine("2. Update Item");
    Console.WriteLine("3. Delete Item");
    Console.WriteLine("4. Show All Items");
    Console.WriteLine("5. Show Items By Category");
    Console.WriteLine("6. Show Items By Price Interval");
    Console.WriteLine("7. Search By Names");
    Console.WriteLine("0. Return to the previous menu");
}

void OrderMenu()
{
    Console.WriteLine("1. Add New Order");
    Console.WriteLine("2. Cancel Order");
    Console.WriteLine("3. Show All Orders");
    Console.WriteLine("4. Show Orders By Date Interval");
    Console.WriteLine("5. Show Orders By Price Interval");
    Console.WriteLine("6. Show Orders By Specific Date");
    Console.WriteLine("7. Show Order By Id Number");
    Console.WriteLine("0. Return to the previous menu");
}

void AddMenuItem()
{
    try
    {
        Console.WriteLine("Enter the name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the price");
        int price = int.Parse(Console.ReadLine());
        Console.WriteLine("Select category: ");
        Category category = (Category)int.Parse(Console.ReadLine());
        menuItemService.Add(new MenuItem { Category = category, Name = name, Price = price });
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        AddMenuItem();
    }
}

void UpdateMenuItem()
{
    try
    {
        Console.WriteLine("Enter the id of the item you want to update: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the price");
        int price = int.Parse(Console.ReadLine());
        Console.WriteLine("Select category: ");
        Category category = (Category)int.Parse(Console.ReadLine());
        menuItemService.Update(id, new MenuItem { Name = name, Category = category, Price = price });
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void DeleteMenuItem()
{
    try
    {
        Console.WriteLine("Enter the id of the item you want to delete");
        int id = int.Parse(Console.ReadLine());
        menuItemService.Remove(id);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ShowAllMenuItems()
{
    foreach (MenuItem item in menuItemService.Get())
        Console.WriteLine(item);
}

void ShowItemsByCategory()
{
    Console.WriteLine("Enter category");
    try
    {
        Category category = (Category)int.Parse(Console.ReadLine());
        foreach (MenuItem item in menuItemService.GetItemsByCategory(category))
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ShowItemsByPriceInterval()
{
    try
    {
        Console.WriteLine("Enter start price: ");
        int startPrice = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter end price: ");
        int endPrice = int.Parse(Console.ReadLine());
        foreach (MenuItem item in menuItemService.GetItemsByPriceInterval(startPrice, endPrice))
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void SearchItemsByName()
{
    Console.WriteLine("Enter the name: ");
    try
    {
        string name = Console.ReadLine();
        foreach (MenuItem item in menuItemService.GetItemsByName(name))
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void AddNewOrder()
{
    Order newOrder = new();
    Console.WriteLine("How many items are in the order?");
    int count = int.Parse(Console.ReadLine());
    for (int i = 0; i < count; i++)
    {
        try
        {
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the price");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Category");
            Category category = (Category)int.Parse(Console.ReadLine());
            OrderItem orderItem = new() { MenuItem = new MenuItem { Category = category, Name = name, Price = price } };
            newOrder.OrderItems.Add(orderItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            i--;
        }
    }
    orderService.Add(newOrder);
}

void CancelOrder()
{
    try
    {
        Console.WriteLine("Enter the id of the order you want to cancel: ");
        int id = int.Parse(Console.ReadLine());
        orderService.Remove(id);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ShowAllOrders()
{
    foreach (Order item in orderService.GetAllOrders())
    {
        Console.WriteLine(item);
    }
}

void ShowOrdersByDateInterval()
{
    Console.WriteLine("Enter start date:");
    DateTime startTime = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Enter end date:");
    DateTime endTime = DateTime.Parse(Console.ReadLine());

    try
    {
        foreach (var item in orderService.GetOrdersByDateInterval(startTime, endTime))
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ShowOrdersByPriceInterval()
{
    Console.WriteLine("Enter start price:");
    int startPrice = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter end price:");
    int endPrice = int.Parse(Console.ReadLine());

    try
    {
        foreach (var item in orderService.GetOrdersByPriceInterval(startPrice, endPrice))
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ShowOrdersBySpecificDate()
{
    Console.WriteLine("Enter date:");
    try
    {
        DateTime dateTime = DateTime.Parse(Console.ReadLine());
        foreach (var item in orderService.GetOrdersByDate(dateTime))
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ShowOrderByIdNumber()
{
    try
    {
        Console.WriteLine("Enter id:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine(orderService.GetOrderByIdNumber(id));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
