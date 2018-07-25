using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core.EventBus;
using Ixq.Soft.Core.EventBus.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ixq.Soft.Core.Tests.EventBus
{
    [TestClass]
    public class EventBusTest
    {
        protected Core.EventBus.Internal.EventBus EventBus { get; }

        public EventBusTest()
        {
            EventBus = Core.EventBus.Internal.EventBus.Default;
        }

        [TestMethod]
        public async Task Should_Call_Action_On_Event_With_Correct_Source()
        {
            var totalData = 0;

            EventBus.Register<MySimpleEventData>(
                eventData =>
                {
                    totalData += eventData.Value;
                    Assert.AreEqual(this, eventData.EventSource);
                });

            EventBus.Trigger(this, new MySimpleEventData(1));
            EventBus.Trigger(this, new MySimpleEventData(2));
            await EventBus.TriggerAsync(this, new MySimpleEventData(3));
            await EventBus.TriggerAsync(this, new MySimpleEventData(4));

            Assert.AreEqual(10, totalData);
        }

    }

    public class CustomEventData : EventData
    {

    }
}
