using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ixq.Soft.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.DataAnnotations.Internal
{
    public class EntityDataAnnotationsMetadataProvider : IEntityMetadataProvider
    {
        public void CreateEntityMetadata(EntityMetadataProviderContext context)
        {
            if (context.Attributes.OfType<SearcherAttribute>().Any())
            {
                context.EntityMetadata.IsSearcher = true;
            }
        }
    }
}
