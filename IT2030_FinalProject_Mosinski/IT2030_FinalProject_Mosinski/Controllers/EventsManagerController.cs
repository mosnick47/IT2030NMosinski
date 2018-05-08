using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT2030_FinalProject_Mosinski.Models;

namespace IT2030_FinalProject_Mosinski.Controllers
{
    public class EventsManagerController : Controller
    {
        private IT2030_FinalProject_MosinskiDB db = new IT2030_FinalProject_MosinskiDB();

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult EventSearch(string q)
        {
            var events = GetEvents(q);

            return PartialView(events);
        }

        private List<Events> GetEvents(string searchString)
        {
            return db.Events.Where(x => x.EventTitle.Contains(searchString) || x.EventDescription.Contains(searchString)).ToList();
        }

        // GET: EventsManager
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: EventsManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        [Authorize]
        // GET: EventsManager/Create
        public ActionResult Create()
        {
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventType");
            return View();
        }

        // POST: EventsManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventTitle,EventDescription,StartDate,StartTime,EndDate,EndTime,EventLocation,EventType,OrganizationFirstName,OrganizerLastName,OrgananizerPhone,OrganizerEmail,MaxTickets,AvailableTickets")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);
        }

        // GET: EventsManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: EventsManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventTitle,EventDescription,StartDate,StartTime,EndDate,EndTime,EventCity,EventState,EventZip,EventAddress,EventType,OrganizationFirstName,OrganizerLastName,OrgananizerPhone,OrganizerEmail,MaxTickets,AvailableTickets")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: EventsManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: EventsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Events events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
