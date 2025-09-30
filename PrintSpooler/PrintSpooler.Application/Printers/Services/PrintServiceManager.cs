using PrintSpooler.Application.Printers.Interfaces;
using PrintSpooler.Domain.Printers.Repositories;

namespace PrintSpooler.Application.Printers.Services;

public class PrinterService : IPrinterService
{
    private readonly IPrinterRepository _printerRepository;

    public PrinterService(IPrinterRepository printerRepository)
        => _printerRepository = printerRepository;

    public IEnumerable<string> GetInstalledPrinters()
        => _printerRepository.GetInstalledPrinters();

    public string GetSpoolerStatus()
        => _printerRepository.GetSpoolerStatus();
}