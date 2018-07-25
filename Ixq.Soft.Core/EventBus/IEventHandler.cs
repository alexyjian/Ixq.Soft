using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Core.EventBus
{
    public interface IEventHandler
    {
    }

    public interface IEventHandler<in TEventData> : IEventHandler
        where TEventData : IEventData
    {
        void HandleEvent(TEventData eventData);

        Task HandleEventAsync(TEventData eventData);
    }
}