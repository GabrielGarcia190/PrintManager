using PrintSpooler.Domain.Files.Entities;

namespace PrintSpooler.Application.Printers.Interfaces;

public interface IPrinterService
{
    IEnumerable<string> GetInstalledPrinters();
    string GetSpoolerStatus();

    Task<IEnumerable<FileToPrint>> GetFilesToPrint();
}