using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.UI.jqGrid
{
    public class JqGridListPageModel : ListPageModel
    {
        public JqGridListPageModel(EntityMetadata entityMetadata) : base(entityMetadata)
        {
        }
        public JqGridMetadata JqGridMetadata { get; set; }
    }
}
