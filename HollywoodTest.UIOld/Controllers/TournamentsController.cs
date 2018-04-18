using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HollywoodTest.Shared.Models;
using HollywoodTest.UI.Models;

namespace HollywoodTest.UI.Controllers
{
    [HandleError]
    public class TournamentsController : BaseController
    {
        private TournamentService tournamentService = new TournamentService();

        // GET: Tournaments
        public ActionResult Index()
        {            
            return View(tournamentService.GetTournaments());
        }

        // GET: Tournaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TournamentName")] Tournament tournament)
        {
            tournament.CreatedByUserID = 1;
            tournament.CreatedDate = DateTime.Now;

            int tournamentID = 1;
               await tournamentService.CreateTournament(tournament);
            if(tournamentID != 0)
                return RedirectToAction("Index");
            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TournamentViewModel tournament = db.Tournaments.Find(id);
            //if (tournament == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentID,TournamentName,CreatedDate,CreatedByUserID,ModifiedDate,ModifiedByUserID")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tournament).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TournamentViewModel tournament = db.Tournaments.Find(id);
            //if (tournament == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //TournamentViewModel tournament = db.Tournaments.Find(id);
            ////db.Tournaments.Remove(tournament);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
