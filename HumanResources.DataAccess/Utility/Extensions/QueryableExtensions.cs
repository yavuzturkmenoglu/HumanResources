using Microsoft.EntityFrameworkCore;

namespace HumanResources.DataAccess.Utility.Extensions
{
    public static class QueryableExtensions
    {
        public static Task<T> FetchAsync<T>(this IQueryable<T> queryable)
        {
            return queryable.FirstOrDefaultAsync();
        }

        public static Task<List<T>> FetchListAsync<T>(this IQueryable<T> queryable)
        {
            return queryable.ToListAsync();
        }

        //public static Task<bool> FetchAnyAsync<T>(this IQueryable<T> queryable)
        //{
        //    return queryable.AnyAsync();
        //}
    }
}
