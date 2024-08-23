using HumanResources.Data.Entities;
using HumanResources.DataAccess.EntityFramework;
using HumanResources.DataAccess.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HumanResources.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly Context _context;
        protected readonly DateTime _now;

        public Repository(Context context)
        {
            _context = context;
            _now = DateTime.UtcNow;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Where(x => !x.IsDeleted);
        }

        public IQueryable<TEntity> Get(long id)
        {
            return _context.Set<TEntity>().Where(x => !x.IsDeleted && x.Id == id);
        }

        public IQueryable<TEntity> GetAsTracking(long id)
        {
            return _context.Set<TEntity>().Where(x => !x.IsDeleted && x.Id == id).AsTracking();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task UpdateAsync(Expression<Func<TEntity, bool>> query, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression)
        {
            await _context.Set<TEntity>().Where(query).Where(x => !x.IsDeleted).ExecuteUpdateAsync(expression.MergeWithAnd(x => x.SetProperty(x => x.UpdatedAt, _now)));
        }

        public async Task HardDelete(Expression<Func<TEntity, bool>> query)
        {
            //_context.Set<TEntity>().Remove(new TEntity { Id = id });
            await _context.Set<TEntity>().ExecuteDeleteAsync();
        }
    }
}
