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

namespace CollegeApp.Models.TrainingGuide
{
    public class TrainingGuidesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: TrainingGuides
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                var getTrainingGuides = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                var getRole = Convert.ToInt32(Session["RoleId"].ToString());
                var getUserRole = db.Users.Where(x => x.RoleId == getRole).Select(x => x.RoleId).FirstOrDefault();
                var getUser = Session["UserName"].ToString();
                var getUserId = db.Users.Where(x => x.UserName == getUser).Select(x => x.UserId).FirstOrDefault();

                // مدير النظام و العميد و الوكلاء
                if (getUserRole == 1 || getUserRole == 2 || getUserRole == 3 || getUserRole == 4 || getUserRole == 5)
                {
                    //ViewBag.Data = getTrainingGuides;
                    return View(getTrainingGuides);
                }
                //رؤوساء الاقسام
                //رئيس قسم الدرسات العامة
                else if (getUserRole == 6)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList());
                }
                //رئيس قسم تقنية الحاسب
                else if (getUserRole == 7)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList());
                }
                //رئيس قسم التقنية الإدراية
                else if (getUserRole == 8)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList());
                }
                //رئيس قسم ميكانيكا السيارات
                else if (getUserRole == 9)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList());
                }
                //رئيس قسم صيانة الآلات الميكانيكية
                else if (getUserRole == 10)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList());
                }
                //رئيس قسم التبريد وتكييف الهواء
                else if (getUserRole == 11)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList());
                }
                // مشرفين التخصصات
                //مشرف تخصص البرمجيات
                else if (getUserRole == 15)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 4).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 4).ToList());
                }
                //مشرف تخصص الشبكات
                else if (getUserRole == 16)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 6).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 6).ToList());
                }
                //مشرف تخصص الدعم الفني
                else if (getUserRole == 17)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 5).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 5).ToList());
                }
                //مشرف تخصص الإدارة المكتبية
                else if (getUserRole == 18)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 16).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 16).ToList());
                }
                //مشرف تخصص الإدارة المحاسبة
                else if (getUserRole == 19)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 15).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 15).ToList());
                }
                //مشرف تخصص ميكانيكا السيارات
                else if (getUserRole == 20)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 9).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 9).ToList());
                }
                //مشرف تخصص صيانة الآلات الميكانيكية
                else if (getUserRole == 21)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 10).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 10).ToList());
                }
                //مشرف تخصص التبريد وتكييف الهواء
                else if (getUserRole == 22)
                {
                    ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 11).ToList();
                    return View();
                }
                //مدرب
                else if (getUserRole == 12)
                {
                    //ViewBag.Data = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList();
                    return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList());
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           

            //var trainingGuides = db.TrainingGuides.Include(t => t.Major).Include(t => t.Term).Include(t => t.User);
            //return View(trainingGuides.ToList());
        }
        [ViewPermissionFilter(ViewId = 13)]

        public ActionResult TrainingGuideList()
        {
            if (Session["UserName"] != null)
            {
                var getTrainingGuides = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                var getRole = Convert.ToInt32(Session["RoleId"].ToString());
                var getUserRole = db.Users.Where(x => x.RoleId == getRole).Select(x => x.RoleId).FirstOrDefault();
                var getUser = Session["UserName"].ToString();
                var getUserId = db.Users.Where(x => x.UserName == getUser).Select(x => x.UserId).FirstOrDefault();

                return View(db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList());
            }

            return View();
            
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


                                TrainingGuide tg = new TrainingGuide();

                                var getTermIdString = Convert.ToString(row[1]);
                                tg.TermId = Convert.ToInt32(db.Terms.Where(x => x.TermName == getTermIdString).Select(x => x.TermId).FirstOrDefault());

                                var getMajorIdString = Convert.ToString(row[3]);
                                var getMajorId = Convert.ToInt32(db.Majors.Where(x => x.MajorName == getMajorIdString).Select(x => x.MajorId).FirstOrDefault());
                                tg.MajorId = getMajorId;

                                tg.UserId = db.Users.Find(Convert.ToInt32(row[4])).UserId;

                                tg.TraineeNumber = Convert.ToInt32(row[7]);
                                tg.TraineeName = Convert.ToString(row[8]);

                                tg.ProgramTypeId = selected;



                                db.TrainingGuides.Add(tg);
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
        // GET: TrainingGuides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingGuide trainingGuide = db.TrainingGuides.Find(id);
            if (trainingGuide == null)
            {
                return HttpNotFound();
            }
            return View(trainingGuide);
        }

        // GET: TrainingGuides/Create
        public ActionResult Create()
        {
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName");
            ViewBag.ProgramTypeId = new SelectList(db.ProgramTypes, "ProgramTypeId", "ProgramTypeName");
            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: TrainingGuides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainingGuideId,TermId,MajorId,UserId,TraineeName,TraineeNumber,ProgramTypeId,RegistrationOfCoursesAccordingToTheTrainingPlan,TrainingLevel,ExplanationOfTheTrainingPlan,TrainingAverageLevel,Notes")] TrainingGuide trainingGuide)
        {
            if (ModelState.IsValid)
            {
                db.TrainingGuides.Add(trainingGuide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", trainingGuide.MajorId);
            ViewBag.ProgramTypeId = new SelectList(db.ProgramTypes, "ProgramTypeId", "ProgramTypeName", trainingGuide.ProgramTypeId);
            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName", trainingGuide.TermId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", trainingGuide.UserId);
            return View(trainingGuide);
        }

        // GET: TrainingGuides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingGuide trainingGuide = db.TrainingGuides.Find(id);
            if (trainingGuide == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", trainingGuide.MajorId);
            ViewBag.ProgramTypeId = new SelectList(db.ProgramTypes, "ProgramTypeId", "ProgramTypeName", trainingGuide.ProgramTypeId);
            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName", trainingGuide.TermId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", trainingGuide.UserId);
            return View(trainingGuide);
        }

        // POST: TrainingGuides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainingGuideId,TermId,MajorId,UserId,TraineeName,TraineeNumber,ProgramTypeId,RegistrationOfCoursesAccordingToTheTrainingPlan,TrainingLevel,ExplanationOfTheTrainingPlan,TrainingAverageLevel,Notes")] TrainingGuide trainingGuide)
        {
            if (ModelState.IsValid)
            {
                var getTrainingGuideIdData = db.TrainingGuides.Where(x => x.TrainingGuideId == trainingGuide.TrainingGuideId).FirstOrDefault();
                getTrainingGuideIdData.ExplanationOfTheTrainingPlan = trainingGuide.ExplanationOfTheTrainingPlan;
                getTrainingGuideIdData.RegistrationOfCoursesAccordingToTheTrainingPlan = trainingGuide.RegistrationOfCoursesAccordingToTheTrainingPlan;
                getTrainingGuideIdData.TrainingAverageLevel = trainingGuide.TrainingAverageLevel;
                getTrainingGuideIdData.TrainingLevel = trainingGuide.TrainingLevel;
                getTrainingGuideIdData.Notes = trainingGuide.Notes;

                db.Entry(getTrainingGuideIdData);
                db.SaveChanges();
                return RedirectToAction("TrainingGuideList");
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", trainingGuide.MajorId);
            ViewBag.ProgramTypeId = new SelectList(db.ProgramTypes, "ProgramTypeId", "ProgramTypeName", trainingGuide.ProgramTypeId);
            ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName", trainingGuide.TermId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", trainingGuide.UserId);
            return View(trainingGuide);
        }

        // GET: TrainingGuides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingGuide trainingGuide = db.TrainingGuides.Find(id);
            if (trainingGuide == null)
            {
                return HttpNotFound();
            }
            return View(trainingGuide);
        }

        // POST: TrainingGuides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingGuide trainingGuide = db.TrainingGuides.Find(id);
            db.TrainingGuides.Remove(trainingGuide);
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
