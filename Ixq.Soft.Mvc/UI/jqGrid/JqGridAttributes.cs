using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Mvc.UI.jqGrid
{
    /// <summary>
    ///     jqGrid 表格列的属性。
    /// </summary>
    public class JqGridColumnAttribute : Attribute
    {
        public JqGridColumnAttribute(string index, string name)
        {
            Index = index;
            Name = name;
        }

        /// <summary>
        ///     获取或设置引索，与后台交互的参数。
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        ///     获取或设置表格列的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     获取或设置是否可排序。
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        ///     获取或设置在初始化表格时是否要隐藏此列。
        /// </summary>
        public bool Hidden { get; set; }
    }

    public class JqGridColumnSytle : Attribute
    {
        /// <summary>
        ///     获取或设置css样式类。
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        ///     获取或设置列宽。
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     获取或设置对齐方式。
        /// </summary>
        public TextAlign Align { get; set; }
    }

    public class JqGridColumnFormatter : Attribute
    {
        /// <summary>
        ///     获取或设置字段值的显示格式。
        /// </summary>
        public string DataFormatString { get; set; }

        /// <summary>
        ///     获取或设置格式化 Javascript 脚本。
        /// </summary>
        public string FormatterScript { get; set; }

        /// <summary>
        ///     获取或设置反格式化 Javascript 脚本。
        /// </summary>
        public string UnFormatterScript { get; set; }
    }
}