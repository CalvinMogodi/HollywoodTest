using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HollywoodTest.Shared.Models;
using HollywoodTest.UI.Models;
using HollywoodTest.UI.Services;

namespace HollywoodTest.UI.Controllers
{
    [HandleError]
    [Authorize]
    public class EventsController : BaseController
    {
        private EventService eventService = new EventService();
        private TournamentService tournamentService = new TournamentService();
        private long TournamentID;
        private IEnumerable<Tournament> Tournaments;

        // GET: Events
        public ActionResult Index(long tournamentID)
        {
            if (tournamentID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session["TournamentID"] = Convert.ToString(tournamentID);
            var eventDetails = eventService.GetEvents(tournamentID);
            return View(eventDetails.ToList());
        }
        
        // GET: Events/Create
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Create()
        {
            ViewBag.TournamentID = new SelectList(tournamentService.GetTournaments(), "TournamentID", "TournamentName");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Create([Bind(Include = "EventID,TournamentID,EventName,EventNumber,EventDateTime,EventEndDateTime,AutoClose")] Event _event)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction("Index", new { tournamentID = TournamentID });
            }

            ViewBag.TournamentID = new SelectList(tournamentService.GetTournaments(), "TournamentID", "TournamentName", _event.TournamentID);
            return View(_event);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Edit(Event _event)
        {
            if (_event == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.TournamentID = new SelectList(tournamentService.GetTournaments(), "TournamentID", "TournamentName", _event.TournamentID);
            return View(_event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Edit([Bind(Include = "EventID,TournamentID,EventName,EventNumber,EventDateTime,EventEndDateTime,AutoClose,CreatedDate,CreatedByUserID,ModifiedDate,ModifiedByUserID")] EventService @event)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
           // ViewBag.TournamentID = new SelectList(db.Tournaments, "TournamentID", "TournamentName", @event.TournamentID);
            return View(@event);
        }

        // GET: Events/Delete/5
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventService @event = new EventService();
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult DeleteConfirmed(long id)
        {
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
