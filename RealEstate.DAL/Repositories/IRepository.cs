using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task AddAsync(TEntity entity);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> where, int limit, int page);
        Task<TEntity> GetIncludingAll(Expression<Func<TEntity, bool>> where);
    }
}
