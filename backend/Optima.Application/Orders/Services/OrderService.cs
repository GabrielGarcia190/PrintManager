using Optima.Application.Orders.Commands;
using Optima.Application.Orders.Interfaces;
using Optima.Domain.DataAccess;
using Optima.Domain.Orders.Entities;
using Optima.Domain.Orders.Repositories;

namespace Optima.Application.Orders.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddOrderAsync(CreateOrderCommand order)
    {
        var orderEntity = new Order(order.UserId, order.TotalOrder);
        await _orderRepository.AddAsync(orderEntity);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _orderRepository.GetAllAsync();
}