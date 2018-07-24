using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public class SingleInstanceHandlerFactory : IEventHandlerFactory
    {
        public SingleInstanceHandlerFactory(IEventHandler eventHandler)
        {
            HandlerInstance = eventHandler;
        }

        public IEventHandler HandlerInstance { get; private set; }

        public IEventHandler GetHandler()
        {
            return HandlerInstance;
        }

        public void ReleaseHandler(IEventHandler eventHandler)
        {
        }
    }
}
