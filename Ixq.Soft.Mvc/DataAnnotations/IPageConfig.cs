using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ixq.Soft.Mvc.DataAnnotations
{
    public interface IPageConfig
    {
        /// <summary>
        ///     获取或设置一个值，表示获取列表数据的控制器 action.
        /// </summary>
        string ListAction { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示表单提交的控制器 action.
        /// </summary>
        string EditAction { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示删除元素时的控制器 action.
        /// </summary>
        string DeleteAction { get; set; }

        /// <summary>
        ///     获取或设置一个值，指示数据的排序字段。
        /// </summary>
        string SortField { get; set; }

        /// <summary>
        ///     获取或设置一个值，指示数据的排序方向。
        /// </summary>
        ListSortDirection SortDirection { get; set; }

    }
}