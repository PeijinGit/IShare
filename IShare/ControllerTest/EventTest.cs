using Business;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Moq;
using System.Collections;
using System.Collections.Generic;

namespace BusinessTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void TestGetAllEvents() 
        {
            var mock = new Mock<DAL.IEventDal>();
            mock.Setup(foo => foo.ListEvents()).Returns(new List<Models.Event>());
            IEventBus _eventBus = new Business.Event(mock.Object);
            int expected = 0;
            int actual = _eventBus.ListEvents().Count();
            Assert.AreEqual(expected, actual, "Counts of events error");
        }
    }
}
