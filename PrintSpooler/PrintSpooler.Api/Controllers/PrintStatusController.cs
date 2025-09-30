using Microsoft.AspNetCore.Mvc;
using PrintSpooler.Application.Printers.Interfaces;

namespace PrintSpooler.Api.Controllers;

[Route("api/printers")]
[ApiController]
public class PrintStatusController : ControllerBase
{
    //IMPLEMETAR PARA PEGAR SE O SPOOLER ESTÁ RODANDO
    [HttpGet("status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Get()
        => Ok("Api is running");

    [HttpGet("get-printers")]
    public IActionResult GetInstalledPrinters([FromServices] IPrinterService printJobService)
    {
        var result = printJobService.GetInstalledPrinters();

        return Ok(result);
    }

    [HttpGet("get-spooler-status")]
    public IActionResult GetSpoolerStatus([FromServices] IPrinterService printJobService)
    {
        var result = printJobService.GetSpoolerStatus();

        return Ok(result);
    }

    [HttpGet("query-firestore")]
    public async Task<IActionResult> GetFirestore([FromServices] IPrinterService printJobService)
    {
        var filesToPrint = await printJobService.GetFilesToPrint();

        return Ok(filesToPrint);
    }
}