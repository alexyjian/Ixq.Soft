using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.UI.jqGrid
{
    public class JqGridMetadataProviderContext : DisplayMetadataProviderContext
    {
        public JqGridMetadataProviderContext(
            ModelMetadataIdentity key,
            ModelAttributes attributes) : base(key, attributes)
        {

            JqGridMetadata = new JqGridMetadata();
        }

        public JqGridMetadata JqGridMetadata { get; set; }
    }
}