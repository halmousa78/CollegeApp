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
using CollegeApp.Models.Cvs;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 13)]
    public class TrainingCoursesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: TrainingCourses
        public ActionResult Index()
        {
            var trainingCourses = db.TrainingCourses.Include(t => t.User);
            return View(trainingCourses.ToList());
        }

        // GET: TrainingCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            if (trainingCourse == null)
            {
                return HttpNotFound();
            }
            return View(trainingCourse);
        }

        // GET: TrainingCourses/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: TrainingCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainingCourseId,InstitutionName,StartDate,EndDate,TrainingCourseDetail,UserId")] TrainingCourse trainingCourse)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();
                trainingCourse.UserId = getUserId;

                db.TrainingCourses.Add(trainingCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", trainingCourse.UserId);
            return View(trainingCourse);
        }

        // GET: TrainingCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            if (trainingCourse == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", trainingCourse.UserId);
            return View(trainingCourse);
        }

        // POST: TrainingCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainingCourseId,InstitutionName,StartDate,EndDate,TrainingCourseDetail,UserId")] TrainingCourse trainingCourse)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();
                trainingCourse.UserId = getUserId;

                db.Entry(trainingCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", trainingCourse.UserId);
            return View(trainingCourse);
        }

        // GET: TrainingCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            if (trainingCourse == null)
            {
                return HttpNotFound();
            }
            return View(trainingCourse);
        }

        // POST: TrainingCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            db.TrainingCourses.Remove(trainingCourse);
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
