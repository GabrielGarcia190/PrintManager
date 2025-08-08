
using Optima.Application.Users.Commands;
using Optima.Application.Users.Interfaces;
using Optima.Domain.Users.Entities;
using Optima.Domain.Users.Repositories;

namespace Optima.Application.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
     => _repository = repository;

    public void AddUser(CreateUserCommand command)
    {
        var user = new User(command.Name, command.Email);

        _repository.Add(user);
    }

    public void Delete(Guid id)
        => _repository.Delete(id);

    public IEnumerable<User> GetAll()
       => _repository.GetAll();

    public User GetById(Guid id)
        => _repository.GetById(id);
}