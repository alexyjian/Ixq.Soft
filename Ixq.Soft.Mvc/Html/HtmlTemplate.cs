using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Ixq.Soft.Mvc.Html
{
    /// <summary>
    ///     html模版。
    /// </summary>
    public class HtmlTemplate
    {
        /// <summary>
        ///     初始化一个<see cref="HtmlTemplate" />对象。
        /// </summary>
        /// <param name="template">模版委托方法。</param>
        public HtmlTemplate(Func<object, HelperResult> template)
        {
            Template = template;
        }

        public Func<object, HelperResult> Template { get; set; }
    }
}