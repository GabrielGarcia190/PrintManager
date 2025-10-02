using PrintSpooler.Domain.Files.Entities;
using PrintSpooler.Domain.Files.Repositories;
using PrintSpooler.Infrastructure.DataAccess;

namespace PrintSpooler.Infrastructure.Files;

public class FirestoreRepository : IFirestoreRepository
{
    private readonly FirestoreContext _context;

    public FirestoreRepository(FirestoreContext context)
        => _context = context;

    public async Task<IEnumerable<FileToPrint>> GetFilesToPrint()
    {
        var snapshot = await _context.Firestore.Collection("FilesToPrint").GetSnapshotAsync();

        var files = snapshot.Documents.Select(x => x.ConvertTo<FileToPrint>());

        return files;
    }

}