using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.EF;

namespace RealEstate.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly RedbContext _dbContext;

        public Repository(DbSet<TEntity> dbSet, RedbContext context)
        {
            _dbSet = dbSet;
            _dbContext = context;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(where);
            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> where, int limit, int page)
        {
            return await _dbSet.Where(where).Skip(limit * page).Take(limit).ToListAsync();
        }

        public TEntity GetIncludingAll(Expression<Func<TEntity, bool>> where)
        {
            var query = _dbSet.AsQueryable();
            query = _dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations().Aggregate(query, (current, property) => current.Include(property.Name));
            return query.FirstOrDefault(where);
        }

    }
}
