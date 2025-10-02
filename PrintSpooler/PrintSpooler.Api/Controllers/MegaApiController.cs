using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrintSpooler.Application.Mega.Interfaces;

namespace PrintSpooler.Api.Controllers;

[ApiController]
[Route("api/mega")]
public class MegaApiController : ControllerBase
{
    [HttpGet("teste2")]
    public async Task<IActionResult> Teste2([FromServices] IMegaService printJobService)
    {
       await printJobService.DownloadFile(urlFile: "https://mega.nz/file/SjQViL6S#r3uVwmJbTsyyHuSHiuZCyOjijDCEOSn0VEjKRVuQFGs");

        return Ok();
    }
}