using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace Optima.Infrastructure.DataAcess;

public class OptimaDbContextFactory : IDesignTimeDbContextFactory<OptimaDbContext>
{
    public OptimaDbContext CreateDbContext(string[] args)
    {
        Env.Load();
        
        var optionsBuilder = new DbContextOptionsBuilder<OptimaDbContext>();
        
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgreSQL");
        
        optionsBuilder.UseNpgsql(connectionString);
        
        return new OptimaDbContext(optionsBuilder.Options);
    }
}