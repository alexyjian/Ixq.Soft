using System.Globalization;

namespace Ixq.Soft.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Fill(this string template, params object[] arguments)
        {
            Guard.ArgumentNotNullOrWhiteSpace(template, nameof(template));
            return string.Format(CultureInfo.CurrentCulture, template, arguments);
        }

        public static bool IsNullOrEmpty(this string template)
        {
            return string.IsNullOrEmpty(template);
        }

        public static bool IsNullOrWhiteSpace(this string template)
        {
            return string.IsNullOrWhiteSpace(template);
        }
    }
}