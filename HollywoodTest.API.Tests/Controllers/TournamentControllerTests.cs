using Microsoft.VisualStudio.TestTools.UnitTesting;
using HollywoodTest.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTest.Business.Repository;
using HollywoodTest.Shared.Models;

namespace HollywoodTest.API.Controllers.Tests
{
    [TestClass()]
    public class TournamentControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            TournamentRepository tournamentRepository = new TournamentRepository();
            TournamentController controller = new TournamentController(tournamentRepository);

            // Act
            IEnumerable<Tournament> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void PostTest()
        {
            // Arrange
            TournamentRepository tournamentRepository = new TournamentRepository();
            TournamentController controller = new TournamentController(tournamentRepository);
            Tournament tournament = new Tournament()
            {
                TournamentName = "Create Tournament API Unit Test",
            };

            // Act
            int tournamentID = controller.Create(tournament);

            // Assert
            Assert.AreNotEqual(tournamentID, 0);
        }

        [TestMethod()]
        public void PutTest()
        {
            // Arrange
            TournamentRepository tournamentRepository = new TournamentRepository();
            TournamentController controller = new TournamentController(tournamentRepository);
            Tournament tournament = new Tournament()
            {
                TournamentName = "Update Tournament Unit Test",
            };

            // Act
            int tournamentID = controller.Create(tournament);
            tournament.TournamentID = tournamentID;
            tournament.TournamentName = "Updated Tournament API Unit Test";
            bool isUpdated = controller.Update(tournament);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            TournamentRepository tournamentRepository = new TournamentRepository();
            TournamentController controller = new TournamentController(tournamentRepository);
            Tournament tournament = new Tournament()
            {
                TournamentName = "Delete Tournament Unit Test",
            };

            // Act
            int tournamentID = controller.Create(tournament);
            bool isDeleted = controller.Delete(tournamentID);

            // Assert
            Assert.IsTrue(isDeleted);
        }
    }
}