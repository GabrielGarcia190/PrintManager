namespace PrintSpooler.Domain.Mega;

public interface IMegaRepository
{
    Task<string> DownloadFile(string urlFile);
    Task<string> UploadFile();
}