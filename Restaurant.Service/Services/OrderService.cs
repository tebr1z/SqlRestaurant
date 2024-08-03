using Restaurant.Core.Entities;
using Restaurant.Data.Repositories;
using Restaurant.Service.Exceptions;

namespace Restaurant.Service.Services;

public class OrderService
{
    public OrderRepository OrderRepository { get; set; }

    public OrderService()
    {
        OrderRepository = new();
    }

    public void Add(Order order)
    {
        order.TotalAmount = order.OrderItems.Sum(x => x.MenuItem.Price);
        OrderRepository.Add(order);
    }

    public void Update(int? id, Order order)
    {
        if (id == null) throw new IdNotGivenException("Id is not given");
        if (order.Date > DateTime.Now) throw new InvalidDateException("Date is not valid");
        OrderRepository.Update(order);
    }

    public void Remove(int? id)
    {
        if (id == null) throw new IdNotGivenException("Id is not given");
        var data = OrderRepository.Get(x => x.Id == id);
        if (data is null) throw new OrderDoesNotExist($"Order with id:{id} does not exist");
        OrderRepository.Delete(data as Order);
    }

    public IEnumerable<Order> GetAllOrders() => OrderRepository.Get();

    public IEnumerable<Order> GetOrdersByDateInterval(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate) throw new InvalidDateException("Dates are invalid");
        return OrderRepository.GetOrdersByDatesInterval(startDate, endDate);
    }

    public IEnumerable<Order> GetOrdersByPriceInterval(int startPrice, int endPrice)
    {
        if (startPrice > endPrice) throw new InvalidPriceException("Prices are invalid");
        return OrderRepository.GetOrdersByPriceInterval(startPrice, endPrice);
    }

    public IEnumerable<Order> GetOrdersByDate(DateTime dateTime) => OrderRepository.GetOrdersByDate(dateTime);

    public Order? GetOrderByIdNumber(int? id)
    {
        if (id is null) throw new IdNotGivenException("Id is not given");
        return OrderRepository.GetOrderByNo(id);
    }
}
