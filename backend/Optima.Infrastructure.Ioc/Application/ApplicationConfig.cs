using Microsoft.Extensions.DependencyInjection;
using Optima.Application.Clients.Interfaces;
using Optima.Application.Clients.Services;

namespace Optima.Infrastructure.Ioc.Application;

internal static class ApplicationConfig
{
    internal static void Register(IServiceCollection services)
        => services.AddScoped<IUserService, UserService>();
}