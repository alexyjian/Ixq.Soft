using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ixq.Soft.Mvc.UI
{
    /// <summary>
    ///     列表页面。
    /// </summary>
    public class ListPages : IListPages
    {
        public ListPages()
        {
            PageIndex = 1;
            PageSize = 30;
            PageSizeList = new PageSizeList {15, 30, 60, 90};
            CustomButtons = new List<CustomButton>();
        }
        public ModelMetadata ModelMetadata { get; set; }
        public PageSizeList PageSizeList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public IList<CustomButton> CustomButtons { get; set; }
    }

    /// <summary>
    ///     列表页面接口。
    /// </summary>
    public interface IListPages
    {
        /// <summary>
        ///     获取或设置模型元数据。
        /// </summary>
        ModelMetadata ModelMetadata { get; set; }

        /// <summary>
        ///     获取或设置页面大小集合。
        /// </summary>
        PageSizeList PageSizeList { get; set; }

        /// <summary>
        ///     获取或设置页面大小。
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        ///     获取或设置当前页。
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        ///     获取或设置排序字段名称。
        /// </summary>
        string SortField { get; set; }

        /// <summary>
        ///     获取或设置排序方向。
        /// </summary>
        string SortDirection { get; set; }

        /// <summary>
        ///     获取或设置自定义按钮。
        /// </summary>
        IList<CustomButton> CustomButtons { get; set; }
    }
}