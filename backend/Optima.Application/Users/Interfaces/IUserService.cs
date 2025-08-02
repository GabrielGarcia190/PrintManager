
using Optima.Application.Users.Commands;
using Optima.Domain.Users.Entities;

namespace Optima.Application.Users.Interfaces;

public interface IUserService
{
    void AddUser(CreateUserCommand command);
    void Delete(Guid id);
    User GetById(Guid id);
}