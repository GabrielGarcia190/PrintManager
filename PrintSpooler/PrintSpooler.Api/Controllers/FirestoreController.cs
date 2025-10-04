using Microsoft.AspNetCore.Mvc;
using PrintSpooler.Application.Files.Interfaces;
using PrintSpooler.Application.Printers.Interfaces;
using PrintSpooler.Application.Printing.Interfaces;

namespace PrintSpooler.Api.Controllers;

[Route("api/files-to-print")]
[ApiController]
public class FilestoPrintController : ControllerBase
{
    [HttpGet("query-firestore")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetFirestore([FromServices] IFilesToPrintService printJobService)
    {
        var filesToPrint = await printJobService.GetFilesToPrint();

        return Ok(filesToPrint);
    }

    [HttpGet("query-a")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> a([FromServices] IPrintingService printJobService)
    {
        await printJobService.PrintAllFiles();

        return Ok();
    }
}