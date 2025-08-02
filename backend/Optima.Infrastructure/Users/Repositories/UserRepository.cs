using Optima.Domain.Users.Entities;
using Optima.Domain.Users.Repositories;
using Optima.Infrastructure.DataAcess;

namespace Optima.Infrastructure.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly OptimaDbContext _dbContext;

    public UserRepository(OptimaDbContext dbContext)
     => _dbContext = dbContext;

    public void Add(User user)
    {
        _dbContext.Users.Add(user);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        _dbContext.Users.Remove(_dbContext.Users.First(x => x.Id == id));

        _dbContext.SaveChanges();
    }

    public User GetById(Guid id)
    {
        return _dbContext.Users.First(x => x.Id == id);
    }
}