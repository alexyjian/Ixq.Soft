using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Linq;
using Ixq.Soft.Core.Threading;

namespace Ixq.Soft.Core.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        ///     根据指定的方向排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="propertyName"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderByDirection<T>(this IQueryable<T> queryable, string propertyName,
            ListSortDirection direction)
        {
            dynamic keySelector = ExpressionHelper.GetKeySelector<T>(propertyName);

            if (direction == ListSortDirection.Ascending) return Queryable.OrderBy(queryable, keySelector);

            return Queryable.OrderByDescending(queryable, keySelector);
        }

        /// <summary>
        ///     升序排序。
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
        ///     降序排序。
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

        /// <summary>
        ///     将指定的 <paramref name="queryable" /> 转换为 <see cref="PagedList{T}" />。
        /// </summary>
        /// <typeparam name="T">返回的数据类型。</typeparam>
        /// <param name="queryable">源数据。</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> queryable, int pageIndex, int pageSize)
        {
            return new PagedList<T>(queryable, pageIndex, pageSize);
        }

        /// <summary>
        ///     将指定的 <paramref name="queryable" /> 转换为 <see cref="PagedList{T}" />。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> queryable, int pageIndex,
            int pageSize)
        {
            return await TaskHelper.Run(() => ToPagedList(queryable, pageIndex, pageSize));

            //var totalRecords = await queryable.CountAsync();

            //var list = await queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            //return new PagedList<T>(list, totalRecords, pageIndex, pageSize);
        }
    }
}