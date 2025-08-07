using Microsoft.EntityFrameworkCore;
using Optima.Domain.Orders.Entities;
using Optima.Domain.Users.Entities;

namespace Optima.Infrastructure.DataAcess;

public class OptimaDbContext : DbContext
{
    public OptimaDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
}