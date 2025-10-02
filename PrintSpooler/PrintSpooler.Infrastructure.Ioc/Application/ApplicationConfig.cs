using Microsoft.Extensions.DependencyInjection;
using PrintSpooler.Application.Files.Interfaces;
using PrintSpooler.Application.Files.Services;
using PrintSpooler.Application.Mega.Interfaces;
using PrintSpooler.Application.Mega.Services;
using PrintSpooler.Application.Printers.Interfaces;
using PrintSpooler.Application.Printers.Services;
using PrintSpooler.Application.Printing.Interfaces;
using PrintSpooler.Application.Printing.Services;

namespace PrintSpooler.Infrastructure.Ioc.Application;

internal static class ApplicationConfig
{
    internal static void Register(IServiceCollection services)
    {
        services.AddScoped<IPrinterService, PrinterService>();
        services.AddScoped<IFilesToPrintService, FilesToPrintService>();
        services.AddScoped<IMegaService, MegaService>();
        services.AddScoped<IPrintingService, PrintingService>();
    }
}