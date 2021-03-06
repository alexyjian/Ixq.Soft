﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ixq.Soft.Mvc.DataAnnotations
{
    public class PageConfigAttribute : Attribute, IPageConfig
    {
        /// <summary>
        ///     获取或设置一个值，指示页面的标题。
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示获取列表数据的控制器 action.
        /// </summary>
        public string ListAction { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示表单提交的控制器 action.
        /// </summary>
        public string EditAction { get; set; }

        /// <summary>
        ///     获取或设置一个值，表示删除元素时的控制器 action.
        /// </summary>
        public string DeleteAction { get; set; }

        /// <summary>
        ///     获取或设置一个值，指示数据的排序字段。
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        ///     获取或设置一个值，指示数据的排序方向。
        /// </summary>
        public ListSortDirection SortDirection { get; set; }

        public string SortDirectionName => SortDirection == ListSortDirection.Ascending ? "asc" : "desc";
    }
}
