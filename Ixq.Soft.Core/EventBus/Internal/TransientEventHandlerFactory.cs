using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public class TransientEventHandlerFactory<THandler> : IEventHandlerFactory
        where THandler : IEventHandler, new ()
    {

        public IEventHandler GetHandler()
        {
            return new THandler();
        }

        public void ReleaseHandler(IEventHandler eventHandler)
        {
        }
    }
}
