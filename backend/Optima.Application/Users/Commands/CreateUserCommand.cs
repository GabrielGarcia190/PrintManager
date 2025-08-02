namespace Optima.Application.Users.Commands;

public class CreateUserCommand
{
    public string Name { get; init; } = null!;
    public string Email { get; init; } = null!;
}