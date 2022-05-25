//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using CollegeApp.Data;
//using CollegeApp.Models;

//namespace CollegeApp.Controllers.Old
//{
//    [Permission]
//    [ViewPermissionFilter(ViewId = 1)]
//    public class UsersoldController : Controller
//    {
//        private MyDbContext db = new MyDbContext();

//        // GET: Users
//        public ActionResult Index()
//        {
//            //var users = db.Users.Include(u => u.Role);
//            ViewBag.role = db.Roles.ToList();
            
//            return View();
//        }

//        // GET: Users/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // GET: Users/Create
//        public ActionResult Create()
//        {
//            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
//            return View();
//        }

//        // POST: Users/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        public ActionResult Create(User user)
//        {
//            try
//            {
//                var getUserId = db.Users.Select(x => x.UserId).Max() + 1;
//                user.UserId = getUserId;
//                db.Users.Add(user);
//                db.SaveChanges();
//                return Json("Done");


//            }
//            catch (Exception)
//            {

//                return Json("error");
//            }
               

            
//        }

//        // GET: Users/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", user.RoleId);
//            return View(user);
//        }

//        // POST: Users/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "UserId,UserName,UserPassword,UserEmail,UserMobile,RoleId")] User user)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(user).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", user.RoleId);
//            return View(user);
//        }

//        // GET: Users/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: Users/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            User user = db.Users.Find(id);
//            db.Users.Remove(user);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
