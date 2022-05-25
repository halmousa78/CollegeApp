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
    public class PlansStudiesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: PlansStudies
        [ViewPermissionFilter(ViewId = 13)]
        public ActionResult Index()
        {
            var plansStudies = db.PlansStudies.Include(p => p.Term);
            return View(plansStudies.ToList());
        }

        // GET: PlansStudies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlansStudy plansStudy = db.PlansStudies.Find(id);
            if (plansStudy == null)
            {
                return HttpNotFound();
            }
            return View(plansStudy);
        }

        // GET: PlansStudies/Create
        public ActionResult Create()
        {
            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName");
            return View();
        }

        // POST: PlansStudies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlansStudyId,CourseId,TermId,CreatedDate,UsersCreated,CourseDescription,Topics,References,Recommended,Week1,GradeWeek1,Week2,GradeWeek2,Week3,GradeWeek3,Week4,GradeWeek4,Week5,GradeWeek5,Week6,GradeWeek6,Week7,GradeWeek7,Week8,GradeWeek8,Week9,GradeWeek9,Week10,GradeWeek10,Week11,GradeWeek11,Week12,GradeWeek12,Week13,GradeWeek13,Week14,GradeWeek14,Week15,GradeWeek15,Week16,GradeWeek16,PlansStudyStatus")] PlansStudy plansStudy)
        {
            if (ModelState.IsValid)
            {
                db.PlansStudies.Add(plansStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName", plansStudy.TermId);
            return View(plansStudy);
        }

        // GET: PlansStudies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlansStudy plansStudy = db.PlansStudies.Find(id);
            if (plansStudy == null)
            {
                return HttpNotFound();
            }
            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName", plansStudy.TermId);
            return View(plansStudy);
        }

        // POST: PlansStudies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlansStudyId,CourseId,TermId,CreatedDate,UsersCreated,CourseDescription,Topics,References,Recommended,Week1,GradeWeek1,Week2,GradeWeek2,Week3,GradeWeek3,Week4,GradeWeek4,Week5,GradeWeek5,Week6,GradeWeek6,Week7,GradeWeek7,Week8,GradeWeek8,Week9,GradeWeek9,Week10,GradeWeek10,Week11,GradeWeek11,Week12,GradeWeek12,Week13,GradeWeek13,Week14,GradeWeek14,Week15,GradeWeek15,Week16,GradeWeek16,PlansStudyStatus")] PlansStudy plansStudy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plansStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName", plansStudy.TermId);
            return View(plansStudy);
        }

        // GET: PlansStudies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlansStudy plansStudy = db.PlansStudies.Find(id);
            if (plansStudy == null)
            {
                return HttpNotFound();
            }
            return View(plansStudy);
        }

        // POST: PlansStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlansStudy plansStudy = db.PlansStudies.Find(id);
            db.PlansStudies.Remove(plansStudy);
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
