using Optima.Application.Orders.Commands;
using Optima.Domain.Orders.Entities;

namespace Optima.Application.Orders.Interfaces;

public interface IOrderService
{
    Task AddOrderAsync(CreateOrderCommand command);
    Task<IEnumerable<Order>> GetAllAsync();
}