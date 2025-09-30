namespace PrintSpooler.Application.Mega.Interfaces;

public interface IMegaService
{
    Task DownloadFile(string urlFile);
    Task<string> UploadFile();
}