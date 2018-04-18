using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTest.Business.Interface;
using HollywoodTest.DataAccess;
using HollywoodTest.Shared.Models;

namespace HollywoodTest.Business.Repository
{
    public class EventRepository : IEventRepository
    {
        #region Properties
        private readonly DataAccess.Interface.IEventRepository _dataAccessEventRepository;
        private readonly EventDetailRepository _eventDetailRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event detail repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public EventRepository()
        {
            HollywoodTestEntities hollywoodTestEntities = new HollywoodTestEntities();
            _dataAccessEventRepository = new DataAccess.Repository.EventRepository(hollywoodTestEntities);
            _eventDetailRepository = new EventDetailRepository();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create new event
        /// </summary>
        /// <param name="event"></param>
        /// <returns>event event id</returns>
        public int Create(Event _event)
        {
            return _dataAccessEventRepository.Create(_event);
        }

        /// <summary>
        /// Update existing event
        /// </summary>
        /// <param name="event"></param>
        /// <returns>true or false</returns>
        public bool Update(Event _event)
        {
            return _dataAccessEventRepository.Update(_event);
        }

        /// <summary>
        /// Get all events by tournament ID
        /// </summary>
        /// <returns>List of events</returns>
        public List<Event> GetByTournamentID(long tournamentID)
        {
            var dbEvents = _dataAccessEventRepository.GetByTournamentID(tournamentID);

            List<Event> events = (from e in dbEvents
                                           select new Event
                                           {
                                               EventID = e.EventID,
                                               TournamentID = e.TournamentID,
                                               EventName = e.EventName,
                                               EventNumber = e.EventNumber,
                                               EventDateTime = e.EventDateTime,
                                               EventEndDateTime = e.EventEndDateTime,
                                               AutoClose = e.AutoClose,
                                               Tournament = new Tournament() {
                                                   TournamentName = e.TournamentName
                                               },                                                           
                                           }).ToList();
            return events;
        }

        /// <summary>
        /// Delete event by ID
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns>true or false</returns>
        public bool Delete(long eventID)
        {
            return _dataAccessEventRepository.Delete(eventID);
        }
        #endregion
    }
}
