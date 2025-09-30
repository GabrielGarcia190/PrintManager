namespace PrintSpooler.Domain.Printers.Repositories;

public interface IPrinterRepository
{
    IEnumerable<string> GetInstalledPrinters();
    string GetSpoolerStatus();
}