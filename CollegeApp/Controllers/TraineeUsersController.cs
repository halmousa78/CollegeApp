using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeApp.Data;
using CollegeApp.Models.Account;

namespace CollegeApp.Controllers
{
    public class TraineeUsersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: TraineeUsers
        public ActionResult Index()
        {
            var traineeUsers = db.TraineeUsers.Include(t => t.DepartmentName).Include(t => t.Role);
            return View(traineeUsers.ToList());
        }

        // GET: TraineeUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeUser traineeUser = db.TraineeUsers.Find(id);
            if (traineeUser == null)
            {
                return HttpNotFound();
            }
            return View(traineeUser);
        }

        // GET: TraineeUsers/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: TraineeUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,UserPassword,UserEmail,UserMobile,DepartmentId,UserStatus,CreatedDate,RoleId,DateCv,ExperienceYears,EngilshLevel,Addressline1,Addressline2,Addressline3,Image")] TraineeUser traineeUser)
        {
            if (ModelState.IsValid)
            {
                db.TraineeUsers.Add(traineeUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", traineeUser.DepartmentId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", traineeUser.RoleId);
            return View(traineeUser);
        }

        // GET: TraineeUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeUser traineeUser = db.TraineeUsers.Find(id);
            if (traineeUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", traineeUser.DepartmentId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", traineeUser.RoleId);
            return View(traineeUser);
        }

        // POST: TraineeUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,UserPassword,UserEmail,UserMobile,DepartmentId,UserStatus,CreatedDate,RoleId,DateCv,ExperienceYears,EngilshLevel,Addressline1,Addressline2,Addressline3,Image")] TraineeUser traineeUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traineeUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", traineeUser.DepartmentId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", traineeUser.RoleId);
            return View(traineeUser);
        }

        // GET: TraineeUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeUser traineeUser = db.TraineeUsers.Find(id);
            if (traineeUser == null)
            {
                return HttpNotFound();
            }
            return View(traineeUser);
        }

        // POST: TraineeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraineeUser traineeUser = db.TraineeUsers.Find(id);
            db.TraineeUsers.Remove(traineeUser);
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
