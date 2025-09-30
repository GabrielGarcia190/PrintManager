using CG.Web.MegaApiClient;
using PrintSpooler.Domain.Mega;

namespace PrintSpooler.Infrastructure.Mega;

public class MegaRepository : IMegaRepository
{
    private readonly MegaApiClient _megaApiClient;

    public MegaRepository()
        => _megaApiClient = new MegaApiClient();

    public async Task DownloadFile(string urlFile)
    {
        await Login();

        var uri = new Uri(urlFile);
        var nodes = _megaApiClient.GetNodesFromLink(uri);
        var node = nodes.Single(n => n.Type == NodeType.File);

        _megaApiClient.DownloadFile(node, Path.Combine(Environment.CurrentDirectory, "DonwloadedFiles"));

        await Logout();
    }

    public async Task<string> UploadFile()
    {
        try
        {
            await Login();

            var filePath = Path.Combine(@"C:\dev\PrintManager\PrintSpooler", "SampleFile.txt");

            var root = _megaApiClient.GetNodes().Single(n => n.Type == NodeType.Root);
            var uploadedNode = await _megaApiClient.UploadFileAsync(filePath, root);

            var urlFile = await _megaApiClient.GetDownloadLinkAsync(uploadedNode);

            await Logout();

            return urlFile.ToString();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private async Task Logout()
        => await _megaApiClient.LogoutAsync();

    private async Task Login()
     => await _megaApiClient.LoginAnonymousAsync();
}