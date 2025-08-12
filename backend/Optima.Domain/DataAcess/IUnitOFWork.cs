namespace Optima.Domain.DataAccess;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
    void Commit();
}