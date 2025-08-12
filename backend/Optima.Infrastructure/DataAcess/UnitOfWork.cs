using Optima.Domain.DataAccess;

namespace Optima.Infrastructure.DataAcess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OptimaDbContext _dbContext;

        public UnitOfWork(OptimaDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<int> CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Commit()
            => _dbContext.SaveChanges();
    }
}