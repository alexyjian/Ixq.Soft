using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Mvc.ModelBinding.Metadata;

namespace Ixq.Soft.Mvc.UI.jqGrid
{
    public static class MetadataExtensions
    {
        public static string BuildColumnNames(this EntityModelMetadata metadata)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            var len = metadata.Properties.Count;
            for (var i = 0; i < len; i++)
            {
                var item = metadata.Properties[i];
                sb.Append($"'{item.DisplayName}'");
                if (i != len - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static string BuildColumnModels()
        {
            return string.Empty;
        }
    }
}