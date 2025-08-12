
using Optima.Application.Users.Commands;
using Optima.Domain.Users.Entities;

namespace Optima.Application.Users.Interfaces;

public interface IUserService
{
    Task<User> AddUserAsync(CreateUserCommand command);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync(int page = 1, int pageSize = 10);
    Task<User?> GetByIdAsync(Guid id);
    Task<int> GetTotalCountAsync();
}