
using Optima.Application.Users.Commands;
using Optima.Application.Users.Interfaces;
using Optima.Domain.DataAccess;
using Optima.Domain.Users.Entities;
using Optima.Domain.Users.Repositories;

namespace Optima.Application.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> AddUserAsync(CreateUserCommand command)
    {
        // Verificar se email já existe
        var existingUser = await _repository.GetByEmailAsync(command.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException($"Usuário com email {command.Email} já existe");
        }

        var user = new User(command.Name, command.Email);
        await _repository.AddAsync(user);
        await _unitOfWork.CommitAsync();
        
        return user;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
        {
            throw new InvalidOperationException($"Usuário com ID {id} não encontrado");
        }

        user.Deactivate();
        await _repository.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync(int page = 1, int pageSize = 10)
        => await _repository.GetAllAsync(page, pageSize);

    public async Task<User?> GetByIdAsync(Guid id)
        => await _repository.GetByIdAsync(id);

    public async Task<int> GetTotalCountAsync()
        => await _repository.GetTotalCountAsync();
}