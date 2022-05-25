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
    public class AwardsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Awards
        public ActionResult Index()
        {
            var awards = db.Awards.Include(a => a.User);
            return View(awards.ToList());
        }

        // GET: Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // GET: Awards/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AwardId,AwardDate,AwardDetail")] Award award)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x=>x.UserEmail == getUserEmail).Select(x=>x.UserId).FirstOrDefault();
                award.UserId = getUserId;

                db.Awards.Add(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", award.UserId);
            return View(award);
        }

        // GET: Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", award.UserId);
            return View(award);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AwardId,AwardDate,AwardDetail,UserId")] Award award)
        {
            if (ModelState.IsValid)
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();
                award.UserId = getUserId;

                db.Entry(award).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", award.UserId);
            return View(award);
        }

        // GET: Awards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Award award = db.Awards.Find(id);
            db.Awards.Remove(award);
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
