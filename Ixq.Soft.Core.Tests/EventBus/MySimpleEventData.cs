using Ixq.Soft.Core.EventBus.Internal;

namespace Ixq.Soft.Core.Tests.EventBus
{
    public class MySimpleEventData : EventData
    {
        public int Value { get; set; }

        public MySimpleEventData(int value)
        {
            Value = value;
        }
    }
}