using Microsoft.Extensions.DependencyInjection;
using Optima.Application.Users.Interfaces;
using Optima.Application.Users.Services;

namespace Optima.Infrastructure.Ioc.Application;

internal static class ApplicationConfig
{
    internal static void Register(IServiceCollection services)
        => services.AddScoped<IUserService, UserService>();
}