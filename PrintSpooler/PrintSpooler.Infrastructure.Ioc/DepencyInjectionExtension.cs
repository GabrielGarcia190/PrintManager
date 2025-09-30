using Microsoft.Extensions.DependencyInjection;
using PrintSpooler.Infrastructure.Ioc.Application;
using PrintSpooler.Infrastructure.Ioc.Infrastructure;

namespace PrintSpooler.Infrastructure.Ioc;

public static class DepencyInjectionExtension
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        ApplicationConfig.Register(services);
        InfrastructureConfig.Register(services);
    }       
}