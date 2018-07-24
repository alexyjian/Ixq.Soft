using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public class IocHandlerFactory : IEventHandlerFactory
    {
        public IocHandlerFactory(Type handlerType)
        {
            HandlerType = handlerType;
        }

        public Type HandlerType { get; }

        public IEventHandler GetHandler()
        {
            return (IEventHandler) Ioc.IocResolver.Current.GetService(HandlerType);
        }

        public void ReleaseHandler(IEventHandler eventHandler)
        {
        }
    }
}
