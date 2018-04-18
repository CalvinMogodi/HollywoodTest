using HollywoodTest.Business.Interface;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HollywoodTest.API.Controllers
{

    public class EventDetailController : ApiController
    {
        #region Properties
        private readonly IEventDetailRepository eventDetailRepository;
        #endregion

        #region Constructor
        public EventDetailController(IEventDetailRepository eventDetailRepository)
        {
            this.eventDetailRepository = eventDetailRepository;
        }

        #endregion

        #region Action Methods
        // GET: api/EventDetail/5
        [HttpGet]
        public IEnumerable<EventDetail> Get(long eventID)
        {
            return eventDetailRepository.GetByEventID(eventID);
        }

        // POST: api/EventDetail
        [HttpPost]
        public int Create(EventDetail eventDetail)
        {
            return eventDetailRepository.Create(eventDetail);
        }

        // PUT: api/EventDetail/5
        [HttpPost]
        public bool Update(EventDetail eventDetail)
        {
            return eventDetailRepository.Update(eventDetail);
        }

        // DELETE: api/EventDetail/5
        [HttpDelete]
        public bool Delete(long eventDetailID)
        {
            return eventDetailRepository.Delete(eventDetailID);
        }

        #endregion
    }
}
