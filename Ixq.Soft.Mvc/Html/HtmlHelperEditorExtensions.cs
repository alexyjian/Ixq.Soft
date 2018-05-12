using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace Ixq.Soft.Mvc.Html
{

    public static class HtmlHelperEditorExtensions
    {
        public static IHtmlContent EditorFor(this IHtmlHelper htmlHelper, ModelMetadata metadata, string templateName,
            string htmlFieldName, object additionalViewData)
        {
            Guard.ArgumentNotNull(htmlHelper, nameof(htmlHelper));
            Guard.ArgumentNotNull(metadata, nameof(metadata));
            Guard.ArgumentNotNullOrEmpty(htmlFieldName, nameof(htmlFieldName));

            var viewEngine = DependencyResolver.Current.GetRequiredService<ICompositeViewEngine>();
            var bufferScope = DependencyResolver.Current.GetRequiredService<IViewBufferScope>();
            var metadataProvider = DependencyResolver.Current.GetRequiredService<IModelMetadataProvider>();

            var modelExplorer = new ModelExplorer(metadataProvider, metadata, null);
            var templateBuilder = new TemplateBuilder(
                viewEngine,
                bufferScope,
                htmlHelper.ViewContext,
                htmlHelper.ViewData,
                modelExplorer,
                htmlFieldName,
                templateName,
                readOnly: false,
                additionalViewData: additionalViewData);

            return templateBuilder.Build();
        }

        public static IHtmlContent EditorFor(this IHtmlHelper htmlHelper, ModelMetadata metadata,
            object additionalViewData)
        {
            return EditorFor(htmlHelper, metadata, null, metadata.PropertyName, additionalViewData);
        }

        public static IHtmlContent EditorFor(this IHtmlHelper htmlHelper, ModelMetadata metadata, string templateName)
        {
            return EditorFor(htmlHelper, metadata, templateName, metadata.PropertyName, null);
        }

        public static IHtmlContent EditorFor(this IHtmlHelper htmlHelper, ModelMetadata metadata, string templateName,
            object additionalViewData)
        {
            return EditorFor(htmlHelper, metadata, templateName, metadata.PropertyName, additionalViewData);
        }

        public static IHtmlContent EditorFor(this IHtmlHelper htmlHelper, ModelMetadata metadata, string templateName,
            string htmlFieldName)
        {
            return EditorFor(htmlHelper, metadata, templateName, htmlFieldName, null);
        }
    }
}