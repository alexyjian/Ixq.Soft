using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core.Thread;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public class ActionEventHandler : IEventHandler
    {
        public ActionEventHandler(Action<IEventData> action)
        {
            Action = action;
        }

        public Action<IEventData> Action { get; }

        public void HandleEvent(IEventData eventData)
        {
            Action(eventData);
        }

        public async Task HandleEventAsync(IEventData eventData)
        {
            await TaskHelper.Run(() => Action(eventData));
        }
    }
}