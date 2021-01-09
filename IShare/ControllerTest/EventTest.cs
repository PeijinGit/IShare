using Business;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ControllerTest
{
    [TestClass]
    public class EventTest
    {
        public IFakeServiceCollection ConfigureServices()
        {
            IFakeServiceCollection fakeServiceCollection = new FakeServiceCollection();
            fakeServiceCollection.AddTransient(typeof(IEventDal), typeof(DAL.Event));
            fakeServiceCollection.AddTransient(typeof(IEventBus), typeof(Business.Event));
            return fakeServiceCollection;
        }

        [TestMethod]
        public void TestGetAllEvents()
        {
            IFakeServiceCollection fakeServiceCollection = ConfigureServices();
            IEventBus _eventBus = fakeServiceCollection.GetService<IEventBus>();
            _eventBus.ListEvents().Count();
            int expected = 4;
            int actual = _eventBus.ListEvents().Count();
            Assert.AreEqual(expected, actual, "Counts of events error");
        }
    }
}
