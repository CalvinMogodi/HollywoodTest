using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HollywoodTest.Shared.Enums;
using HollywoodTest.Shared.Models;
using HollywoodTest.UI.Models;
using HollywoodTest.UI.Services;

namespace HollywoodTest.UI.Controllers
{
    [HandleError]
    [Authorize]
    public class TournamentsController : BaseController
    {
        private TournamentService tournamentService = new TournamentService();

        // GET: Tournaments
        public ActionResult Index()
        {           
            return View(tournamentService.GetTournaments());
        }

        // GET: Tournaments/Create
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SysAdmin")]
        public async Task<ActionResult> Create([Bind(Include = "TournamentName")] Tournament tournament)
        {
            if (await tournamentService.CreateTournament(tournament))
            {
                ShowResult(ResultCode.Success, "Create Tournament", "Tournament is created Successful");
                return RedirectToAction("Index");
            }
            else
                ShowResult(ResultCode.Error, "Create Tournament", "Tournament is not created Successful");
            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Edit(Tournament tournament)
        {
            if (tournament == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(tournament);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SysAdmin")]
        public async Task<ActionResult> EditTournament([Bind(Include = "TournamentID,TournamentName")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                if (await tournamentService.UpdateTournament(tournament))
                {
                    ShowResult(ResultCode.Success, "Update Tournament", "Tournament is updated Successful");
                    return RedirectToAction("Index");
                }
                else
                    ShowResult(ResultCode.Error, "Update Tournament", "Tournament is not updated Successful");
            }
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        [Authorize(Roles = "SysAdmin")]
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (await tournamentService.DeleteTournament(id.Value))
            {
                ShowResult(ResultCode.Success, "Delete Tournament", "Tournament is deleted Successful");
            }
            else
                ShowResult(ResultCode.Error, "Delete Tournament", "Tournament is not deleted Successful");

            return RedirectToAction("Index");
        }
    }
}
