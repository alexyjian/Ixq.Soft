using System.ComponentModel;

namespace Ixq.Soft.Core
{
    /// <summary>
    ///     数据请求类。
    /// </summary>
    public class DataRequestModel
    {
        /// <summary>
        ///     获取或设置页面大小。
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        ///     获取或设置当前页。
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        ///     获取或设置排序字段名称。
        /// </summary>
        public string SortField { get; set; }
        /// <summary>
        ///     获取或设置排序方向。
        /// </summary>
        public string SortDirection { get; set; }

        /// <summary>
        ///     获取用 <see cref="System.ComponentModel.ListSortDirection"/> 表示的排序方向。
        /// </summary>
        public ListSortDirection ListSortDirection =>
            SortDirection.Equals("asc", System.StringComparison.OrdinalIgnoreCase)
                ? ListSortDirection.Ascending
                : ListSortDirection.Descending;
    }
}
