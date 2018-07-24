using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Core.EventBus
{
    public interface IEventHandler
    {
        void HandleEvent(IEventData eventData);

        Task HandleEventAsync(IEventData eventData);
    }
}
