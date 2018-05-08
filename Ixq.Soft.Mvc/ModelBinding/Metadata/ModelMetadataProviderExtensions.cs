using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Mvc.UI;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public static class ModelMetadataProviderExtensions
    {
        public static IListPageModel GetListPageModel(this IModelMetadataProvider provider, Type modelType)
        {
            var metadata = provider.GetMetadataForType(modelType);
            EntityMetadata entityMetadata = null;
            if (metadata is EntityModelMetadata entityModelMetadata)
            {
                entityMetadata = entityModelMetadata.EntityMetadata;
            }

            IListPageModel pageModel = new ListPageModel(entityMetadata ?? new EntityMetadata());
            pageModel.ModelMetadata = metadata;
            return pageModel;
        }

        public static IListPageModel GetListPageModel<T>(this IModelMetadataProvider provide)
        {
            return GetListPageModel(provide, typeof(T));
        }
    }
}
