using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Data.Repositories;
using Restaurant.Service.Exceptions;

namespace Restaurant.Service.Services;

public class MenuItemService
{
    public MenuItemRepository MenuItemRepository { get; set; }

    public MenuItemService()
    {
        MenuItemRepository = new();
    }

    public void Add(MenuItem menuItem)
    {
        foreach(var item in MenuItemRepository.Get(x => x.Name.Equals(menuItem.Name))) Console.WriteLine(item);
        if (MenuItemRepository.Get(x => x.Name == menuItem.Name).Count() != 0)
            throw new MenuItemAlreadyExistsException($"Menu item with name:{menuItem.Name} already exists.");
        MenuItemRepository.Add(menuItem);
    }

    public void Remove(int? id)
    {
        if (id == null) throw new IdNotGivenException("Id is not given");
        var data = MenuItemRepository.Get(x => x.Id == id);
        if (data is null) throw new MenuItemDoesNotExist($"Order with id:{id} does not exist");
        MenuItemRepository.Delete(data as MenuItem);
    }

    public void Update(int? id, MenuItem menuItem)
    {
        if (id == null) throw new IdNotGivenException("Id is not given");
        var data = MenuItemRepository.Get(x => x.Id == id);
        if (data is null) throw new MenuItemDoesNotExist($"Order with id:{id} does not exist");
        if (MenuItemRepository.Get(x => x.Name == menuItem.Name).Count() != 0)
            throw new MenuItemAlreadyExistsException($"Menu item with name:{menuItem.Name} already exists.");
        MenuItemRepository.Update(menuItem);
    }

    public IEnumerable<MenuItem> Get() => MenuItemRepository.Get();

    public IEnumerable<MenuItem> GetItemsByCategory(Category category) => MenuItemRepository.Get(x => x.Category == category);

    public IEnumerable<MenuItem> GetItemsByPriceInterval(int startPrice, int endPrice)
    {
        if (startPrice > endPrice) throw new InvalidPriceException("Invalid Prices");
        return MenuItemRepository.Get(x => x.Price > startPrice && x.Price < endPrice);
    }

    public IEnumerable<MenuItem> GetItemsByName(string name) => MenuItemRepository.Get(x => x.Name.Equals(name));
        
}
