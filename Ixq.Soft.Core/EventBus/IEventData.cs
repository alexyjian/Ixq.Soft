using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.EventBus
{
    public interface IEventData
    {
        object EventSource { get; set; }
        DateTime EventTime { get; }
    }
}