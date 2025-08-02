using Optima.Domain.DataAcess;

namespace Optima.Infrastructure.DataAcess
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly OptimaDbContext _dbContext;

        public UnitOfWork(OptimaDbContext dbContext)
         => _dbContext = dbContext;

        public void Commit()
         => _dbContext.SaveChanges();
       
    }
}