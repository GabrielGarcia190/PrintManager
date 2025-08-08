using Optima.Application.Orders.Commands;
using Optima.Application.Orders.Interfaces;
using Optima.Domain.Orders.Entities;
using Optima.Domain.Orders.Repositories;

namespace Optima.Application.Orders.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
        => _orderRepository = orderRepository;

    public void AddOrder(CreateOrderCommand order)
        => _orderRepository.Add(new Order(order.UserId, order.TotalOrder));

    public IEnumerable<Order> GetAll()
        => _orderRepository.GetAll();
}