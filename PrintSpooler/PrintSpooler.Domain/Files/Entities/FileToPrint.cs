
using Google.Cloud.Firestore;
using PrintSpooler.Domain.Files.Enuns;

namespace PrintSpooler.Domain.Files.Entities;

[FirestoreData]
public class FileToPrint
{
    [FirestoreProperty]
    public string? FileExtension { get; set; }

    [FirestoreProperty]
    public string? FileLenght { get; set; }

    [FirestoreProperty]
    public string? FileName { get; set; }

    [FirestoreProperty]
    public string? FileUrl { get; set; }

    [FirestoreProperty]
    public string? PrinterName { get; set; }

    [FirestoreProperty]
    public EStatusFile Status { get; set; }

    [FirestoreProperty]
    public string? User { get; set; }

    [FirestoreProperty]
    public Timestamp CreateAt { get; set; }

    [FirestoreProperty]
    public Timestamp UpdatedAt { get; set; }
}