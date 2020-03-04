using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using gaimz.Models;
using Microsoft.AspNet.Identity;

namespace gaimz.Controllers
{
    public class WishlistsController : Controller
    {
        private Game db = new Game();

        // GET: Wishlists
        public ActionResult Index(string id)
        {   
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }
            
            if (id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            List<tblWishlist> lst = db.tblWishlists.Where(i => i.userId == id).ToList();
            if (lst == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = id;
            return View(lst);
        }

        public ActionResult viewAllWishList()
        {
            var list = db.tblWishlists.GroupBy(o=>new { o.userId}).Select(o=>o.FirstOrDefault());
            return View(list);
        }


        // GET: Wishlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWishlist tblWishlist = db.tblWishlists.Find(id);
            if (tblWishlist == null)
            {
                return HttpNotFound();
            }
            return View(tblWishlist);
        }

        // GET: Wishlists/Create
        public ActionResult Create(int? id)
        {
            string userId = User.Identity.GetUserId();
            tblWishlist wishlist = new tblWishlist();
            wishlist.userId = userId;
            wishlist.gameId = id;

            if(wishlist.userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            db.tblWishlists.Add(wishlist);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        // POST: Wishlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wishlistId,userId,gameId")] tblWishlist tblWishlist)
        {
            if (ModelState.IsValid)
            {
               
                
                db.tblWishlists.Add(tblWishlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblWishlist);
        }

        // GET: Wishlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWishlist tblWishlist = db.tblWishlists.Find(id);
            if (tblWishlist == null)
            {
                return HttpNotFound();
            }
            return View(tblWishlist);
        }

        // POST: Wishlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wishlistId,userId,gameId")] tblWishlist tblWishlist)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                db.Entry(tblWishlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblWishlist);
        }

        // GET: Wishlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWishlist tblWishlist = db.tblWishlists.Find(id);
            if (tblWishlist == null)
            {
                return HttpNotFound();
            }
            return View(tblWishlist);
        }

        // POST: Wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWishlist tblWishlist = db.tblWishlists.Find(id);
            db.tblWishlists.Remove(tblWishlist);
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
