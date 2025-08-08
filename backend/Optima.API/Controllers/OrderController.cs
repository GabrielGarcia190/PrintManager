using Microsoft.AspNetCore.Mvc;
using Optima.API.Models.Requests;
using Optima.Application.Orders.Commands;
using Optima.Application.Orders.Interfaces;
namespace Optima.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(200)]
    public IActionResult Post([FromBody] CreteOrderRequest userRequest, [FromServices] IOrderService service)
    {

        var command = new CreateOrderCommand(userRequest.UserId, userRequest.TotalOrder);

        service.AddOrder(command);

        return Ok(new { Message = "User added successfully" });
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public IActionResult GetAll([FromServices] IOrderService service)
    {

        var orders = service.GetAll();

        return Ok(orders);
    }
}