using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ixq.Soft.Mvc.UI.jqGrid;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.ModelBinding.Metadata
{
    public class DefaultCompositeMetadataDetailsProvider :
        Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider, ICompositeMetadataDetailsProvider
    {
        private readonly IEnumerable<IMetadataDetailsProvider> _providers;

        public DefaultCompositeMetadataDetailsProvider(IEnumerable<IMetadataDetailsProvider> providers) :
            base(providers)
        {
            _providers = providers;
        }

        public void CreateEntityMetadata(EntityMetadataProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            foreach (var provider in _providers.OfType<IEntityMetadataProvider>())
            {
                provider.CreateEntityMetadata(context);
            }
        }

        public void CreateJqGridMetadata(JqGridMetadataProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            foreach (var provider in _providers.OfType<IJqGridMetadataProvider>())
            {
                provider.CreateJqGridMetadata(context);
            }
        }
    }
}
