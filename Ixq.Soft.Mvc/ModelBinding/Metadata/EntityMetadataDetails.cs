using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public class EntityMetadataDetails : DefaultMetadataDetails
    {

        public EntityMetadataDetails(ModelMetadataIdentity key, ModelAttributes attributes) : base(key, attributes)
        {
        }

        public EntityMetadata EntityMetadata { get; set; }
    }
}
