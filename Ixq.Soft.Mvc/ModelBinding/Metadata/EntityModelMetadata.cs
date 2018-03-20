using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Mvc.UI.jqGrid;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

                    _details.JqGridMetadata = content.JqGridMetadata;
                }

                return _details.JqGridMetadata;
            }
        }

        /// <summary>
        ///     获取一个值，指示模型值是否用于页面搜索字段。
        /// </summary>
        public bool IsSearcher => EntityMetadata.IsSearcher;
    }
}
