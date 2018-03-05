using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public class EntityModelMetadata : DefaultModelMetadata
    {
        public EntityModelMetadata(IModelMetadataProvider provider, ICompositeMetadataDetailsProvider detailsProvider,
            DefaultMetadataDetails details) : base(provider, detailsProvider, details)
        {
        }

        public EntityModelMetadata(IModelMetadataProvider provider, ICompositeMetadataDetailsProvider detailsProvider,
            DefaultMetadataDetails details, DefaultModelBindingMessageProvider modelBindingMessageProvider) : base(
            provider, detailsProvider, details, modelBindingMessageProvider)
        {
        }


        /// <summary>
        ///     获取一个值，指示模型值是否用于页面搜索字段。
        /// </summary>
        public bool IsSearcher { get; }
    }
}
