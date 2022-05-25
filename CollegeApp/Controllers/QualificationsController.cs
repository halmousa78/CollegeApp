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
    public class QualificationsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Qualifications
        public ActionResult Index()
        {
            var qualifications = db.Qualifications.Include(q => q.User);
            return View(qualifications.ToList());
        }

        // GET: Qualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // GET: Qualifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QualificationId,Degree,institute,year,major,UserId")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();
                qualification.UserId = getUserId;

                db.Qualifications.Add(qualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", qualification.UserId);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", qualification.UserId);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QualificationId,Degree,institute,year,major,UserId")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();
                qualification.UserId = getUserId;

                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", qualification.UserId);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualification qualification = db.Qualifications.Find(id);
            db.Qualifications.Remove(qualification);
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
