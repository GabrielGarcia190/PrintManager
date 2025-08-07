using Optima.Domain.Orders.Entities;

namespace Optima.Application.Orders.Services;

public class OrderService
{
    public void AddOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));


        Console.WriteLine($"Pedido criado para o cliente: {order.UserId}, valor: {order.TotalOrder}");
    }
}