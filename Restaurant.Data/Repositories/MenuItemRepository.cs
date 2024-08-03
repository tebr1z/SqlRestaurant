using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Data.Interfaces;

namespace Restaurant.Data.Repositories;

public class MenuItemRepository : Repository<MenuItem>, IRepository<MenuItem>
{
}