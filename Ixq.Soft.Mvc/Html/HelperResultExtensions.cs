using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Ixq.Soft.Mvc.Html
{
    public static class HelperResultExtensions
    {
        public static string ToHtmlString(this HelperResult helperResult)
        {
            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                helperResult.WriteAction(writer);
                return writer.ToString();
            }
        }
    }
}