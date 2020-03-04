using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using gaimz.Models;
using Microsoft.AspNet.Identity;

namespace gaimz.Controllers
{
    public class tblGamesController : Controller
    {
        private Game db = new Game();
        // GET: tblGames
        public ActionResult Index()
        {
            if (Roles.IsUserInRole(User.Identity.Name, "Employee"))
            {
                return View(db.tblGames.ToList());
            }
            else
            {
               return RedirectToAction("viewGame");
            }
        }

        // GET: tblGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGame tblGame = db.tblGames.Find(id);
            if (tblGame == null)
            {
                return HttpNotFound();
            }
            return View(tblGame);
        }
        public ActionResult SearchGame(string searching)
        {
            return View(db.tblGames.Where(x => x.gameName.StartsWith(searching) || searching == null).ToList());
        }

        // GET: tblGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gameId,gameName,gameDesc,gameGenre")] tblGame tblGame)
        {
            if (ModelState.IsValid)
            {
                db.tblGames.Add(tblGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblGame);
        }

        // GET: tblGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGame tblGame = db.tblGames.Find(id);
            if (tblGame == null)
            {
                return HttpNotFound();
            }
            return View(tblGame);
        }

        // POST: tblGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gameId,gameName,gameDesc,gameGenre")] tblGame tblGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGame);
        }

        // GET: tblGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGame tblGame = db.tblGames.Find(id);
            if (tblGame == null)
            {
                return HttpNotFound();
            }
            return View(tblGame);
        }

        // POST: tblGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGame tblGame = db.tblGames.Find(id);
            db.tblGames.Remove(tblGame);
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

        public ActionResult viewGame()
        {
            return View(db.tblGames.ToList());
        }
    }
}
