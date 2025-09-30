using PrintSpooler.Application.Mega.Interfaces;
using PrintSpooler.Domain.Mega;

namespace PrintSpooler.Application.Mega.Services;

public class MegaService : IMegaService
{
    private readonly IMegaRepository _megaRepository;

    public MegaService(IMegaRepository megaRepository)
     => _megaRepository = megaRepository;

    public Task DownloadFile(string urlFile)
     => _megaRepository.DownloadFile(urlFile);

    public Task<string> UploadFile()
     => _megaRepository.UploadFile();
}