using System.ComponentModel;

namespace Ixq.Soft.Core
{
    /// <summary>
    ///     数据请求类。
    /// </summary>
    public class DataRequest
    {
        public DataRequest()
        {
            PageSize = 30;
            PageIndex = 1;
            SortDirection = "asc";
            QueryParam = new DataQueryParameter();
        }

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
        ///     获取或设置请求查询参数。
        ///     <para>
        ///         如果此类作用于 action 方法的参数，模型绑定器将自动从 ValueProvider 中前缀为 “search.” 的查询参数转换为字典项，并同时将字典的key去掉前缀部分。
        ///     </para>
        /// </summary>
        public DataQueryParameter QueryParam { get; set; }

        /// <summary>
        ///     获取用 <see cref="System.ComponentModel.ListSortDirection"/> 表示的排序方向。
        /// </summary>
        public ListSortDirection ListSortDirection =>
            SortDirection.Equals("asc", System.StringComparison.OrdinalIgnoreCase)
                ? ListSortDirection.Ascending
                : ListSortDirection.Descending;
    }
}
