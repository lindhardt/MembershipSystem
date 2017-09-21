using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MembershipSystem.Models;

namespace MembershipSystem.Controllers
{
    public class UserClaimsController : Controller
    {
        private MembershipContext db = new MembershipContext();

        // GET: UserClaims
        public ActionResult Index()
        {
            return View(db.UserClaims.ToList());
        }

        // GET: UserClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClaim userClaim = db.UserClaims.Find(id);
            if (userClaim == null)
            {
                return HttpNotFound();
            }
            return View(userClaim);
        }

        // GET: UserClaims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Id,ClaimType,ClaimValue")] UserClaim userClaim)
        {
            if (ModelState.IsValid)
            {
                db.UserClaims.Add(userClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userClaim);
        }

        // GET: UserClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClaim userClaim = db.UserClaims.Find(id);
            if (userClaim == null)
            {
                return HttpNotFound();
            }
            return View(userClaim);
        }

        // POST: UserClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Id,ClaimType,ClaimValue")] UserClaim userClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userClaim);
        }

        // GET: UserClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClaim userClaim = db.UserClaims.Find(id);
            if (userClaim == null)
            {
                return HttpNotFound();
            }
            return View(userClaim);
        }

        // POST: UserClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserClaim userClaim = db.UserClaims.Find(id);
            db.UserClaims.Remove(userClaim);
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
