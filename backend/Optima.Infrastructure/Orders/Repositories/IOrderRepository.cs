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

    public async Task<Order> AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _context.Orders.Include(x => x.Users).ToListAsync();
}