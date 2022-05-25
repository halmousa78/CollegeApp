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
using CollegeApp.Models.plan;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 13)]
    public class InitiativesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Initiatives
        public ActionResult Index()
        {
            var initiatives = db.Initiatives.Include(i => i.Standard);
            return View(initiatives.ToList());
        }

        // GET: Initiatives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Initiative initiative = db.Initiatives.Find(id);
            if (initiative == null)
            {
                return HttpNotFound();
            }
            return View(initiative);
        }

        // GET: Initiatives/Create
        public ActionResult Create()
        {
            ViewBag.StandardId = new SelectList(db.Standards, "StandardId", "StandardName");
            return View();
        }

        // POST: Initiatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InitiativeId,InitiativeName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,StandardId,InitiativeStatus,Notes")] Initiative initiative)
        {
            if (ModelState.IsValid)
            {
                db.Initiatives.Add(initiative);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StandardId = new SelectList(db.Standards, "StandardId", "StandardName", initiative.StandardId);
            return View(initiative);
        }

        // GET: Initiatives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Initiative initiative = db.Initiatives.Find(id);
            if (initiative == null)
            {
                return HttpNotFound();
            }
            ViewBag.StandardId = new SelectList(db.Standards, "StandardId", "StandardName", initiative.StandardId);
            return View(initiative);
        }

        // POST: Initiatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InitiativeId,InitiativeName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,StandardId,InitiativeStatus,Notes")] Initiative initiative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(initiative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandardId = new SelectList(db.Standards, "StandardId", "StandardName", initiative.StandardId);
            return View(initiative);
        }

        // GET: Initiatives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Initiative initiative = db.Initiatives.Find(id);
            if (initiative == null)
            {
                return HttpNotFound();
            }
            return View(initiative);
        }

        // POST: Initiatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Initiative initiative = db.Initiatives.Find(id);
            db.Initiatives.Remove(initiative);
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
