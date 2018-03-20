using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ixq.Soft.Core.Tests.Caching
{
    [TestClass]
    public class SerializableServiceTests
    {
        [TestMethod]
        public void Serializable()
        {
            var svc = new SerializableService();
            var obj = new InternalClass();
            obj.Field = 123;
            obj.Name = "Test";

            var bytes = svc.Serialize(obj);

            var newObj = svc.Deserialize<InternalClass>(bytes);

            Assert.IsInstanceOfType(newObj, typeof(InternalClass));
            Assert.AreEqual(obj.Field, newObj.Field);
            Assert.AreEqual(obj.Name, newObj.Name);
        }


        [Serializable]
        class InternalClass
        {
            public int Field;
            public string Name { get; set; }
        }
    }
}
