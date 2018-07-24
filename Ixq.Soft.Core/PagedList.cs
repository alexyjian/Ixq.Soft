using System;
using System.Collections.Generic;
using System.Linq;

namespace Ixq.Soft.Core
{
    /// <summary>
    ///     分页类。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        private PagedList(int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        public PagedList(IQueryable<T> queryable, int pageIndex, int pageSize) : this(pageIndex, pageSize)
        {
            TotalRecords = queryable.Count();
            TotalPages = (int) Math.Ceiling(TotalRecords / (double) pageSize);

            AddRange(queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        public PagedList(IEnumerable<T> queryable, int totalRecords, int pageIndex, int pageSize) : this(pageIndex,
            pageSize)
        {
            TotalRecords = totalRecords;
            TotalPages = (int) Math.Ceiling(TotalRecords / (double) pageSize);

            AddRange(queryable);
        }

        /// <summary>
        ///     获取页面大小。
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        ///     获取当前页面。
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        ///     获取总页面数。
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        ///     获取总记录数。
        /// </summary>
        public int TotalRecords { get; }

        /// <summary>
        ///     获取一个值，表示是否有上一页。
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;

        /// <summary>
        ///     获取一个值，表示是否有下一页。
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;

        /// <summary>
        ///     返回一个新的 <see cref="DataResponse" /> 对象实例。
        /// </summary>
        /// <returns></returns>
        public DataResponse ToDataResponse()
        {
            return new DataResponse(this);
        }
    }
}