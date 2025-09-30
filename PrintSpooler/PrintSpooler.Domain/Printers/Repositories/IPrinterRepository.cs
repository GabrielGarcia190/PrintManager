using PrintSpooler.Domain.Files.Entities;

namespace PrintSpooler.Domain.Printers.Repositories;

public interface IPrinterRepository
{
    IEnumerable<string> GetInstalledPrinters();
    string GetSpoolerStatus();
    Task<IEnumerable<FileToPrint>> GetFilesToPrint();
}