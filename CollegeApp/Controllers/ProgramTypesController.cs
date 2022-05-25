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
    public class ProgramTypesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: ProgramTypes
        public ActionResult Index()
        {
            return View(db.ProgramTypes.ToList());
        }

        // GET: ProgramTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramType programType = db.ProgramTypes.Find(id);
            if (programType == null)
            {
                return HttpNotFound();
            }
            return View(programType);
        }

        // GET: ProgramTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramTypeId,ProgramTypeName")] ProgramType programType)
        {
            if (ModelState.IsValid)
            {
                db.ProgramTypes.Add(programType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programType);
        }

        // GET: ProgramTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramType programType = db.ProgramTypes.Find(id);
            if (programType == null)
            {
                return HttpNotFound();
            }
            return View(programType);
        }

        // POST: ProgramTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramTypeId,ProgramTypeName")] ProgramType programType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programType);
        }

        // GET: ProgramTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramType programType = db.ProgramTypes.Find(id);
            if (programType == null)
            {
                return HttpNotFound();
            }
            return View(programType);
        }

        // POST: ProgramTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramType programType = db.ProgramTypes.Find(id);
            db.ProgramTypes.Remove(programType);
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
