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
using CollegeApp.Models.ImprovementIndicator;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class InitiativeScopesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: InitiativeScopes
        public ActionResult Index()
        {
            return View(db.InitiativeScopes.ToList());
        }

        // GET: InitiativeScopes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InitiativeScope initiativeScope = db.InitiativeScopes.Find(id);
            if (initiativeScope == null)
            {
                return HttpNotFound();
            }
            return View(initiativeScope);
        }

        // GET: InitiativeScopes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InitiativeScopes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InitiativeScopeId,InitiativeScopeName")] InitiativeScope initiativeScope)
        {
            if (ModelState.IsValid)
            {
                db.InitiativeScopes.Add(initiativeScope);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(initiativeScope);
        }

        // GET: InitiativeScopes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InitiativeScope initiativeScope = db.InitiativeScopes.Find(id);
            if (initiativeScope == null)
            {
                return HttpNotFound();
            }
            return View(initiativeScope);
        }

        // POST: InitiativeScopes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InitiativeScopeId,InitiativeScopeName")] InitiativeScope initiativeScope)
        {
            if (ModelState.IsValid)
            {
                db.Entry(initiativeScope).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(initiativeScope);
        }

        // GET: InitiativeScopes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InitiativeScope initiativeScope = db.InitiativeScopes.Find(id);
            if (initiativeScope == null)
            {
                return HttpNotFound();
            }
            return View(initiativeScope);
        }

        // POST: InitiativeScopes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InitiativeScope initiativeScope = db.InitiativeScopes.Find(id);
            db.InitiativeScopes.Remove(initiativeScope);
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
