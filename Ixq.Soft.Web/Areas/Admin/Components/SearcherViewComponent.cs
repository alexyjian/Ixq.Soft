﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Mvc.ModelBinding.Metadata;
using Ixq.Soft.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Ixq.Soft.Web.Areas.Admin.Components
{
    public class SearcherViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IListPageModel model)
        {
            var propertieMetadatas = model.ModelMetadata.Properties
                .OfType<EntityModelMetadata>()
                .Where(x => x.IsSearcher)
                .OrderBy(x => x.Order);

            return View(propertieMetadatas);
        }
    }
}