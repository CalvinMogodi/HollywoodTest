using HollywoodTest.DataAccess.Interface;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Repository
{
    public class EventDetailRepository : IEventDetailRepository
    {
        #region Properties
        private readonly HollywoodTestEntities _db;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event detail repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public EventDetailRepository(HollywoodTestEntities db)
        {
            _db = db;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Create new event detail
        /// </summary>
        /// <param name="eventDetail"></param>
        /// <returns>event detail id</returns>
        public int Create(EventDetail eventDetail)
        {
            try
            {
                return _db.prtbEventDetail_Insert(eventDetail.EventID, eventDetail.EventDetailStatusID, eventDetail.EventDetailName, eventDetail.EventDetailNumber, eventDetail.EventDetailsOdd, eventDetail.FinishingPosition, eventDetail.FirstTimer).FirstOrDefault().Value;              
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Update existing event detail
        /// </summary>
        /// <param name="eventDetail"></param>
        /// <returns>true or false</returns>
        public bool Update(EventDetail eventDetail)
        {
            try
            {
                _db.prtbEventDetail_Update(eventDetail.EventDetailID, eventDetail.EventDetailID, eventDetail.EventDetailStatusID, eventDetail.EventDetailName, eventDetail.EventDetailNumber, eventDetail.EventDetailsOdd, eventDetail.FinishingPosition, eventDetail.FirstTimer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all event details
        /// </summary>
        /// <returns>List of event details</returns>
        public List<prtbEventDetail_GetByEventID_Result> GetByEventID(long eventID)
        {
            return _db.prtbEventDetail_GetByEventID(eventID).ToList();
        }

        /// <summary>
        /// Get event details by ID
        /// </summary>
        /// <returns>Event details</returns>
        public prtbEventDetail_GetOne_Result GetAllOne(int eventDetailID)
        {
            return _db.prtbEventDetail_GetOne(eventDetailID).FirstOrDefault();
        }

        /// <summary>
        /// Delete event detail by ID
        /// </summary>
        /// <param name="eventDetailID"></param>
        /// <returns>true or false</returns>
        public bool Delete(long eventDetailID)
        {
            try
            {
                _db.prtbEventDetail_Delete(eventDetailID);
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
