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

//namespace CollegeApp.Controllers
//{
//    [Permission]
//    [ViewPermissionFilter(ViewId = 1)]
//    public class CoursesController : Controller
//    {
//        private MyDbContext db = new MyDbContext();

//        // GET: Courses
//        public ActionResult Index()
//        {
//            var courses = db.Courses.Include(c => c.Major).OrderBy(x=>x.level);
//            return View(courses.ToList());
//        }

//        [ViewPermissionFilter(ViewId = 13)]
//        public ActionResult Courses()
//        {
//            if (!(Session["UserEmail"] == null))
//            {
//                var getUser = Session["UserName"].ToString();
//                var getDepartmentId = db.Users.Where(x => x.UserName == getUser).Select(x => x.DepartmentId).FirstOrDefault();



//                if (getDepartmentId == 1)
//                {
//                    var majorList = db.Majors.Where(x => x.MajorStatus == true & x.DepartmentId == getDepartmentId).Select(x => x.MajorName).ToList();
//                    SelectList majorSelectList = new SelectList(majorList);
//                    ViewBag.majorSelectList = majorSelectList;

//                    var courses = db.Courses.Include(c => c.Major).Where(x => x.Major.DepartmentId == 1 || x.Major.DepartmentId == 1).OrderBy(x => x.level);
//                    return View(courses.ToList());
//                }
//                else if (getDepartmentId == 2)
//                {
//                    var majorList = db.Majors.Where(x => x.MajorStatus == true & x.DepartmentId == getDepartmentId).Select(x => x.MajorName).ToList();
//                    SelectList majorSelectList = new SelectList(majorList);
//                    ViewBag.majorSelectList = majorSelectList;

//                    //var courses = db.Courses.Include(c => c.Major).Where(x => x.Major.DepartmentId == 2 || x.Major.DepartmentId == 1).OrderBy(x => x.level);

//                    return View(/*courses.ToList()*/);
//                }
//                else if (getDepartmentId == 3)
//                {
//                    var majorList = db.Majors.Where(x => x.MajorStatus == true & x.DepartmentId == getDepartmentId).Select(x => x.MajorName).ToList();
//                    SelectList majorSelectList = new SelectList(majorList);
//                    ViewBag.majorSelectList = majorSelectList;

//                    var courses = db.Courses.Include(c => c.Major).Where(x => x.Major.DepartmentId == 3 || x.Major.DepartmentId == 1).OrderBy(x => x.level);
//                    return View(courses.ToList());
//                }
//                else if (getDepartmentId == 4)
//                {
//                    var majorList = db.Majors.Where(x => x.MajorStatus == true & x.DepartmentId == getDepartmentId).Select(x => x.MajorName).ToList();
//                    SelectList majorSelectList = new SelectList(majorList);
//                    ViewBag.majorSelectList = majorSelectList;

//                    var courses = db.Courses.Include(c => c.Major).Where(x => x.Major.DepartmentId == 4 || x.Major.DepartmentId == 1).OrderBy(x => x.level);
//                    return View(courses.ToList());
//                }
//                else if (getDepartmentId == 5)
//                {
//                    var majorList = db.Majors.Where(x => x.MajorStatus == true & x.DepartmentId == getDepartmentId).Select(x => x.MajorName).ToList();
//                    SelectList majorSelectList = new SelectList(majorList);
//                    ViewBag.majorSelectList = majorSelectList;

//                    var courses = db.Courses.Include(c => c.Major).Where(x => x.Major.DepartmentId == 5 || x.Major.DepartmentId == 1).OrderBy(x => x.level);
//                    return View(courses.ToList());
//                }
//                else
//                {
//                    var majorList = db.Majors.Where(x => x.MajorStatus == true & x.DepartmentId == getDepartmentId).Select(x => x.MajorName).ToList();
//                    SelectList majorSelectList = new SelectList(majorList);
//                    ViewBag.majorSelectList = majorSelectList;

//                    var courses = db.Courses.Include(c => c.Major).Where(x => x.Major.DepartmentId == 6 || x.Major.DepartmentId == 1).OrderBy(x => x.level);
//                    return View(courses.ToList());
//                }
//            }
//            else
//            {
//                return RedirectToAction("Login", "Account");

//            }
           
           
//        }

//        [ViewPermissionFilter(ViewId = 13)]
//        public ActionResult GetCourses(string MajorName)
//        {
//            var courses = db.Courses.Include(c => c.Major).Where(x => x.Major.MajorName == MajorName || x.MajorId == 1).OrderBy(x => x.level).ToList();

//            return PartialView("_GetCoursesListView", courses);
//        }

//        // GET: Courses/Details/5
//        public ActionResult Details(string id, int y)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Course course = db.Courses.Where(x => x.CourseId == id && x.MajorId == y).FirstOrDefault();
//            if (course == null)
//            {
//                return HttpNotFound();
//            }
//            return View(course);
//        }

//        // GET: Courses/Create
//        public ActionResult Create()
//        {
//            ViewBag.MajorId = new SelectList(db.Majors.Where(x => x.MajorStatus == true), "MajorId", "MajorName");
//            return View();
//        }

//        // POST: Courses/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "CourseId,MajorId,CourseName,Prerequisites,CourseStatus")] Course course)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Courses.Add(course);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.MajorId = new SelectList(db.Majors.Where(x=>x.MajorStatus == true), "MajorId", "MajorName", course.MajorId);
//            return View(course);
//        }

//        // GET: Courses/Edit/5
//        public ActionResult Edit(string id , int y)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Course course = db.Courses.Where(x=>x.CourseId == id && x.MajorId == y).FirstOrDefault();
//            if (course == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.MajorId = new SelectList(db.Majors.Where(x => x.MajorStatus == true), "MajorId", "MajorName", course.MajorId);
//            return View(course);
//        }

//        // POST: Courses/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "CourseId,MajorId,CourseName,Prerequisites,CourseStatus")] Course course)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(course).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.MajorId = new SelectList(db.Majors.Where(x => x.MajorStatus == true), "MajorId", "MajorName", course.MajorId);
//            return View(course);
//        }

//        // GET: Courses/Delete/5
//        public ActionResult Delete(string id, int y)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Course course = db.Courses.Where(x => x.CourseId == id && x.MajorId == y).FirstOrDefault();
//            if (course == null)
//            {
//                return HttpNotFound();
//            }
//            return View(course);
//        }

//        // POST: Courses/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id, int y)
//        {
//            Course course = db.Courses.Where(x => x.CourseId == id && x.MajorId == y).FirstOrDefault();
//            db.Courses.Remove(course);
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
