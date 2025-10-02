using PrintSpooler.Domain.Files.Entities;

namespace PrintSpooler.Domain.Files.Repositories;

public interface IFirestoreRepository
{
    Task<IEnumerable<FileToPrint>> GetFilesToPrint();
}