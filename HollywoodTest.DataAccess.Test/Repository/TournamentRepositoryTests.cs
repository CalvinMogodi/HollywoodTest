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
    public class TournamentRepositoryTests
    {
        #region Test Methods

        /// <summary>
        /// Create tournament test
        /// </summary>        
        [TestMethod()]
        [Priority(1)]
        public void CreateTournamentTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            TournamentRepository tournamentRepository = new TournamentRepository(dataContext);
            Tournament tournament = new Tournament() {
                TournamentName = "Create Tournament Data Access Unit Test",
                };

            // Act
            int tournamentID = tournamentRepository.Create(tournament);

            // Assert
            Assert.AreNotEqual(tournamentID,0);
        }

        /// <summary>
        /// Update tournament test
        /// </summary>
        [TestMethod()]
        public void UpdateTournamentTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            TournamentRepository tournamentRepository = new TournamentRepository(dataContext);
            Tournament tournament = new Tournament()
            {
                TournamentName = "Update Tournament Data Access Unit Test",
            };

            // Act
            int tournamentID = tournamentRepository.Create(tournament);
            tournament.TournamentID = tournamentID;
            bool isUpdated = tournamentRepository.Update(tournament);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        /// <summary>
        /// Get all tournaments test
        /// </summary>
        [TestMethod()]
        public void GetAllTournamentsTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            TournamentRepository tournamentRepository = new TournamentRepository(dataContext);

            // Act
            var tournaments = tournamentRepository.GetAll();

            // Assert
            Assert.AreNotEqual(tournaments.Count(), 0);
        }

        /// <summary>
        /// Delete tournament test
        /// </summary>
        [TestMethod()]
        public void DeleteTournamentTest()
        {
            // Arrange
            HollywoodTestEntities dataContext = new HollywoodTestEntities();
            TournamentRepository tournamentRepository = new TournamentRepository(dataContext);
            Tournament tournament = new Tournament()
            {
                TournamentName = "Delete Tournament Data Access Unit Test",
            };

            // Act
            int tournamentID = tournamentRepository.Create(tournament);
            bool isDeleted = tournamentRepository.Delete(tournamentID);

            // Assert
            Assert.IsTrue(isDeleted);
        }
        #endregion
    }
}