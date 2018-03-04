using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Mvc.UI
{
    public class PageSizeList : List<int>
    {
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
