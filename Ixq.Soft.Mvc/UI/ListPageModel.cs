using System;
using System.Collections.Generic;
using System.ComponentModel;
using Ixq.Soft.Mvc.DataAnnotations;
using Ixq.Soft.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ixq.Soft.Mvc.UI
{
    /// <summary>
    ///     列表页面。
    /// </summary>
    public class ListPageModel : IListPageModel
    {
        private readonly EntityMetadata _entityMetadata;

        public ListPageModel(EntityMetadata entityMetadata) : this()
        {
            _entityMetadata = entityMetadata ?? throw new ArgumentNullException(nameof(entityMetadata));
        }

        private ListPageModel()
        {
            PageIndex = 1;
            PageSize = 30;
            PageSizeList = new PageSizeList {15, 30, 60, 90};
            CustomButtons = new List<CustomButton>();
        }

        public string PageTitle
        {
            get => _entityMetadata.PageTitle;
            set => _entityMetadata.PageTitle = value;
        }

        public string ListAction
        {
            get => _entityMetadata.ListAction;
            set => _entityMetadata.ListAction = value;
        }

        public string EditAction
        {
            get => _entityMetadata.EditAction;
            set => _entityMetadata.EditAction = value;
        }

        public string DeleteAction
        {
            get => _entityMetadata.DeleteAction;
            set => _entityMetadata.DeleteAction = value;
        }

        public ModelMetadata ModelMetadata { get; set; }
        public PageSizeList PageSizeList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public string SortField
        {
            get => _entityMetadata.SortField;
            set => _entityMetadata.SortField = value;
        }

        public ListSortDirection SortDirection
        {
            get => _entityMetadata.SortDirection;
            set => _entityMetadata.SortDirection = value;
        }

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