using PrintSpooler.Application.Files.Interfaces;
using PrintSpooler.Domain.Files.Entities;
using PrintSpooler.Domain.Files.Repositories;

namespace PrintSpooler.Application.Files.Services;

public class FilesToPrintService : IFilesToPrintService
{
    private readonly IFirestoreRepository _printerRepository;

    public FilesToPrintService(IFirestoreRepository printerRepository)
     => _printerRepository = printerRepository;

    public async Task<IEnumerable<FileToPrint>> GetFilesToPrint()
     => await _printerRepository.GetFilesToPrint();
}