using Restaurant.Core.Entities;
using Restaurant.Data.Interfaces;

namespace Restaurant.Data.Repositories;

public class OrderItemRepository:Repository<OrderItem>, IRepository<OrderItem>
{
}
