using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public class EntityModelMetadataProvider : DefaultModelMetadataProvider
    {
        public EntityModelMetadataProvider(
            ICompositeMetadataDetailsProvider detailsProvider) : base(
            detailsProvider)
        {
        }

        public EntityModelMetadataProvider(
            ICompositeMetadataDetailsProvider detailsProvider,
            IOptions<MvcOptions> optionsAccessor) : base(detailsProvider, optionsAccessor)
        {
        }

        protected override ModelMetadata CreateModelMetadata(DefaultMetadataDetails entry)
        {
            var detailsProvider = DetailsProvider as ICompositeMetadataDetailsProvider;
            return new EntityModelMetadata(this, detailsProvider, ConvertMetadataDetails(entry),
                ModelBindingMessageProvider);
        }

        protected virtual EntityMetadataDetails ConvertMetadataDetails(DefaultMetadataDetails details)
        {
            var entityDetails = new EntityMetadataDetails(details.Key, details.ModelAttributes);
            entityDetails.ContainerMetadata = details.ContainerMetadata;
            entityDetails.PropertyGetter = details.PropertyGetter;
            entityDetails.PropertySetter = details.PropertySetter;
            entityDetails.Properties = entityDetails.Properties;
            return entityDetails;
        }
    }
}
