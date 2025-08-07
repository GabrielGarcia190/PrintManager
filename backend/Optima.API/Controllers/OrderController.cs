using Microsoft.AspNetCore.Mvc;
using Optima.API.Models.Requests;
using Optima.Application.Orders.Interfaces;
using Optima.Domain.Orders.Entities;

namespace Optima.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(200)]
    public IActionResult Post([FromBody] CreteOrderRequest userRequest, [FromServices] IOrderService service)
    {
        var order = new Order(userRequest.UserId, userRequest.TotalOrder);

        service.AddOrder(order);

        return Ok(new { Message = "User added successfully" });
    }
}