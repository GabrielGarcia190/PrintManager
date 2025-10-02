using Microsoft.AspNetCore.Mvc;
using PrintSpooler.Application.Printers.Interfaces;

namespace PrintSpooler.Api.Controllers;

[Route("api/printers")]
[ApiController]
public class PrintStatusController : ControllerBase
{
    [HttpGet("status")]
    [ProducesResponseType(200)]
    public IActionResult Get()
        => Ok("Api is running");

    [HttpGet("get-printers")]
    public IActionResult GetInstalledPrinters([FromServices] IPrinterService printJobService)
    {
        var result = printJobService.GetInstalledPrinters();

        return Ok(result);
    }

    [HttpGet("get-spooler-status")]
    [ProducesResponseType(200)]
    public IActionResult GetSpoolerStatus([FromServices] IPrinterService printJobService)
    {
        var result = printJobService.GetSpoolerStatus();

        return Ok(result);
    }

    [HttpPost("print-document")]
    [ProducesResponseType(200)]
    public IActionResult Print([FromServices] IPrinterService printJobService)
    {
        printJobService.PrintFile();

        return Ok();
    }
}