using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gaimz.Models;
using Microsoft.AspNet.Identity;

namespace gaimz.Controllers
{
    public class tblReviewsController : Controller
    {
        private Game db = new Game();

        // GET: tblReviews
        public ActionResult Index()
        {
            return View(db.tblReviews.ToList());
        }

        // GET: tblReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReview tblReview = db.tblReviews.Find(id);
            if (tblReview == null)
            {
                return HttpNotFound();
            }
            return View(tblReview);
        }

        // GET: tblReviews/Create
        public ActionResult Create(int id)
        {
            tblGame Games = (tblGame)db.tblGames.Where(i => i.gameId == id).FirstOrDefault();
            tblReview tblReview = new tblReview();
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                tblReview.gameID = id;
                tblReview.userID = userId;
                tblReview.gameName = Games.gameName;
                db.tblReviews.Add(tblReview);
                db.SaveChanges();
                return RedirectToAction("Edit", new
                {
                    id = tblReview.reviewID
                });
            }
        }

        // POST: tblReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reviewID, gameID, userID, review,rating,gameName")] tblReview tblReview)
        {
            var id = tblReview.gameID;
            if (ModelState.IsValid)
            {
            }

            return View("Details", "tblGames", id);
        }

        // GET: tblReviews/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReview tblReview = db.tblReviews.Find(id);
            if (tblReview == null)
            {
                return HttpNotFound();
            }
            return View(tblReview);
        }

        // POST: tblReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reviewID,gameID,userID,review,rating,gameName")] tblReview tblReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblReview);
        }

        // GET: tblReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReview tblReview = db.tblReviews.Find(id);
            if (tblReview == null)
            {
                return HttpNotFound();
            }
            return View(tblReview);
        }

        // POST: tblReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblReview tblReview = db.tblReviews.Find(id);
            db.tblReviews.Remove(tblReview);
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
