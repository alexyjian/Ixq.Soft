using System.Collections.Generic;
using System.ComponentModel;
using Ixq.Soft.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ixq.Soft.Mvc.UI
{
    /// <summary>
    ///     列表页面。
    /// </summary>
    public class ListPageModel : IListPageModel
    {
        public ListPageModel()
        {
            PageIndex = 1;
            PageSize = 30;
            PageSizeList = new PageSizeList {15, 30, 60, 90};
            CustomButtons = new List<CustomButton>();
        }

        public string PageTitle { get; set; }
        public string ListAction { get; set; }
        public string EditAction { get; set; }
        public string DeleteAction { get; set; }
        public ModelMetadata ModelMetadata { get; set; }
        public PageSizeList PageSizeList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortField { get; set; }
        public ListSortDirection SortDirection { get; set; }
        public string SortDirectionName => SortDirection == ListSortDirection.Ascending ? "asc" : "desc";
        public IList<CustomButton> CustomButtons { get; set; }
    }

    /// <summary>
    ///     列表页面接口。
    /// </summary>
    public interface IListPageModel : IPageConfig
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
        ///     获取或设置自定义按钮。
        /// </summary>
        IList<CustomButton> CustomButtons { get; set; }
    }
}