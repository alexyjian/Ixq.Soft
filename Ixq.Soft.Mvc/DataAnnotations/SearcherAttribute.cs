using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Mvc.DataAnnotations
{
    /// <summary>
    /// 表示属性可用于搜索的一个特性，应用了此特性后 <see cref="ModelBinding.Metadata.EntityModelMetadata.IsSearch"/> 将为 true。反之则为 false.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SearcherAttribute : Attribute
    {
    }
}
