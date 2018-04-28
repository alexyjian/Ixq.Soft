using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Ixq.Soft.Mvc.Html
{
    public class StyleTemplate : HtmlTemplate
    {
        public StyleTemplate(Func<object, HelperResult> template) : base(template)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is StyleTemplate))
                return false;


            var pattern = @"<link.*?href=""(.*?)""";

            var value1 = Template(null).ToHtmlString();
            var match1 = Regex.Match(value1, pattern);

            var value2 = (obj as StyleTemplate).Template(null).ToHtmlString();
            var match2 = Regex.Match(value2, pattern);

            if (!match1.Success || !match2.Success)
                return false;

            return match1.Groups[1].Value == match2.Groups[1].Value;
        }
    }
}
