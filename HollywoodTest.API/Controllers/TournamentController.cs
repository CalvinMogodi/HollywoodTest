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
    public class TournamentController : ApiController
    {
        #region Properties
        private readonly ITournamentRepository tournamentRepository;
        #endregion

        #region Constructor
        public TournamentController(ITournamentRepository eournamentRepository)
        {
            this.tournamentRepository = eournamentRepository;
        }

        #endregion

        #region Action Methods
        // GET: api/Tournament
        [HttpGet]
        public IEnumerable<Tournament> Get()
        {
            return tournamentRepository.GetAll();
        }

        // POST: api/Tournament
        [HttpPost]
        public int Create(Tournament tournament)
        {
            return tournamentRepository.Create(tournament);
        }

        // PUT: api/Tournament/5
        [HttpPut]
        public bool Update(Tournament tournament)
        {
            return tournamentRepository.Update(tournament);
        }

        // DELETE: api/Tournament/5
        [HttpDelete]
        public bool Delete(long tournamentID)
        {
            return tournamentRepository.Delete(tournamentID);
        }
        #endregion
    }
}
