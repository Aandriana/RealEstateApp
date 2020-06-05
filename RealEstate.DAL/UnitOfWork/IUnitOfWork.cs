using System;
using System.Threading.Tasks;
using RealEstate.DAL.Repositories;

namespace RealEstate.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable 
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
