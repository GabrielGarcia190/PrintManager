namespace Optima.Application.Orders.Commands;

public class CreateOrderCommand
{
    public CreateOrderCommand(Guid userId, decimal totalOrder)
    {
        UserId = userId == Guid.Empty ? throw new ArgumentException("UserId não pode ser vazio", nameof(userId)) : userId;
        TotalOrder = totalOrder == decimal.Zero ? throw new ArgumentException("TotalOrder não pode ser zero", nameof(totalOrder)) : totalOrder;
    }
    public Guid UserId { get; set; }
    public decimal TotalOrder { get; set; }
}