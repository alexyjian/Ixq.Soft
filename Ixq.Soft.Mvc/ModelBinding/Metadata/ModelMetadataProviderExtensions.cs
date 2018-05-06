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
            IListPageModel pageModel = new ListPageModel();
            pageModel.ModelMetadata = metadata;

            if (metadata is EntityModelMetadata entityMetadata)
            {
                pageModel.ListAction = entityMetadata.ListAction;
                pageModel.EditAction = entityMetadata.EditAction;
                pageModel.DeleteAction = entityMetadata.DeleteAction;
                pageModel.SortField = entityMetadata.SortField;
                pageModel.SortDirection = entityMetadata.SortDirection;
            }

            return pageModel;
        }

        public static IListPageModel GetListPageModel<T>(this IModelMetadataProvider provide)
        {
            return GetListPageModel(provide, typeof(T));
        }
    }
}
