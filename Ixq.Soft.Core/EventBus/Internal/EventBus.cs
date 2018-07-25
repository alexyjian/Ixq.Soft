using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Threading.Extensions;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Core.EventBus.Internal
{
    public class EventBus : IEventBus
    {
        private readonly ConcurrentDictionary<Type, List<IEventHandlerFactory>> _handlerFactories;

        public EventBus()
        {
            //Logger = Ioc.IocResolver.Current.GetService<ILogger<EventBus>>();
            _handlerFactories = new ConcurrentDictionary<Type, List<IEventHandlerFactory>>();
        }

        public static EventBus Default { get; } = new EventBus();

        public ILogger Logger { get; }


        public IDisposable Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            return Register(typeof(TEventData), new ActionEventHandler<TEventData>(action));
        }

        public IDisposable Register<TEventData>(IEventHandler handler) where TEventData : IEventData
        {
            return Register(typeof(TEventData), handler);
        }

        public IDisposable Register<TEventData, THandler>() where TEventData : IEventData where THandler : IEventHandler, new()
        {
            return Register(typeof(TEventData), new TransientEventHandlerFactory<THandler>());
        }

        public IDisposable Register(Type eventType, IEventHandler handler)
        {
            return Register(eventType, new SingleInstanceHandlerFactory(handler));
        }

        public IDisposable Register<TEventData>(IEventHandlerFactory factory) where TEventData : IEventData
        {
            return Register(typeof(TEventData), factory);
        }

        public IDisposable Register(Type eventType, IEventHandlerFactory factory)
        {
            GetOrCreateHandlerFactories(eventType)
                .Locking(factories => factories.Add(factory));

            return new EventDisposable(this, eventType, factory);
        }

        public void Unregister<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            GetOrCreateHandlerFactories(typeof(TEventData))
                .Locking(factories =>
                {
                    factories.RemoveAll(
                        factory =>
                        {
                            var singleInstanceFactory = factory as SingleInstanceHandlerFactory;
                            if (singleInstanceFactory == null)
                            {
                                return false;
                            }

                            var actionHandler = singleInstanceFactory.HandlerInstance as ActionEventHandler<TEventData>;
                            if (actionHandler == null)
                            {
                                return false;
                            }

                            return actionHandler.Action == action;
                        });
                });
        }

        public void Unregister<TEventData>(IEventHandler handler) where TEventData : IEventData
        {
            Unregister(typeof(TEventData), handler);
        }

        public void Unregister(Type eventType, IEventHandler handler)
        {
            GetOrCreateHandlerFactories(eventType)
                .Locking(factories =>
                {
                    factories.RemoveAll(
                        factory =>
                            factory is SingleInstanceHandlerFactory &&
                            (factory as SingleInstanceHandlerFactory).HandlerInstance == handler
                    );
                });
        }

        public void Unregister<TEventData>(IEventHandlerFactory factory) where TEventData : IEventData
        {
            Unregister(typeof(TEventData), factory);
        }

        public void Unregister(Type eventType, IEventHandlerFactory factory)
        {
            GetOrCreateHandlerFactories(eventType).Locking(factories => factories.Remove(factory));
        }

        public void UnregisterAll<TEventData>() where TEventData : IEventData
        {
            UnregisterAll(typeof(TEventData));
        }

        public void UnregisterAll(Type eventType)
        {
            GetOrCreateHandlerFactories(eventType).Locking(factories => factories.Clear());
        }

        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            Trigger((object)null, eventData);
        }

        public void Trigger<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData
        {
            Trigger(typeof(TEventData), eventSource, eventData);
        }

        public void Trigger(Type eventType, IEventData eventData)
        {
            Trigger(eventType, null, eventData);
        }

        public void Trigger(Type eventType, object eventSource, IEventData eventData)
        {
            var exceptions = new List<Exception>();

            eventData.EventSource = eventSource;

            foreach (var handlerFactories in GetHandlerFactories(eventType))
            {
                foreach (var handlerFactory in handlerFactories.EventHandlerFactories)
                {
                    SyncTrigger(handlerFactory, eventType, eventData, exceptions);
                }
            }

            if (exceptions.Any())
            {
                if (exceptions.Count == 1)
                {
                    throw exceptions[0];
                }

                throw new AggregateException("More than one error has occurred while triggering the event: " + eventType, exceptions);
            }
        }

        public Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            return TriggerAsync((object)null, eventData);
        }

        public Task TriggerAsync<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData
        {
            return TriggerAsync(typeof(TEventData), eventSource, eventData);
        }

        public Task TriggerAsync(Type eventType, IEventData eventData)
        {
            return TriggerAsync(eventType, null, eventData);
        }

        public async Task TriggerAsync(Type eventType, object eventSource, IEventData eventData)
        {
            var exceptions = new List<Exception>();

            eventData.EventSource = eventSource;

            await new SynchronizationContextRemover();

            foreach (var handlerFactories in GetHandlerFactories(eventType))
            {
                foreach (var handlerFactory in handlerFactories.EventHandlerFactories)
                {
                    await AsyncTrigger(handlerFactory, eventType, eventData, exceptions);
                }
            }

            if (exceptions.Any())
            {
                if (exceptions.Count == 1)
                {
                    throw exceptions[0];
                }

                throw new AggregateException("More than one error has occurred while triggering the event: " + eventType, exceptions);
            }
        }

        private void SyncTrigger(IEventHandlerFactory handlerFactory, Type eventType, IEventData eventData,
            List<Exception> exceptions)
        {
            var eventHandler = handlerFactory.GetHandler();
            try
            {
                if (eventHandler == null)
                {
                    throw new ArgumentNullException($"Registered event handler for event type {eventType.Name} is null!");
                }

                var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);

                var method = handlerType.GetMethod(
                    "HandleEvent",
                    new[] { eventType }
                );

                method.Invoke(eventHandler, new object[] { eventData });
            }
            catch (TargetInvocationException ex)
            {
                exceptions.Add(ex.InnerException);
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            finally
            {
                handlerFactory.ReleaseHandler(eventHandler);
            }
        }

        private async Task AsyncTrigger(IEventHandlerFactory handlerFactory, Type eventType, IEventData eventData,
            List<Exception> exceptions)
        {
            var eventHandler = handlerFactory.GetHandler();
            try
            {
                if (eventHandler == null)
                {
                    throw new ArgumentNullException($"Registered event handler for event type {eventType.Name} is null!");
                }

                var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);

                var method = handlerType.GetMethod(
                    "HandleEventAsync",
                    new[] { eventType }
                );

                await (Task)method.Invoke(eventHandler, new object[] { eventData });
            }
            catch (TargetInvocationException ex)
            {
                exceptions.Add(ex.InnerException);
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            finally
            {
                handlerFactory.ReleaseHandler(eventHandler);
            }
        }

        private List<IEventHandlerFactory> GetOrCreateHandlerFactories(Type eventType)
        {
            return _handlerFactories.GetOrAdd(eventType, (type) => new List<IEventHandlerFactory>());
        }
        private IEnumerable<EventTypeWithEventHandlerFactories> GetHandlerFactories(Type eventType)
        {
            var handlerFactoryList = new List<EventTypeWithEventHandlerFactories>();

            foreach (var handlerFactory in _handlerFactories.Where(hf => ShouldTriggerEventForHandler(eventType, hf.Key)))
            {
                handlerFactoryList.Add(new EventTypeWithEventHandlerFactories(handlerFactory.Key, handlerFactory.Value));
            }

            return handlerFactoryList.ToArray();
        }

        private static bool ShouldTriggerEventForHandler(Type eventType, Type handlerType)
        {
            //Should trigger same type
            if (handlerType == eventType)
            {
                return true;
            }

            //Should trigger for inherited types
            if (handlerType.IsAssignableFrom(eventType))
            {
                return true;
            }

            return false;
        }

        private class EventTypeWithEventHandlerFactories
        {
            public Type EventType { get; }

            public List<IEventHandlerFactory> EventHandlerFactories { get; }

            public EventTypeWithEventHandlerFactories(Type eventType, List<IEventHandlerFactory> eventHandlerFactories)
            {
                EventType = eventType;
                EventHandlerFactories = eventHandlerFactories;
            }
        }


        // Reference from
        // https://blogs.msdn.microsoft.com/benwilli/2017/02/09/an-alternative-to-configureawaitfalse-everywhere/
        private struct SynchronizationContextRemover : INotifyCompletion
        {
            public bool IsCompleted
            {
                get { return SynchronizationContext.Current == null; }
            }

            public void OnCompleted(Action continuation)
            {
                var prevContext = SynchronizationContext.Current;
                try
                {
                    SynchronizationContext.SetSynchronizationContext(null);
                    continuation();
                }
                finally
                {
                    SynchronizationContext.SetSynchronizationContext(prevContext);
                }
            }

            public SynchronizationContextRemover GetAwaiter()
            {
                return this;
            }

            public void GetResult()
            {
            }
        }

    }
}
