using System;
using System.Threading.Tasks;
using Ixq.Soft.Core.EventBus;
using Ixq.Soft.Core.Tests.EventBus;

namespace Abp.Tests.Events.Bus
{
    public class MySimpleTransientAsyncEventHandler : IEventHandler<MySimpleEventData>, IDisposable
    {
        public static int HandleCount { get; set; }

        public static int DisposeCount { get; set; }

        public void HandleEvent(MySimpleEventData eventData)
        {
            ++HandleCount;
        }

        public Task HandleEventAsync(MySimpleEventData eventData)
        {
            ++HandleCount;
            return Task.FromResult(0);
        }

        public void Dispose()
        {
            ++DisposeCount;
        }
    }
}