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
    public class ExperincesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Experinces
        public ActionResult Index()
        {
            var experinces = db.Experinces.Include(e => e.User);
            return View(experinces.ToList());
        }

        // GET: Experinces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experince experince = db.Experinces.Find(id);
            if (experince == null)
            {
                return HttpNotFound();
            }
            return View(experince);
        }

        // GET: Experinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExperinceId,JobTitle,CompanyName,StartDate,EndDate,ExperinceDetail,UserId")] Experince experince)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();
                experince.UserId = getUserId;

                db.Experinces.Add(experince);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", experince.UserId);
            return View(experince);
        }

        // GET: Experinces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experince experince = db.Experinces.Find(id);
            if (experince == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", experince.UserId);
            return View(experince);
        }

        // POST: Experinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExperinceId,JobTitle,CompanyName,StartDate,EndDate,ExperinceDetail,UserId")] Experince experince)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();
                experince.UserId = getUserId;

                db.Entry(experince).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", experince.UserId);
            return View(experince);
        }

        // GET: Experinces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experince experince = db.Experinces.Find(id);
            if (experince == null)
            {
                return HttpNotFound();
            }
            return View(experince);
        }

        // POST: Experinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experince experince = db.Experinces.Find(id);
            db.Experinces.Remove(experince);
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
