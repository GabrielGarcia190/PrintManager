using Optima.Domain.Users.Entities;

namespace Optima.Domain.Users.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Delete(Guid id);
    User GetById(Guid id);
}