using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.EventBus
{
    public interface IEventHandlerFactory
    {
        IEventHandler GetHandler();

        void ReleaseHandler(IEventHandler eventHandler);
    }
}