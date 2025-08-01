using Microsoft.AspNetCore.Mvc;
using Optima.Application.Clients.Interfaces;

namespace Optima.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] UserDto user, [FromServices] IUserService service)
    {
        service.AddUser("John Doe", "test");

        return Created("User added successfully", null);
    }
}
public class UserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
}