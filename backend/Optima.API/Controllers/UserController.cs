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
    [ProducesResponseType(400)]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest userRequest, [FromServices] IUserService service)
    {
        try
        {
            var command = new CreateUserCommand
            {
                Name = userRequest.Name,
                Email = userRequest.Email
            };

            var user = await service.AddUserAsync(command);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Get(Guid id, [FromServices] IUserService service)
    {
        var user = await service.GetByIdAsync(id);

        if (user == null)
            return NotFound(new { Message = "Usuário não encontrado" });

        return Ok(user);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll(
         [FromServices] IUserService service,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var users = await service.GetAllAsync(page, pageSize);
        var totalCount = await service.GetTotalCountAsync();

        return Ok(new
        {
            Data = users,
            Pagination = new
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            }
        });
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(Guid id, [FromServices] IUserService service)
    {
        try
        {
            await service.DeleteAsync(id);
            return Ok(new { Message = "Usuário deletado com sucesso" });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }
}