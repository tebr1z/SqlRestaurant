using Restaurant.Core.Entities;
using Restaurant.Data.Interfaces;

namespace Restaurant.Data.Repositories;

public class OrderRepository:Repository<Order>, IRepository<Order>
{
    public IEnumerable<Order> GetOrdersByDatesInterval(DateTime startDate, DateTime endDate) => _table.Where(o => o.Date > startDate && o.Date < endDate);
    public IEnumerable<Order> GetOrdersByDate(DateTime dateTime) => _table.Where(o => o.Date == dateTime);
    public IEnumerable<Order> GetOrdersByPriceInterval(int startPrice, int endPrice) => _table.Where(o => o.TotalAmount > startPrice && o.TotalAmount < endPrice);
    public Order? GetOrderByNo(int? id) => _table.SingleOrDefault(o => o.Id == id);
}
