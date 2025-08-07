using Optima.Domain.Orders.Entities;

namespace Optima.Application.Orders.Interfaces;

public interface IOrderService
{
    void AddOrder(Order order);
}