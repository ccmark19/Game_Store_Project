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
    public class userInfoesController : Controller
    {
        private Game db = new Game();

        // GET: userInfoes
        public ActionResult Index()
        {
            return View(db.userInfoes.ToList());
        }

        // GET: userInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userInfo userInfo = db.userInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: userInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,favPlatform,favCategory,Address,postCode,City,Country, wantEmail")] userInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.userId = User.Identity.GetUserId();
                db.userInfoes.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "tblGames");
            }

            return View(userInfo);
        }

        // GET: userInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            id = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userInfo UserInfo = (userInfo) db.userInfoes.Where(i => i.userId == id).FirstOrDefault();
            if (UserInfo == null)
            {
                return HttpNotFound();
            }
            return View(UserInfo);
        }

        // POST: userInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,favPlatform,favCategory,Address,postCode,City,Country")] userInfo userInfo)
        {
            userInfo.userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "tblGames");
            }
            return View(userInfo);
        }

        // GET: userInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userInfo userInfo = db.userInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: userInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userInfo userInfo = db.userInfoes.Find(id);
            db.userInfoes.Remove(userInfo);
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
