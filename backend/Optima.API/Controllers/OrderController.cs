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
    [ProducesResponseType(400)]
    public async Task<IActionResult> Post([FromBody] CreateOrderRequest orderRequest, [FromServices] IOrderService service)
    {
        try
        {
            var command = new CreateOrderCommand(orderRequest.UserId, orderRequest.TotalOrder);
            await service.AddOrderAsync(command);

            return Ok(new { Message = "Pedido criado com sucesso" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll([FromServices] IOrderService service)
    {
        var orders = await service.GetAllAsync();
        return Ok(orders);
    }
}