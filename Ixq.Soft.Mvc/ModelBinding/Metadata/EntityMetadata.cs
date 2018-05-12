using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public class EntityMetadata
    {
        /// <summary>
        ///     获取或设置一个值，指示页面的标题。
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        ///     获取或设置一个值，表示获取数据的控制器 action，默认是 List.
        /// </summary>
        public string ListAction { get; set; } = "List";

        /// <summary>
        ///     获取或设置一个值，表示表单提交的控制器 action，默认是 Edit.
        /// </summary>
        public string EditAction { get; set; } = "Edit";

        /// <summary>
        ///     获取或设置一个值，表示删除元素时的控制器 action，默认是 Delete.
        /// </summary>
        public string DeleteAction { get; set; } = "Delete";

        /// <summary>
        ///     获取或设置一个值，指示模型值是否用于页面搜索字段。
        /// </summary>
        public bool IsSearcher { get; set; }

        /// <summary>
        ///     获取或设置一个值，指示数据的排序字段。
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        ///     获取或设置一个值，指示数据的排序方向。
        /// </summary>
        public ListSortDirection SortDirection { get; set; }

    }
}