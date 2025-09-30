using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrintSpooler.Application.Mega.Interfaces;

namespace PrintSpooler.Api.Controllers;

[ApiController]
[Route("api/mega")]
public class MegaApiController : ControllerBase
{
    [HttpGet("teste")]
    public async Task<IActionResult> Teste([FromServices] IMegaService printJobService)
    {
        var result = await printJobService.UploadFile();

        return Ok(result);
    }

    // [HttpGet("teste2")]
    // public IActionResult Teste2([FromServices] IMegaService printJobService)
    // {
    //     var result = printJobService.DownloadFile();

    //     return Ok(result);
    // }


}