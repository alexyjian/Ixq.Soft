using System.Linq;
using Ixq.Soft.Core.Linq;

namespace Ixq.Soft.Core.Extensions
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
    }
}
