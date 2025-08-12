using Microsoft.EntityFrameworkCore;
using Optima.Domain.Users.Entities;
using Optima.Domain.Users.Repositories;
using Optima.Infrastructure.DataAcess;

namespace Optima.Infrastructure.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly OptimaDbContext _dbContext;

    public UserRepository(OptimaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<User> AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return user;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync(int page = 1, int pageSize = 10)
    {
        return await _dbContext.Users
            .Where(u => u.IsActive)
            .OrderBy(u => u.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id && u.IsActive);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Users
            .AnyAsync(u => u.Id == id && u.IsActive);
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _dbContext.Users
            .CountAsync(u => u.IsActive);
    }
}