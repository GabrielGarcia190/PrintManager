using PrintSpooler.Application.Printing.Interfaces;
using PrintSpooler.Domain.Files.Repositories;
using PrintSpooler.Domain.Mega;
using PrintSpooler.Domain.Printers.Repositories;
using PrintSpooler.Domain.Shared.Results;

namespace PrintSpooler.Application.Printing.Services;

public class PrintingService : IPrintingService
{
    private readonly IFirestoreRepository _filesToPrintRepository;
    private readonly IMegaRepository _megaRepository;
    private readonly IPrinterRepository _printerRepository;

    public PrintingService(IFirestoreRepository filesToPrintRepository, IPrinterRepository printerRepository, IMegaRepository megaRepository)
    {
        _filesToPrintRepository = filesToPrintRepository;
        _printerRepository = printerRepository;
        _megaRepository = megaRepository;
    }

    public async Task<ResponseData> PrintAllFiles()
    {
        try
        {
            var filesToPrint = await _filesToPrintRepository.GetFilesToPrint();

            if (filesToPrint is null || !filesToPrint.Any()) return ResponseData.Sucesso("No files to print.");

            foreach (var file in filesToPrint)
            {
                if (string.IsNullOrEmpty(file.FileUrl)) continue;

                var filePath = await _megaRepository.DownloadFile(file.FileUrl);

                _printerRepository.PrintFile(filePath, file.PrinterName);
            }

            return ResponseData.Sucesso("No files to print.");
        }
        catch (Exception ex)
        {
            return ResponseData.Sucesso($"An error occurred while trying to print the files. {ex.Message}");
        }
    }
}