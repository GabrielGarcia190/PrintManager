using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optima.Domain.DataAccess;
using Optima.Domain.Orders.Repositories;
using Optima.Domain.Users.Repositories;
using Optima.Infrastructure.DataAcess;
using Optima.Infrastructure.Orders.Repositories;
using Optima.Infrastructure.Users.Repositories;

namespace Optima.Infrastructure.Ioc.Infrastructure;

internal static class InfrastructureConfig
{
    internal static void Register(IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<OptimaDbContext>((serviceProvider, options) =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();

            var connectionString = config.GetConnectionString("PostgreSQL");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string 'SqlServer' não encontrada. Verifique o .env ou variáveis de ambiente.");

            options.UseNpgsql(connectionString);
        });
    }
}