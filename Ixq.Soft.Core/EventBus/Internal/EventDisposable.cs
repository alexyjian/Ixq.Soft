using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public class EventDisposable : IDisposable
    {
        private readonly IEventBus _eventBus;
        private readonly Type _eventType;
        private readonly IEventHandlerFactory _factory;

        public EventDisposable(IEventBus eventBus, Type eventType, IEventHandlerFactory factory)
        {
            _eventBus = eventBus;
            _eventType = eventType;
            _factory = factory;

        }

        public void Dispose()
        {
            _eventBus.Unregister(_eventType, _factory);
        }
    }
}