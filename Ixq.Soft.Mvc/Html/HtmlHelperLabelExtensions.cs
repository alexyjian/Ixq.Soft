using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ixq.Soft.Mvc.Html
{
    public static class HtmlHelperLabelExtensions
    {
        public static IHtmlContent LabelFor(this IHtmlHelper htmlHelper, ModelMetadata metadata)
        {
            return GenerateLabel(htmlHelper, metadata, null, null);
        }

        public static IHtmlContent LabelFor(this IHtmlHelper htmlHelper, ModelMetadata metadata, string labelText)
        {
            return GenerateLabel(htmlHelper, metadata, labelText, null);
        }

        public static IHtmlContent LabelFor(this IHtmlHelper htmlHelper, ModelMetadata metadata, object htmlAttributes)
        {
            return GenerateLabel(htmlHelper, metadata, null, htmlAttributes);
        }


        private static IHtmlContent GenerateLabel(IHtmlHelper htmlHelper, ModelMetadata metadata, string labelText,
            object htmlAttributes)
        {
            Guard.ArgumentNotNull(htmlHelper, nameof(htmlHelper));
            Guard.ArgumentNotNull(metadata, nameof(metadata));


            return null;
        }
    }
}
