using PrintSpooler.Domain.Files.Entities;

namespace PrintSpooler.Application.Files.Interfaces;

public interface IFilesToPrintService
{
    Task<IEnumerable<FileToPrint>> GetFilesToPrint();
}