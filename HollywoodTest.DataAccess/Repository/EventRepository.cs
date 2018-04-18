using HollywoodTest.DataAccess.Interface;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Repository
{
    public class EventRepository : IEventRepository
    {
        #region Properties
        private readonly HollywoodTestEntities _db;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public EventRepository(HollywoodTestEntities db)
        {
            _db = db;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Create new event
        /// </summary>
        /// <param name="event"></param>
        /// <returns>event id</returns>
        public int Create(Event _event)
        {
            try
            {
                return _db.prtbEvent_Insert(_event.TournamentID, _event.EventName, _event.EventNumber, _event.EventDateTime, _event.EventEndDateTime, _event.AutoClose).FirstOrDefault().Value;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Update existing event
        /// </summary>
        /// <param name="event"></param>
        /// <returns>true or false</returns>
        public bool Update(Event _event)
        {
            try
            {
                _db.prtbEvent_Update(_event.EventID, _event.TournamentID, _event.EventName, _event.EventNumber, _event.EventDateTime, _event.EventEndDateTime, _event.AutoClose);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns>List of events</returns>
        public List<prtbEvent_GetByTournamentID_Result> GetByTournamentID(long tournamentID)
        {
            return _db.prtbEvent_GetByTournamentID(tournamentID).ToList();
        }

        /// <summary>
        /// Delete event by ID
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns>true or false</returns>
        public bool Delete(long eventID)
        {
            try
            {
                _db.prtbEvent_Delete(eventID);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
