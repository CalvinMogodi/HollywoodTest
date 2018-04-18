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
    public class TournamentRepository : ITournamentRepository
    {
        #region Properties
        private readonly DataAccess.Interface.ITournamentRepository _dataAccessTournamentRepository;
        private readonly EventRepository _eventRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event detail repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public TournamentRepository()
        {
            HollywoodTestEntities hollywoodTestEntities = new HollywoodTestEntities();
            _dataAccessTournamentRepository = new HollywoodTest.DataAccess.Repository.TournamentRepository(hollywoodTestEntities);
            _eventRepository = new EventRepository();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create new tournament
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns>event tournament id</returns>
        public int Create(Tournament tournament)
        {
            return _dataAccessTournamentRepository.Create(tournament);
        }

        /// <summary>
        /// Update existing tournament
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns>true or false</returns>
        public bool Update(Tournament tournament)
        {
            return _dataAccessTournamentRepository.Update(tournament);
        }

        /// <summary>
        /// Get all tournaments
        /// </summary>
        /// <returns>List of tournaments</returns>
        public List<Tournament> GetAll()
        {
           var dbTurnaments = _dataAccessTournamentRepository.GetAll();
            List<Tournament> tournaments = (from t in dbTurnaments select new Tournament {
                TournamentID = t.TournamentID,
                TournamentName = t.TournamentName
            }).ToList();
            return tournaments;
        }

        /// <summary>
        /// Delete tournament by ID
        /// </summary>
        /// <param name="tournamentID"></param>
        /// <returns>true or false</returns>
        public bool Delete(long tournamentID)
        {
            return _dataAccessTournamentRepository.Delete(tournamentID);
        }
        #endregion
    }
}
