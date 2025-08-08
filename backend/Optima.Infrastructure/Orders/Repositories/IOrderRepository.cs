using Microsoft.EntityFrameworkCore;
using Optima.Domain.Orders.Entities;
using Optima.Domain.Orders.Repositories;
using Optima.Infrastructure.DataAcess;

namespace Optima.Infrastructure.Orders.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OptimaDbContext _context;

    public OrderRepository(OptimaDbContext context)
        => _context = context;

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public IEnumerable<Order> GetAll()
        => _context.Orders.Include(x => x.Users).ToList();
}