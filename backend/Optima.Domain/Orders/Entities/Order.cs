using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Optima.Domain.Users.Entities;

namespace Optima.Domain.Orders.Entities;

public class Order
{
    public Order(Guid userId, decimal totalOrder)
    {
        UserId = userId == Guid.Empty ? throw new ArgumentException("UserId não pode ser vazio", nameof(userId)) : userId;
        TotalOrder = totalOrder == decimal.Zero ? throw new ArgumentException("TotalOrder não pode ser zero", nameof(totalOrder)) : totalOrder;
    }

    [Key]
    public Guid Id { get; private set; }
    public DateTime DateOrder { get; private set; } = DateTime.UtcNow;
    [ForeignKey("User")]
    public Guid UserId { get; private set; }
    public User? Users { get; private set; }
    public decimal TotalOrder { get; private set; }
}