using Optima.Domain.Users.Entities;

namespace Optima.Domain.Users.Repositories;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync(int page = 1, int pageSize = 10);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsAsync(Guid id);
    Task<int> GetTotalCountAsync();
}