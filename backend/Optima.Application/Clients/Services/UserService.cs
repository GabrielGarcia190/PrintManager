
using Optima.Application.Clients.Interfaces;
using Optima.Domain.Users.Entities;
using Optima.Domain.Users.Repositories;

namespace Optima.Application.Clients.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
        => _repository = repository;

    public void AddUser(string name, string email)
        => _repository.Add(new User(name, email));
}