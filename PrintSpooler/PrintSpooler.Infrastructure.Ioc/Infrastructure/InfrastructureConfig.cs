using Microsoft.Extensions.DependencyInjection;
using PrintSpooler.Domain.Files.Repositories;
using PrintSpooler.Domain.Mega;
using PrintSpooler.Domain.Printers.Repositories;
using PrintSpooler.Infrastructure.Files;
using PrintSpooler.Infrastructure.Mega;
using PrintSpooler.Infrastructure.Printers;

namespace PrintSpooler.Infrastructure.Ioc.Infrastructure;

internal static class InfrastructureConfig
{
    internal static void Register(IServiceCollection services)
    {
        services.AddSingleton<DataAccess.FirestoreContext>();

        services.AddScoped<IPrinterRepository, PrinterRepository>();
        services.AddScoped<IFirestoreRepository, FirestoreRepository>();
        services.AddScoped<IMegaRepository, MegaRepository>();
    }
}