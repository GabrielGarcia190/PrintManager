using Microsoft.Extensions.DependencyInjection;
using Optima.Infrastructure.Ioc.Application;
using Optima.Infrastructure.Ioc.Infrastructure;

namespace Optima.Infrastructure.Ioc;

public static class DepencyInjectionExtension
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        InfrastructureConfig.Register(services);
        ApplicationConfig.Register(services);
    }
}