using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core
{
    public interface IPagingList<T> : IPagingList, IList<T>
    {
        
    }

    public interface IPagingList
    {
        /// <summary>
        ///     获取页面大小。
        /// </summary>
        int PageSize { get; }

        /// <summary>
        ///     获取当前页面。
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        ///     获取总页面数。
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        ///     获取总记录数。
        /// </summary>
        int TotalRecords { get; }

        /// <summary>
        ///     获取一个值，表示是否有上一页。
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        ///     获取一个值，表示是否有下一页。
        /// </summary>
        bool HasNextPage { get; }
    }
}
