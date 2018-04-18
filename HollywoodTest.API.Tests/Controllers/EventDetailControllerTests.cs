using Microsoft.VisualStudio.TestTools.UnitTesting;
using HollywoodTest.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTest.Business.Repository;
using HollywoodTest.Shared.Models;

namespace HollywoodTest.API.Controllers.Tests
{
    [TestClass()]
    public class EventDetailControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            EventDetailRepository eventDetailRepository = new EventDetailRepository();
            EventDetailController controller = new EventDetailController(eventDetailRepository);

            // Act
            IEnumerable<EventDetail> result = controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void PostTest()
        {
            // Arrange
            EventDetailRepository eventDetailRepository = new EventDetailRepository();
            EventDetailController controller = new EventDetailController(eventDetailRepository);
            EventDetail eventDetail = new EventDetail()
            {
                EventID = 1,
                EventDetailStatusID = 1,
                EventDetailName = "Create Event Detail Unit Test",
                EventDetailNumber = 1,
                EventDetailsOdd = 1,
                FinishingPosition = 1,
                FirstTimer = true,
            };

            // Act
            int EventDetailID = controller.Create(eventDetail);

            // Assert
            Assert.AreNotEqual(EventDetailID, 0);
        }

        [TestMethod()]
        public void PutTest()
        {
            // Arrange
            EventDetailRepository eventDetailRepository = new EventDetailRepository();
            EventDetailController controller = new EventDetailController(eventDetailRepository);
            EventDetail eventDetail = new EventDetail()
            {
                EventID = 1,
                EventDetailStatusID = 1,
                EventDetailName = "Update Event Detail API Unit Test",
                EventDetailNumber = 1,
                EventDetailsOdd = 1,
                FinishingPosition = 1,
                FirstTimer = true,
            };

            // Act
            int EventDetailID = controller.Create(eventDetail);
            eventDetail.EventDetailID = EventDetailID;
            eventDetail.EventDetailName = "Updated Event Detail API Unit Test";
            bool isUpdated = controller.Update(eventDetail);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            EventDetailRepository eventDetailRepository = new EventDetailRepository();
            EventDetailController controller = new EventDetailController(eventDetailRepository);
            EventDetail eventDetail = new EventDetail()
            {
                EventID = 1,
                EventDetailStatusID = 1,
                EventDetailName = "Delete Event Detail API Unit Test",
                EventDetailNumber = 1,
                EventDetailsOdd = 1,
                FinishingPosition = 1,
                FirstTimer = true,
            };

            // Act
            int eventDetailID = controller.Create(eventDetail);
            bool isDeleted = controller.Delete(eventDetailID);

            // Assert
            Assert.IsTrue(isDeleted);
        }
    }
}