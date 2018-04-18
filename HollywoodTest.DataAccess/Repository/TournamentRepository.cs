using HollywoodTest.DataAccess.Interface;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        #region Properties
        private readonly HollywoodTestEntities _db;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event detail repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public TournamentRepository(HollywoodTestEntities db) 
        {
            _db = db;
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
            try
            {
                return _db.prtbTournament_Insert(tournament.TournamentName).FirstOrDefault().Value;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Update existing tournament
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns>true or false</returns>
        public bool Update(Tournament tournament)
        {
            try
            {
                _db.prtbTournament_Update(tournament.TournamentID, tournament.TournamentName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all tournaments
        /// </summary>
        /// <returns>List of tournaments</returns>
        public List<prtbTournament_GetAll_Result> GetAll()
        {
            return _db.prtbTournament_GetAll().ToList();           
        }

        /// <summary>
        /// Delete tournament by ID
        /// </summary>
        /// <param name="tournamentID"></param>
        /// <returns>true or false</returns>
        public bool Delete(long tournamentID)
        {
            try
            {
                _db.prtbTournament_Delete(tournamentID);
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
