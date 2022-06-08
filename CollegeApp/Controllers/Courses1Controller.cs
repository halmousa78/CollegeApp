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
    public class Courses1Controller : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Courses1
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Major);
            return View(courses.ToList());
        }

        // GET: Courses1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses1/Create
        public ActionResult Create()
        {
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName");
            return View();
        }

        // POST: Courses1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,MajorId,level,CourseName,Lecture,Practical,CreditHours,ContactHours,Tutorial,Prerequisites,CourseStatus")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", course.MajorId);
            return View(course);
        }

        // GET: Courses1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", course.MajorId);
            return View(course);
        }

        // POST: Courses1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,MajorId,level,CourseName,Lecture,Practical,CreditHours,ContactHours,Tutorial,Prerequisites,CourseStatus")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", course.MajorId);
            return View(course);
        }

        // GET: Courses1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
