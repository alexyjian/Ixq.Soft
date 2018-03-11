using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public class EntityMetadataProviderContext : DisplayMetadataProviderContext
    {
        public EntityMetadataProviderContext(
            ModelMetadataIdentity key,
            ModelAttributes attributes) : base(key, attributes)
        {

            EntityMetadata = new EntityMetadata();
        }

        public EntityMetadata EntityMetadata { get; set; }
    }
}
