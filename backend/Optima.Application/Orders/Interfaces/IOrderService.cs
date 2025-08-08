using Optima.Application.Orders.Commands;
using Optima.Domain.Orders.Entities;

namespace Optima.Application.Orders.Interfaces;

public interface IOrderService
{
    void AddOrder(CreateOrderCommand command);
    IEnumerable<Order> GetAll();
}