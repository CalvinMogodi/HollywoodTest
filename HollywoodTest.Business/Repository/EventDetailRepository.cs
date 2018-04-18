using HollywoodTest.Business.Interface;
using HollywoodTest.DataAccess;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.Business.Repository
{
    public class EventDetailRepository : IEventDetailRepository
    {
        #region Properties
        private readonly DataAccess.Interface.IEventDetailRepository _dataAccessEventDetailRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event detail repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public EventDetailRepository()
        {
            HollywoodTestEntities hollywoodTestEntities = new HollywoodTestEntities();
            _dataAccessEventDetailRepository = new DataAccess.Repository.EventDetailRepository(hollywoodTestEntities);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create new event detail
        /// </summary>
        /// <param name="eventDetail"></param>
        /// <returns>event event detail id</returns>
        public int Create(EventDetail eventDetail)
        {
            return _dataAccessEventDetailRepository.Create(eventDetail);
        }

        /// <summary>
        /// Update existing event detail
        /// </summary>
        /// <param name="eventDetail"></param>
        /// <returns>true or false</returns>
        public bool Update(EventDetail eventDetail)
        {
            return _dataAccessEventDetailRepository.Update(eventDetail);
        }

        /// <summary>
        /// Get all event details by event ID
        /// </summary>
        /// <returns>List of event details</returns>
        public List<EventDetail> GetByEventID(long eventID)
        {
            var dbEventDetails = _dataAccessEventDetailRepository.GetByEventID(eventID);
            List<EventDetail> eventDetails = (from ed in dbEventDetails
                                  select new EventDetail
                                  {
                                      EventDetailID = ed.EventDetailID,
                                      EventID = ed.EventID,
                                      EventDetailStatusID = ed.EventDetailStatusID,
                                      EventDetailName = ed.EventDetailName,
                                      EventDetailNumber = ed.EventDetailNumber,
                                      EventDetailsOdd = ed.EventDetailsOdd,
                                      FinishingPosition = ed.FinishingPosition,
                                      FirstTimer = ed.FirstTimer,
                                      Event = new Event() {
                                          EventName = ed.EventName
                                      }
                                  }).ToList();
            return eventDetails;
        }

        /// <summary>
        /// Delete event by ID
        /// </summary>
        /// <param name="eventDetailID"></param>
        /// <returns>true or false</returns>
        public bool Delete(long eventDetailID)
        {
            return _dataAccessEventDetailRepository.Delete(eventDetailID);
        }
        #endregion
    }
}
