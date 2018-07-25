using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core.Threading;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public class ActionEventHandler<TEventData> : IEventHandler<TEventData>
        where TEventData : IEventData
    {
        public ActionEventHandler(Action<TEventData> action)
        {
            Action = action;
        }

        public Action<TEventData> Action { get; }

        public void HandleEvent(TEventData eventData)
        {
            Action(eventData);
        }

        public async Task HandleEventAsync(TEventData eventData)
        {
            await TaskHelper.Run(() => Action(eventData));
        }
    }
}