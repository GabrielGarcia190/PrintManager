using PrintSpooler.Application.Files.Interfaces;
using PrintSpooler.Domain.Files.Entities;
using PrintSpooler.Domain.Files.Repositories;

namespace PrintSpooler.Application.Files.Services;

public class FilesToPrintService : IFilesToPrintService
{
    private readonly IFilesToPrintRepository _printerRepository;

    public FilesToPrintService(IFilesToPrintRepository printerRepository)
     => _printerRepository = printerRepository;

    public async Task<IEnumerable<FileToPrint>> GetFilesToPrint()
     => await _printerRepository.GetFilesToPrint();
}