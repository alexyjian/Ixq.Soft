using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Mvc.Models
{
    [Serializable]
    public class DataTableResult<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public List<T> Data { get; set; }
    }
}
