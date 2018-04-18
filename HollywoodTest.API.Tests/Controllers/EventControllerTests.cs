using Microsoft.VisualStudio.TestTools.UnitTesting;
using HollywoodTest.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTest.Shared.Models;
using HollywoodTest.Business.Repository;

namespace HollywoodTest.API.Controllers.Tests
{
    [TestClass()]
    public class EventControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            EventRepository iEventRepository = new EventRepository();
            EventController controller = new EventController(iEventRepository);

            // Act
            IEnumerable<Event> result = controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            EventRepository iEventRepository = new EventRepository();
            EventController controller = new EventController(iEventRepository);
            Event _event = new Event()
            {
                TournamentID = 1,
                EventName = "Create Event API Unit Test",
                EventNumber = 1,
                EventDateTime = Convert.ToDateTime("2019-04-16"),
                EventEndDateTime = Convert.ToDateTime("2019-06-16"),
                AutoClose = true,
            };

            // Act
            int result = controller.Create(_event);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod()]
        public void PutTest()
        {
            // Arrange
            EventRepository iEventRepository = new EventRepository();
            EventController controller = new EventController(iEventRepository);
            Event _event = new Event()
            {
                TournamentID = 1,
                EventName = "Update Event API Unit Test",
                EventNumber = 1,
                EventDateTime = Convert.ToDateTime("2019-04-16"),
                EventEndDateTime = Convert.ToDateTime("2019-06-16"),
                AutoClose = true,
            };

            // Act
            int eventId = controller.Create(_event);
            _event.EventID = eventId;
            _event.EventName = "Updated Event API Unit Test";
            bool isUpdated = controller.Update(_event);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            EventRepository iEventRepository = new EventRepository();
            EventController controller = new EventController(iEventRepository);
            Event _event = new Event()
            {
                TournamentID = 1,
                EventName = "Delete Event Unit Test",
                EventNumber = 1,
                EventDateTime = Convert.ToDateTime("2019-04-16"),
                EventEndDateTime = Convert.ToDateTime("2019-06-16"),
                AutoClose = true,
            };
            // Act
            int eventId = controller.Create(_event);
            bool isDeleted = controller.Delete(eventId);

            // Assert
            Assert.IsTrue(isDeleted);
        }
    }
}