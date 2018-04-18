using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HollywoodTest.UI.Models;
using HollywoodTest.UI.Services;

namespace HollywoodTest.UI.Controllers
{
    [HandleError]
    [Authorize]
    public class EventDetailsController : BaseController
    {
        private EventDetailService eventDetailService = new EventDetailService();

        // GET: EventDetails
        public ActionResult Index(long eventID)
        {
            if (eventID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var eventDetails = eventDetailService.GetEventDetails(eventID);
            return View(eventDetails.ToList());
        }


        // GET: EventDetails/Create
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Create()
        {
            //ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Create([Bind(Include = "EventDetailID,EventID,EventDetailStatusID,EventDetailName,EventDetailNumber,EventDetailsOdd,FinishingPosition,FirstTimer,CreatedDate,CreatedByUserID,ModifiedDate,ModifiedByUserID")] EventDetailService eventDetail)
        {
            if (ModelState.IsValid)
            {
                //db.EventDetails.Add(eventDetail);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

          //  ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.EventID);
            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // EventDetailService eventDetail = db.EventDetails.Find(id);
            //if (eventDetail == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.EventID);
            return View();
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult Edit([Bind(Include = "EventDetailID,EventID,EventDetailStatusID,EventDetailName,EventDetailNumber,EventDetailsOdd,FinishingPosition,FirstTimer,CreatedDate,CreatedByUserID,ModifiedDate,ModifiedByUserID")] EventDetailService eventDetail)
        {
            return View();
        }

        // GET: EventDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EventDetailService eventDetail = db.EventDetails.Find(id);
            //if (eventDetail == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: EventDetails/Delete/5
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
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
