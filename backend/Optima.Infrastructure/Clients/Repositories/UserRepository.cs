using Optima.Domain.Users.Entities;
using Optima.Domain.Users.Repositories;

namespace Optima.Infrastructure.Clients.Repositories;

public class UserRepository : IUserRepository
{
    public void Add(User user)
        => Console.WriteLine($"User {user.Name} with email {user.Email} added to the repository.");
}