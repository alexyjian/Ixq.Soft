using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ixq.Soft.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        public static object ScriptsKey = new object();
        public static object StylesKey = new object();

        /// <summary>
        ///     注册脚本。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="templates"></param>
        /// <returns></returns>
        public static IHtmlContent RegisterScript(this IHtmlHelper helper,
            params Func<object, HelperResult>[] templates)
        {
            foreach (var template in templates)
            {
                var htmlTemplate = new ScriptTemplate(template);
                if (helper.ViewContext.HttpContext.Items[ScriptsKey] != null)
                    ((List<ScriptTemplate>) helper.ViewContext.HttpContext.Items[ScriptsKey]).Add(htmlTemplate);
                else
                    helper.ViewContext.HttpContext.Items[ScriptsKey] = new List<ScriptTemplate> {htmlTemplate};
            }

            return HtmlString.Empty;
        }

        /// <summary>
        ///     渲染脚本。
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlContent RenderScripts(this IHtmlHelper helper)
        {
            var scripts = new List<ScriptTemplate>();
            if (helper.ViewContext.HttpContext.Items[ScriptsKey] != null)
            {
                var resources = (List<ScriptTemplate>) helper.ViewContext.HttpContext.Items[ScriptsKey];
                foreach (var resource in resources)
                    if (!scripts.Any(x => x.Equals(resource)))
                    {
                        helper.ViewContext.Writer.Write(resource.Template(null));
                        scripts.Add(resource);
                    }
            }

            return HtmlString.Empty;
        }

        /// <summary>
        ///     注册样式。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="templates"></param>
        /// <returns></returns>
        public static IHtmlContent RegisterStyles(this IHtmlHelper helper,
            params Func<object, HelperResult>[] templates)
        {
            foreach (var template in templates)
            {
                var htmlTemplate = new StyleTemplate(template);
                if (helper.ViewContext.HttpContext.Items[StylesKey] != null)
                    ((List<StyleTemplate>) helper.ViewContext.HttpContext.Items[StylesKey]).Add(htmlTemplate);
                else
                    helper.ViewContext.HttpContext.Items[StylesKey] = new List<StyleTemplate> {htmlTemplate};
            }

            return HtmlString.Empty;
        }

        /// <summary>
        ///     渲染样式。
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlContent RenderStyles(this IHtmlHelper helper)
        {
            var styles = new List<StyleTemplate>();
            if (helper.ViewContext.HttpContext.Items[StylesKey] != null)
            {
                var resources = (List<StyleTemplate>) helper.ViewContext.HttpContext.Items[StylesKey];
                foreach (var resource in resources)
                    if (!styles.Any(x => x.Equals(resource)))
                    {
                        helper.ViewContext.Writer.Write(resource.Template(null));
                        styles.Add(resource);
                    }
            }

            return HtmlString.Empty;
        }

        /// <summary>
        ///     注册资源。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="type"></param>
        /// <param name="templates"></param>
        /// <returns></returns>
        public static IHtmlContent RegisterResource(this IHtmlHelper helper, string type,
            params Func<object, HelperResult>[] templates)
        {
            foreach (var template in templates)
            {
                var htmlTemplate = new HtmlTemplate(template);
                if (helper.ViewContext.HttpContext.Items[type] != null)
                    ((List<HtmlTemplate>) helper.ViewContext.HttpContext.Items[type]).Add(htmlTemplate);
                else
                    helper.ViewContext.HttpContext.Items[type] = new List<HtmlTemplate> {htmlTemplate};
            }

            return HtmlString.Empty;
        }

        /// <summary>
        ///     渲染资源。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IHtmlContent RenderResources(this IHtmlHelper helper, string type)
        {
            if (helper.ViewContext.HttpContext.Items[type] != null)
            {
                var resources = (List<HtmlTemplate>) helper.ViewContext.HttpContext.Items[type];

                foreach (var resource in resources)
                    if (resource != null)
                        helper.ViewContext.Writer.Write(resource.Template(null));
            }

            return HtmlString.Empty;
        }
    }
}