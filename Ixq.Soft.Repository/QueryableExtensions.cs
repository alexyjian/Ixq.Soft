using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.Repository
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 根据指定的方向排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="propertyName"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderByDirection<T>(this IQueryable<T> queryable, string propertyName,
            System.ComponentModel.ListSortDirection direction)
        {
            dynamic keySelector = ExpressionHelper.GetKeySelector<T>(propertyName);

            if (direction == System.ComponentModel.ListSortDirection.Ascending)
            {
                return Queryable.OrderBy(queryable, keySelector);
            }

            return Queryable.OrderByDescending(queryable, keySelector);
        }

        /// <summary>
        /// 升序排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName)
        {
            dynamic keySelector = ExpressionHelper.GetKeySelector<T>(propertyName);
            return Queryable.OrderBy(queryable, keySelector);
        }

        /// <summary>
        /// 降序排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> queryable, string propertyName)
        {
            dynamic keySelector = ExpressionHelper.GetKeySelector<T>(propertyName);
            return Queryable.OrderByDescending(queryable, keySelector);
        }

        public static PagingList<T> ToPagingList<T>(this IQueryable<T> queryable, int pageIndex, int pageSize)
        {
            return new PagingList<T>(queryable, pageIndex, pageSize);
        }

        public static async Task<PagingList<T>> ToPagingListAsync<T>(this IQueryable<T> queryable, int pageIndex,
            int pageSize)
        {
            var totalRecords = await queryable.CountAsync();

            var list = await queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagingList<T>(list, totalRecords, pageIndex, pageSize);
        }
    }
}
