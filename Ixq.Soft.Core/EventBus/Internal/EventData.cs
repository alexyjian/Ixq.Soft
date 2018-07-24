using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public abstract class EventData : IEventData
    {
        protected EventData()
        {
            EventTime = DateTime.Now;
        }

        public object EventSource { get; set; }
        public DateTime EventTime { get; }
    }
}
