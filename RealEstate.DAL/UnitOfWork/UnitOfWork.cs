using System.Threading.Tasks;
using RealEstate.DAL.EF;
using RealEstate.DAL.Repositories;

namespace RealEstate.DAL.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly RedbContext _dbContext;
        public UnitOfWork(RedbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_dbContext.Set<TEntity>());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
