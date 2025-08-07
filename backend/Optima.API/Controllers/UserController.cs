using Microsoft.AspNetCore.Mvc;
using Optima.API.Models.Requests;
using Optima.Application.Users.Commands;
using Optima.Application.Users.Interfaces;

namespace Optima.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(200)]
    public IActionResult Post([FromBody] CreateUserRequest userRequest, [FromServices] IUserService service)
    {
        var command = new CreateUserCommand
        {
            Name = userRequest.Name,
            Email = userRequest.Email
        };

        service.AddUser(command);

        return Ok(new { Message = "User added successfully" });
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id, [FromServices] IUserService service)
    {
        var user = service.GetById(id);

        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id, [FromServices] IUserService service)
    {
        service.Delete(id);
        
        return Ok(new { Message = "User deleted successfully" });
    }
}