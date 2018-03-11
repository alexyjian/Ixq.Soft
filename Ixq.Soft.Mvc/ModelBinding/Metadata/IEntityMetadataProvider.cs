using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public interface IEntityMetadataProvider : IMetadataDetailsProvider
    {
        void CreateEntityMetadata(EntityMetadataProviderContext context);
    }
}