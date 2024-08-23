using HumanResources.Data.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HumanResources.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(long id);
        IQueryable<TEntity> GetAsTracking(long id);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Use this in a manual transaction if a transaction is needed because this function executes immediately.
        /// This function does not work with the change tracker, it may cause unexpected behaviour if used with it. (You do not need to call commit after using this function)
        /// </summary>
        Task UpdateAsync(Expression<Func<TEntity, bool>> query, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression);
        /// <summary>
        /// Use this in a manual transaction if a transaction is needed because this function executes immediately.
        /// This function does not work with the change tracker, it may cause unexpected behaviour if used with it. (You do not need to call commit after using this function)
        /// </summary>
        Task HardDelete(Expression<Func<TEntity, bool>> query);
    }
}
