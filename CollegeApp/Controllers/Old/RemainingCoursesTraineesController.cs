//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using CollegeApp.Data;
//using CollegeApp.Models.TrainingGuide;
//using LumenWorks.Framework.IO.Csv;

//namespace CollegeApp.Controllers
//{
//    public class RemainingCoursesTraineesController : Controller
//    {
//        private MyDbContext db = new MyDbContext();

//        // GET: RemainingCoursesTrainees
//        public ActionResult Index()
//        {
//            var remainingCoursesTrainees = db.RemainingCoursesTrainees.Include(r => r.Course).Include(r => r.Major).Include(r => r.TraineeUser);
//            return View(remainingCoursesTrainees.ToList());
//        }

//        public ActionResult UplaodData()
//        {

//            ViewBag.getTrainingTypeList = db.ProgramTypes.ToList();

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult UplaodData(HttpPostedFileBase upload, int selected)
//        {
//            ViewBag.getTrainingTypeList = db.ProgramTypes.ToList();

//            if (ModelState.IsValid)
//            {

//                if (upload != null && upload.ContentLength > 0)
//                {

//                    if (upload.FileName.EndsWith(".csv"))
//                    {
//                        Stream stream = upload.InputStream;
//                        DataTable csvTable = new DataTable();

//                        using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true, ','))
//                        {

//                            csvTable.Load(csvReader);

//                            /////////////////////////
//                            foreach (DataRow row in csvTable.Rows)
//                            {


//                                RemainingCoursesTrainee rct = new RemainingCoursesTrainee();



//                                var getMajorIdString = Convert.ToString(row[3]);
//                                var getMajorId = Convert.ToInt32(db.Majors.Where(x => x.MajorName == getMajorIdString).Select(x => x.MajorId).FirstOrDefault());
//                                rct.MajorId = getMajorId;

//                                rct.TraineeUserId = db.TraineeUsers.Find(Convert.ToInt32(row[5])).TraineeUserId;
//                                rct.GPA = Convert.ToDouble(row[7]);
//                                var getCourseId = Convert.ToString(row[8]);
//                                rct.CourseId = getCourseId.Replace(" - ", String.Empty);

//                                //rct.ProgramTypeId = selected;



//                                db.RemainingCoursesTrainees.Add(rct);
//                                db.SaveChanges();




//                            }

//                            /////////////////// 
//                        }

//                        return View(csvTable);
//                    }
//                    else
//                    {
//                        ModelState.AddModelError("File", "هذا الملف ليس بصيغة csv يجب تغير الصيغة");
//                        return View();
//                    }
//                }
//                else
//                {
//                    ModelState.AddModelError("File", "Please Upload Your file");
//                }
//            }



//            return View();
//        }
//        // GET: RemainingCoursesTrainees/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
//            if (remainingCoursesTrainee == null)
//            {
//                return HttpNotFound();
//            }
//            return View(remainingCoursesTrainee);
//        }

//        // GET: RemainingCoursesTrainees/Create
//        public ActionResult Create()
//        {
//            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
//            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName");
//            ViewBag.TraineeUserId = new SelectList(db.TraineeUsers, "TraineeUserId", "TraineeUserName");
//            return View();
//        }

//        // POST: RemainingCoursesTrainees/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "RemainingCoursesTraineeId,MajorId,TraineeUserId,GPA,CourseId")] RemainingCoursesTrainee remainingCoursesTrainee)
//        {
//            if (ModelState.IsValid)
//            {
//                db.RemainingCoursesTrainees.Add(remainingCoursesTrainee);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", remainingCoursesTrainee.CourseId);
//            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", remainingCoursesTrainee.MajorId);
//            ViewBag.TraineeUserId = new SelectList(db.TraineeUsers, "TraineeUserId", "TraineeUserName", remainingCoursesTrainee.TraineeUserId);
//            return View(remainingCoursesTrainee);
//        }

//        // GET: RemainingCoursesTrainees/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
//            if (remainingCoursesTrainee == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", remainingCoursesTrainee.CourseId);
//            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", remainingCoursesTrainee.MajorId);
//            ViewBag.TraineeUserId = new SelectList(db.TraineeUsers, "TraineeUserId", "TraineeUserName", remainingCoursesTrainee.TraineeUserId);
//            return View(remainingCoursesTrainee);
//        }

//        // POST: RemainingCoursesTrainees/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "RemainingCoursesTraineeId,MajorId,TraineeUserId,GPA,CourseId")] RemainingCoursesTrainee remainingCoursesTrainee)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(remainingCoursesTrainee).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", remainingCoursesTrainee.CourseId);
//            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", remainingCoursesTrainee.MajorId);
//            ViewBag.TraineeUserId = new SelectList(db.TraineeUsers, "TraineeUserId", "TraineeUserName", remainingCoursesTrainee.TraineeUserId);
//            return View(remainingCoursesTrainee);
//        }

//        // GET: RemainingCoursesTrainees/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
//            if (remainingCoursesTrainee == null)
//            {
//                return HttpNotFound();
//            }
//            return View(remainingCoursesTrainee);
//        }

//        // POST: RemainingCoursesTrainees/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
//            db.RemainingCoursesTrainees.Remove(remainingCoursesTrainee);
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
