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
    public class UserViewRolesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: UserViewRoles
        public ActionResult Index()
        {
            var userViewRoles = db.UserViewRoles.Include(u => u.Role).Include(u => u.UserView);
            return View(userViewRoles.ToList());
        }

        // GET: UserViewRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewRole userViewRole = db.UserViewRoles.Find(id);
            if (userViewRole == null)
            {
                return HttpNotFound();
            }
            return View(userViewRole);
        }

        // GET: UserViewRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            ViewBag.UserViewId = new SelectList(db.UserViews, "UserViewId", "UserViewName");
            return View();
        }

        // POST: UserViewRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserViewRoleId,RoleId,UserViewId")] UserViewRole userViewRole)
        {
            if (ModelState.IsValid)
            {
                db.UserViewRoles.Add(userViewRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userViewRole.RoleId);
            ViewBag.UserViewId = new SelectList(db.UserViews, "UserViewId", "UserViewName", userViewRole.UserViewId);
            return View(userViewRole);
        }

        // GET: UserViewRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewRole userViewRole = db.UserViewRoles.Find(id);
            if (userViewRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userViewRole.RoleId);
            ViewBag.UserViewId = new SelectList(db.UserViews, "UserViewId", "UserViewName", userViewRole.UserViewId);
            return View(userViewRole);
        }

        // POST: UserViewRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserViewRoleId,RoleId,UserViewId")] UserViewRole userViewRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userViewRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userViewRole.RoleId);
            ViewBag.UserViewId = new SelectList(db.UserViews, "UserViewId", "UserViewName", userViewRole.UserViewId);
            return View(userViewRole);
        }

        // GET: UserViewRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewRole userViewRole = db.UserViewRoles.Find(id);
            if (userViewRole == null)
            {
                return HttpNotFound();
            }
            return View(userViewRole);
        }

        // POST: UserViewRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserViewRole userViewRole = db.UserViewRoles.Find(id);
            db.UserViewRoles.Remove(userViewRole);
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
