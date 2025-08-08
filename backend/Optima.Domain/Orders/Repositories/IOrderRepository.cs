using Optima.Domain.Orders.Entities;

namespace Optima.Domain.Orders.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    IEnumerable<Order> GetAll();
}