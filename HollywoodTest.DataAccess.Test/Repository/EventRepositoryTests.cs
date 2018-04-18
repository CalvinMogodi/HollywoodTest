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
    public class EventRepositoryTests
    {
        #region Test Methods

        /// <summary>
        /// Create event test
        /// </summary>
        [TestMethod()]
        [Priority(2)]
        public void CreateEventTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventRepository eventRepository = new EventRepository(dataContext);
            Event _event = new Event()
            {
               TournamentID = 1,
               EventName = "Create Event Data Access Unit Test",
               EventNumber = 1,
               EventDateTime = Convert.ToDateTime("2019-04-16"),
               EventEndDateTime = Convert.ToDateTime("2019-06-16"),
               AutoClose = true,
            };

            // Act
            int eventId = eventRepository.Create(_event);

            // Assert
            Assert.AreNotEqual(eventId, 0);
        }

        /// <summary>
        /// Update event test
        /// </summary>
        [TestMethod()]
        public void UpdateEventTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventRepository eventRepository = new EventRepository(dataContext); 
            Event _event = new Event()
            {
                TournamentID = 1,
                EventName = "Update Event Data Access Unit Test",
                EventNumber = 1,
                EventDateTime = Convert.ToDateTime("2019-04-16"),
                EventEndDateTime = Convert.ToDateTime("2019-06-16"),
                AutoClose = true,
            };

            // Act
            int eventId = eventRepository.Create(_event);
            _event.EventID = eventId;
            _event.EventName = "Updated Event Data Access Unit Test";
            bool isUpdated = eventRepository.Update(_event);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        /// <summary>
        /// Get all event test
        /// </summary>
        [TestMethod()]
        public void GetAllEventTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventRepository eventRepository = new EventRepository(dataContext);

            // Act
            var tournaments = eventRepository.GetByTournamentID(1);

            // Assert
            Assert.AreNotEqual(tournaments.Count(), 0);
        }

        /// <summary>
        /// Delete event test
        /// </summary>
        [TestMethod()]
        public void DeleteEventTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            EventRepository eventRepository = new EventRepository(dataContext);
            Event _event = new Event()
            {
                TournamentID = 1,
                EventName = "Delete Event Data Access Unit Test",
                EventNumber = 1,
                EventDateTime = Convert.ToDateTime("2019-04-16"),
                EventEndDateTime = Convert.ToDateTime("2019-06-16"),
                AutoClose = true,
            };

            // Act
            int eventId = eventRepository.Create(_event);
            bool isDeleted = eventRepository.Delete(eventId);

            // Assert
            Assert.IsTrue(isDeleted);
        }
        #endregion
    }
}