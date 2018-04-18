using Microsoft.VisualStudio.TestTools.UnitTesting;
using HollywoodTest.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTest.Shared.Models;

namespace HollywoodTest.DataAccess.Repository.Tests
{
    [TestClass()]
    public class EventDetailRepositoryTests
    {
        #region Test Methods

        /// <summary>
        /// Create event detail test
        /// </summary>
        [TestMethod()]
        [Priority(2)]
        public void CreateEventDetailTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventDetailRepository eventDetailRepository = new EventDetailRepository(dataContext);
            EventDetail eventDetail = new EventDetail()
            {
                EventID = 1,
                EventDetailStatusID = 1,
                EventDetailName = "Create Event Detail Data Access Unit Test",
                EventDetailNumber = 1,
                EventDetailsOdd = 1,
                FinishingPosition = 1,
                FirstTimer = true,
            };

            // Act
            int EventDetailID = eventDetailRepository.Create(eventDetail);

            // Assert
            Assert.AreNotEqual(EventDetailID, 0);
        }

        /// <summary>
        /// Update event detail test
        /// </summary>
        [TestMethod()]
        public void UpdateEventDetailTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventDetailRepository eventDetailRepository = new EventDetailRepository(dataContext);
            EventDetail eventDetail = new EventDetail()
            {
                EventID = 1,
                EventDetailStatusID = 1,
                EventDetailName = "Update Event Detail Data Access Unit Test",
                EventDetailNumber = 1,
                EventDetailsOdd = 1,
                FinishingPosition = 1,
                FirstTimer = true,
            };

            // Act
            int EventDetailID = eventDetailRepository.Create(eventDetail);
            eventDetail.EventDetailID = EventDetailID;
            eventDetail.EventDetailName = "Updated Event Detail Data Access Unit Test";
            bool isUpdated = eventDetailRepository.Update(eventDetail);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        /// <summary>
        /// Get all event detail test
        /// </summary>
        [TestMethod()]
        public void GetByEventIDTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventDetailRepository eventDetailRepository = new EventDetailRepository(dataContext);

            // Act
            var tournaments = eventDetailRepository.GetByEventID(1);

            // Assert
            Assert.AreNotEqual(tournaments.Count(), 0);
        }

        /// <summary>
        /// Delete event detail test
        /// </summary>
        [TestMethod()]
        public void DeleteEventDetailTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventDetailRepository eventDetailRepository = new EventDetailRepository(dataContext);
            EventDetail eventDetail = new EventDetail()
            {
                EventID = 1,
                EventDetailStatusID = 1,
                EventDetailName = "Delete Event Detail Data Access Unit Test",
                EventDetailNumber = 1,
                EventDetailsOdd = 1,
                FinishingPosition = 1,
                FirstTimer = true,
            };

            // Act
            int eventDetailID = eventDetailRepository.Create(eventDetail);
            bool isDeleted = eventDetailRepository.Delete(eventDetailID);

            // Assert
            Assert.IsTrue(isDeleted);
        }
                
        #endregion
    }
}