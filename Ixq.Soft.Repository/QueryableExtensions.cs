using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.Repository
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName)
        {
            dynamic keySelector = ExpressionHelper.GetKeySelector<T>(propertyName);
            return Queryable.OrderBy(queryable, keySelector);
        }

        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> queryable, string propertyName)
        {
            dynamic keySelector = ExpressionHelper.GetKeySelector<T>(propertyName);
            return Queryable.OrderByDescending(queryable, keySelector);
        }

        public static PagingList<T> PagingList<T>(this IQueryable<T> queryable, int pageIndex, int pageSize)
        {
            return new PagingList<T>(queryable, pageIndex, pageSize);
        }

        public static async Task<PagingList<T>> PagingListAsync<T>(this IQueryable<T> queryable, int pageIndex,
            int pageSize)
        {
            var totalRecords = await queryable.CountAsync();

            var list = await queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagingList<T>(list, totalRecords, pageIndex, pageSize);
        }
    }
}
