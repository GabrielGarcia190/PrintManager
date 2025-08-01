using Microsoft.EntityFrameworkCore;
using Optima.Domain.Users.Entities;

namespace Optima.Infrastructure.DataAcess;

public class OptimaDbContext : DbContext
{
    public OptimaDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
}