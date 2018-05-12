using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.UI.jqGrid
{
    public interface IJqGridMetadataProvider : IMetadataDetailsProvider
    {
        void CreateJqGridMetadata(JqGridMetadataProviderContext context);
    }
}
