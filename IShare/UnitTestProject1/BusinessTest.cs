using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class BusinessTest
    {
        [TestMethod]
        public void ListEventsTest()
        {
            IEnumerable modelList = new List<Models.Event>();
            var mock = new Mock<DAL.IEventDAL>();
            mock.Setup(foo => foo.ListEvents()).Returns(new List<Models.Event>(
                new Models.Event[]
                {
                    new Models.Event(1, "eve1"),
                    new Models.Event(2, "eve2"),
                    new Models.Event(3, "eve3"),
                    new Models.Event(4, "eve4"),
                    new Models.Event(5, "eve5")
                }
            ));
            IEventBLL _eventBus = new Business.Event(mock.Object);
            int expected = 5;
            int actual = _eventBus.ListEvents().Count();
            Assert.AreEqual(expected, actual, "Counts of events error");

        }
    }
}
