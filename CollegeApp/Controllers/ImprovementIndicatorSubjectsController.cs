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
    public class ImprovementIndicatorSubjectsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: ImprovementIndicatorSubjects
        public ActionResult Index()
        {
            return View(db.ImprovementIndicatorSubjects.ToList());
        }

        // GET: ImprovementIndicatorSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImprovementIndicatorSubject improvementIndicatorSubject = db.ImprovementIndicatorSubjects.Find(id);
            if (improvementIndicatorSubject == null)
            {
                return HttpNotFound();
            }
            return View(improvementIndicatorSubject);
        }

        // GET: ImprovementIndicatorSubjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImprovementIndicatorSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImprovementIndicatorSubjectId,ImprovementIndicatorSubjectName")] ImprovementIndicatorSubject improvementIndicatorSubject)
        {
            if (ModelState.IsValid)
            {
                db.ImprovementIndicatorSubjects.Add(improvementIndicatorSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(improvementIndicatorSubject);
        }

        // GET: ImprovementIndicatorSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImprovementIndicatorSubject improvementIndicatorSubject = db.ImprovementIndicatorSubjects.Find(id);
            if (improvementIndicatorSubject == null)
            {
                return HttpNotFound();
            }
            return View(improvementIndicatorSubject);
        }

        // POST: ImprovementIndicatorSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImprovementIndicatorSubjectId,ImprovementIndicatorSubjectName")] ImprovementIndicatorSubject improvementIndicatorSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(improvementIndicatorSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(improvementIndicatorSubject);
        }

        // GET: ImprovementIndicatorSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImprovementIndicatorSubject improvementIndicatorSubject = db.ImprovementIndicatorSubjects.Find(id);
            if (improvementIndicatorSubject == null)
            {
                return HttpNotFound();
            }
            return View(improvementIndicatorSubject);
        }

        // POST: ImprovementIndicatorSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImprovementIndicatorSubject improvementIndicatorSubject = db.ImprovementIndicatorSubjects.Find(id);
            db.ImprovementIndicatorSubjects.Remove(improvementIndicatorSubject);
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
