using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Ixq.Soft.Core.Extensions;
using Ixq.Soft.Mvc.ModelBinding.Metadata;
using Ixq.Soft.Mvc.UI.jqGrid;
using Microsoft.AspNetCore.Mvc;

namespace Ixq.Soft.Mvc.DataAnnotations.Internal
{
    public class EntityDataAnnotationsMetadataProvider : IEntityMetadataProvider, IJqGridMetadataProvider
    {
        public void CreateEntityMetadata(EntityMetadataProviderContext context)
        {
            var entityMetadata = context.EntityMetadata;
            var attributes = context.Attributes;
            var pageConfigAttribute = attributes.OfType<PageConfigAttribute>().FirstOrDefault();
            if (pageConfigAttribute != null)
            {
                if (!pageConfigAttribute.ListAction.IsNullOrEmpty())
                {
                    entityMetadata.ListAction = pageConfigAttribute.ListAction;
                }

                if (!pageConfigAttribute.EditAction.IsNullOrEmpty())
                {
                    entityMetadata.EditAction = pageConfigAttribute.EditAction;
                }

                if (!pageConfigAttribute.DeleteAction.IsNullOrEmpty())
                {
                    entityMetadata.DeleteAction = pageConfigAttribute.DeleteAction;
                }

                entityMetadata.SortField = pageConfigAttribute.SortField;
                entityMetadata.SortDirection = pageConfigAttribute.SortDirection;
            }

            if (context.Attributes.OfType<SearcherAttribute>().Any())
            {
                entityMetadata.IsSearcher = true;
            }
        }

        public void CreateJqGridMetadata(JqGridMetadataProviderContext context)
        {
            var attributes = context.Attributes;

            var columnAttribute = attributes.OfType<JqGridColumnAttribute>().FirstOrDefault();
            var styleAttribute = attributes.OfType<JqGridColumnSytle>().FirstOrDefault();
            var formatterAttribute = attributes.OfType<JqGridColumnFormatter>().FirstOrDefault();

            var displayAttribute = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            var displayFormatAttribute = attributes.OfType<DisplayFormatAttribute>().FirstOrDefault();
            var hiddenInputAttribute = attributes.OfType<HiddenInputAttribute>().FirstOrDefault();

            var metadata = context.JqGridMetadata;

            if (hiddenInputAttribute != null)
            {
                metadata.ShowForList = false;
            }

            if (displayAttribute != null)
            {
                metadata.Name = displayAttribute.GetName();
            }

            if (columnAttribute != null)
            {
                metadata.Name = columnAttribute.Name;
                metadata.Index = columnAttribute.Index;
                metadata.Sortable = columnAttribute.Sortable;
                metadata.ShowForList = !columnAttribute.Hidden;
            }

            if (styleAttribute != null)
            {
                metadata.CssClass = styleAttribute.CssClass;
                metadata.Width = styleAttribute.Width;
                metadata.Align = styleAttribute.Align;
            }

            if (formatterAttribute != null)
            {
                metadata.DataFormatString = formatterAttribute.DataFormatString;
                metadata.FormatterScript = formatterAttribute.FormatterScript;
                metadata.UnFormatterScript = formatterAttribute.UnFormatterScript;
            }
            else if (displayFormatAttribute != null)
            {
                metadata.DataFormatString = displayFormatAttribute.DataFormatString;
            }
        }
    }
}
