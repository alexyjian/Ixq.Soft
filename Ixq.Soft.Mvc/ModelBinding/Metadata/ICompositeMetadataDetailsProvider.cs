using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public interface ICompositeMetadataDetailsProvider :
        Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider, IEntityMetadataProvider
    {
    }
}