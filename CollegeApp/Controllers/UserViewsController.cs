using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeApp.Data;
using CollegeApp.Models;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class UserViewsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: UserViews
        public ActionResult Index()
        {
            return View(db.UserViews.ToList());
        }

        // GET: UserViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = db.UserViews.Find(id);
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        // GET: UserViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserViews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserViewId,UserViewName")] UserView userView)
        {
            if (ModelState.IsValid)
            {
                db.UserViews.Add(userView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userView);
        }

        // GET: UserViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = db.UserViews.Find(id);
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        // POST: UserViews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserViewId,UserViewName")] UserView userView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userView);
        }

        // GET: UserViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = db.UserViews.Find(id);
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        // POST: UserViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserView userView = db.UserViews.Find(id);
            db.UserViews.Remove(userView);
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
