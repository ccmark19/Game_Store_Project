using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gaimz.Models;

namespace gaimz.Controllers
{
    public class user_eventController : Controller
    {
        private Game db = new Game();

        // GET: user_event
        public ActionResult Index()
        {
            return View(db.user_event.ToList());
        }

        // GET: user_event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_event user_event = db.user_event.Find(id);
            if (user_event == null)
            {
                return HttpNotFound();
            }
            return View(user_event);
        }

        // GET: user_event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_event_ID,userId,eventID")] user_event user_event)
        {
            if (ModelState.IsValid)
            {
                db.user_event.Add(user_event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_event);
        }

        // GET: user_event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_event user_event = db.user_event.Find(id);
            if (user_event == null)
            {
                return HttpNotFound();
            }
            return View(user_event);
        }

        // POST: user_event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_event_ID,userId,eventID")] user_event user_event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_event);
        }

        // GET: user_event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_event user_event = db.user_event.Find(id);
            if (user_event == null)
            {
                return HttpNotFound();
            }
            return View(user_event);
        }

        // POST: user_event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_event user_event = db.user_event.Find(id);
            db.user_event.Remove(user_event);
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
