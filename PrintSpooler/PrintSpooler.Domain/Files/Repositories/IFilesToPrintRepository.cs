using PrintSpooler.Domain.Files.Entities;

namespace PrintSpooler.Domain.Files.Repositories;

public interface IFilesToPrintRepository
{
    Task<IEnumerable<FileToPrint>> GetFilesToPrint();
}