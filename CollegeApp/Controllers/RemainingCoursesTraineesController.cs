using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeApp.Data;
using CollegeApp.Models;
using CollegeApp.Models.TrainingGuide;
using LumenWorks.Framework.IO.Csv;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class RemainingCoursesTraineesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: RemainingCoursesTrainees
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int TraineeUserId)
        {
            return View(db.RemainingCoursesTrainees.Where(x=>x.TraineeUserId == TraineeUserId).ToList());
        }

        public ActionResult UplaodData()
        {

            ViewBag.getTrainingTypeList = db.ProgramTypes.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UplaodData(HttpPostedFileBase upload, int selected)
        {
            ViewBag.getTrainingTypeList = db.ProgramTypes.ToList();

            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();

                        using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true, ','))
                        {

                            csvTable.Load(csvReader);

                            /////////////////////////
                            foreach (DataRow row in csvTable.Rows)
                            {


                                RemainingCoursesTrainee rct = new RemainingCoursesTrainee();

                                rct.TrainingTypeName = Convert.ToString(row[1]);
                                rct.DepartmentName = Convert.ToString(row[2]);
                                rct.MajorName = Convert.ToString(row[3]);

                                rct.TraineeUserId = Convert.ToInt32(row[5]);
                                rct.TraineeName = Convert.ToString(row[6]);

                                if (row[7] == System.DBNull.Value)
                                {
                                    rct.GPA = 0;

                                }
                                else
                                {
                                    rct.GPA = Convert.ToDouble(row[7]);

                                }
                                rct.CourseId = Convert.ToString(row[8]);
                                rct.CourseName = Convert.ToString(row[9]);

                                //rct.ProgramTypeId = selected;



                                db.RemainingCoursesTrainees.Add(rct);
                                db.SaveChanges();




                            }

                            /////////////////// 
                        }

                        return View(csvTable);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "هذا الملف ليس بصيغة csv يجب تغير الصيغة");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }



            return View();
        }
        // GET: RemainingCoursesTrainees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
            if (remainingCoursesTrainee == null)
            {
                return HttpNotFound();
            }
            return View(remainingCoursesTrainee);
        }

        // GET: RemainingCoursesTrainees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RemainingCoursesTrainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RemainingCoursesTraineeId,DepartmentName,MajorName,TraineeUserId,TraineeName,GPA,CourseId,CourseName")] RemainingCoursesTrainee remainingCoursesTrainee)
        {
            if (ModelState.IsValid)
            {
                db.RemainingCoursesTrainees.Add(remainingCoursesTrainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(remainingCoursesTrainee);
        }

        // GET: RemainingCoursesTrainees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
            if (remainingCoursesTrainee == null)
            {
                return HttpNotFound();
            }
            return View(remainingCoursesTrainee);
        }

        // POST: RemainingCoursesTrainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RemainingCoursesTraineeId,DepartmentName,MajorName,TraineeUserId,TraineeName,GPA,CourseId,CourseName")] RemainingCoursesTrainee remainingCoursesTrainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remainingCoursesTrainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(remainingCoursesTrainee);
        }

        // GET: RemainingCoursesTrainees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
            if (remainingCoursesTrainee == null)
            {
                return HttpNotFound();
            }
            return View(remainingCoursesTrainee);
        }

        // POST: RemainingCoursesTrainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RemainingCoursesTrainee remainingCoursesTrainee = db.RemainingCoursesTrainees.Find(id);
            db.RemainingCoursesTrainees.Remove(remainingCoursesTrainee);
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
