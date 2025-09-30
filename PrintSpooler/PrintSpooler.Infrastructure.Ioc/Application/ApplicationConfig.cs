using Microsoft.Extensions.DependencyInjection;
using PrintSpooler.Application.Printers.Interfaces;
using PrintSpooler.Application.Printers.Services;

namespace PrintSpooler.Infrastructure.Ioc.Application;

internal static class ApplicationConfig
{
    internal static void Register(IServiceCollection services)
        => services.AddScoped<IPrinterService, PrinterService>();
}