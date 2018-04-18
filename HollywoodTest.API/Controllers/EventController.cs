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
    public class EventController : ApiController
    {
        #region Properties
        private readonly IEventRepository eventRepository;
        #endregion

        #region Constructor
        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        #endregion

        #region Action Methods
        // GET: api/Event/5
        [HttpGet]
        public IEnumerable<Event> Get(long tournamentID)
        {
            return this.eventRepository.GetByTournamentID(tournamentID);
        }

        // POST: api/Event
        [HttpPost]
        public int Create(Event _event)
        {
            return this.eventRepository.Create(_event);
        }

        // PUT: api/Event/5
        [HttpPost]
        public bool Update(Event _event)
        {
            return this.eventRepository.Update(_event);
        }

        // DELETE: api/Event/5
        [HttpDelete]
        public bool Delete(long eventID)
        {
            return this.eventRepository.Delete(eventID);
        }
        #endregion
    }
}
