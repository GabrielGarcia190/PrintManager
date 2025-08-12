using Optima.Domain.Orders.Entities;

namespace Optima.Domain.Orders.Repositories;

public interface IOrderRepository
{
    Task<Order> AddAsync(Order order);
    Task<IEnumerable<Order>> GetAllAsync();
}