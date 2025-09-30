namespace PrintSpooler.Domain.Mega;

public interface IMegaRepository
{
    Task DownloadFile(string urlFile);
    Task<string> UploadFile();
}