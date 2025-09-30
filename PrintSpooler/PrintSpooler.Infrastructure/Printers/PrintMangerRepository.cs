using System.Drawing.Printing;
using System.Runtime.Versioning;
using PrintSpooler.Domain.Printers.Repositories;
using System.ServiceProcess;
using PrintSpooler.Infrastructure.DataAccess;
using PrintSpooler.Domain.Files.Entities;

namespace PrintSpooler.Infrastructure.Printers;

public class PrinterRepository : IPrinterRepository
{
    
    [SupportedOSPlatform("windows")]
    public IEnumerable<string> GetInstalledPrinters()
    {
        foreach (string printer in PrinterSettings.InstalledPrinters)
        {
            yield return printer;
        }
    }

    [SupportedOSPlatform("windows")]
    public string GetSpoolerStatus()
    {
        using var service = new ServiceController("Spooler");

        return service.Status switch
        {
            ServiceControllerStatus.Running => "Spooler está em execução",
            ServiceControllerStatus.Stopped => "Spooler está parado",
            ServiceControllerStatus.Paused => "Spooler está pausado",
            _ => $"Spooler em estado {service.Status}"
        };
    }
}