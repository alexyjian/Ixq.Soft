using System.ComponentModel;
using Ixq.Soft.Mvc.UI;
using Ixq.Soft.Mvc.UI.jqGrid;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public class EntityModelMetadata : DefaultModelMetadata
    {
        private readonly EntityMetadataDetails _details;
        private readonly ICompositeMetadataDetailsProvider _detailsProvider;

        public EntityModelMetadata(IModelMetadataProvider provider, ICompositeMetadataDetailsProvider detailsProvider,
            EntityMetadataDetails details) : base(provider, detailsProvider, details)
        {
            _details = details;
            _detailsProvider = detailsProvider;
        }

        public EntityModelMetadata(IModelMetadataProvider provider, ICompositeMetadataDetailsProvider detailsProvider,
            EntityMetadataDetails details, DefaultModelBindingMessageProvider modelBindingMessageProvider) : base(
            provider, detailsProvider, details, modelBindingMessageProvider)
        {
            _details = details;
            _detailsProvider = detailsProvider;
        }

        public EntityMetadata EntityMetadata
        {
            get
            {
                if (_details.EntityMetadata == null)
                {
                    var content = new EntityMetadataProviderContext(Identity, _details.ModelAttributes);
                    _detailsProvider.CreateEntityMetadata(content);
                    _details.EntityMetadata = content.EntityMetadata;
                }

                return _details.EntityMetadata;
            }
        }

        public JqGridMetadata JqGridMetadata
        {
            get
            {
                if (_details.JqGridMetadata == null)
                {
                    var content = new JqGridMetadataProviderContext(Identity, _details.ModelAttributes);
                    _detailsProvider.CreateJqGridMetadata(content);
                    _details.JqGridMetadata = content.JqGridMetadata;
                }

                return _details.JqGridMetadata;
            }
        }

        /// <summary>
        ///     获取一个值，指示页面的标题。
        /// </summary>
        public string PageTitle => EntityMetadata.PageTitle;

        /// <summary>
        ///     获取或设置一个值，表示获取列表数据的控制器 action.
        /// </summary>
        public string ListAction => EntityMetadata.ListAction;

        /// <summary>
        ///     获取或设置一个值，表示表单提交的控制器 action.
        /// </summary>
        public string EditAction => EntityMetadata.EditAction;

        /// <summary>
        ///     获取一个值，表示删除元素时的控制器 action.
        /// </summary>
        public string DeleteAction => EntityMetadata.DeleteAction;

        /// <summary>
        ///     获取一个值，指示模型值是否用于页面搜索字段。
        /// </summary>
        public bool IsSearcher => EntityMetadata.IsSearcher;

        /// <summary>
        ///     获取一个值，指示数据的排序字段。
        /// </summary>
        public string SortField => EntityMetadata.SortField;

        /// <summary>
        ///     获取一个值，指示数据的排序方向。
        /// </summary>
        public ListSortDirection SortDirection => EntityMetadata.SortDirection;

        /// <summary>
        ///     获取一个值，表示与后台交互的参数。
        /// </summary>
        public string Index => JqGridMetadata.Index;

        /// <summary>
        ///     获取一个值，表示表格列的名称。
        /// </summary>
        public string JqPropertyName => JqGridMetadata.Name;

        /// <summary>
        ///     获取一个值，表示css样式类。
        /// </summary>
        public string CssClass => JqGridMetadata.CssClass;

        /// <summary>
        ///     获取一个值，表示单元格列宽。
        /// </summary>
        public int Width => JqGridMetadata.Width;

        /// <summary>
        ///     获取一个值，表示单元格内容的对齐方式。
        /// </summary>
        public TextAlign Align => JqGridMetadata.Align;

        /// <summary>
        ///     获取一个值，表示字段值的显示格式。
        /// </summary>
        public string DataFormatString => JqGridMetadata.DataFormatString;

        /// <summary>
        ///     获取一个值，表示格式化 Javascript 脚本。
        /// </summary>
        public string FormatterScript => JqGridMetadata.FormatterScript;

        /// <summary>
        ///     获取一个值，表示反格式化 Javascript 脚本。
        /// </summary>
        public string UnFormatterScript => JqGridMetadata.UnFormatterScript;

        /// <summary>
        ///     获取一个值，表示是否可排序。
        /// </summary>
        public bool Sortable => JqGridMetadata.Sortable;

        /// <summary>
        ///     获取一个值，表示在列表中否要隐藏此属性。
        /// </summary>
        public bool ShowForList => JqGridMetadata.ShowForList;
    }
}