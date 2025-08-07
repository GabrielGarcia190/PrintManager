using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Optima.Domain.Users.Entities;

namespace Optima.Domain.Orders.Entities;

public class Order
{
    public Order(Guid clienteId, decimal totalOrder)
    {
        UserId = UserId == Guid.Empty ? throw new ArgumentException("ClienteId não pode ser vazio", nameof(clienteId)) : clienteId;
        TotalOrder = totalOrder == decimal.Zero ? throw new ArgumentNullException(nameof(totalOrder), "Usuário não pode ser nulo") : totalOrder;
        ArgumentNullException.ThrowIfNull(clienteId, nameof(clienteId));
        
    }

    [Key]
    public Guid Id { get; private set; }
    public DateTime DateOrder { get; private set; } = DateTime.UtcNow;
    [ForeignKey("User")]
    public Guid UserId { get; private set; }
    public User? Users { get; private set; }
    public decimal TotalOrder { get; private set; }
}