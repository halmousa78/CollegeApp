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
//using CollegeApp.Models.ImprovementIndicator;

//namespace CollegeApp.Controllers
//{
//    [Permission]
//    [ViewPermissionFilter(ViewId = 13)]
//    public class ImprovementIndicatorsController : Controller
//    {
//        private MyDbContext db = new MyDbContext();

//        // GET: ImprovementIndicators
//        public ActionResult Index()
//        {
//            var getRole = Convert.ToInt32(Session["RoleId"].ToString());
//            var getRoleName = db.Roles.Where(x => x.RoleId == getRole).Select(x => x.RoleName).FirstOrDefault();
//            var improvementIndicators = db.ImprovementIndicators.Include(i => i.Subject).Where(x => x.ResponsibleEntity == getRoleName);

//            return View(improvementIndicators.ToList());
//        }

//        public ActionResult MyIndex()
//        {

//            var improvementIndicators = db.ImprovementIndicators.Include(i => i.Subject);
//            return View(improvementIndicators.ToList());
//        }

//        public ActionResult GetImprovementIndicatorsBySubjectId(double Id)
//        {
//            var improvementIndicators = db.ImprovementIndicators.Include(i => i.Subject).Where(x => x.SubjectId == Id);
//            ViewBag.Id = Id;

//            return View(improvementIndicators.ToList());
//        }

//        public ActionResult CreateImprovementIndicatorsBySubjectId(double Id)
//        {
//            ViewBag.ResponsibleEntity = new SelectList(db.Roles, "RoleName", "RoleName");
//            ViewBag.SupportingEntity = new SelectList(db.Roles, "RoleName", "RoleName");
//            var getSubjectName = db.Subjects.Find(Id);
//            ViewBag.SubjectName = getSubjectName.SubjectName;
//            ViewBag.SubjectId = Convert.ToString(Id);
//            return View();
//        }

//        [HttpPost]
//        public ActionResult CreateImprovementIndicatorsBySubjectId([Bind(Include = "ImprovementIndicatorId,ImprovementIndicatorName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,SubjectId,ImprovementIndicatorStatus,Notes")] ImprovementIndicator improvementIndicator)
//        {
//            if (ModelState.IsValid)
//            {
//                var getimprovementIndicator = db.ImprovementIndicators;
//                if (getimprovementIndicator != null)
//                {
//                    var getimprovementIndicatorId = db.ImprovementIndicators.Select(x => x.ImprovementIndicatorId).Max() + 1;
//                    improvementIndicator.ImprovementIndicatorId = getimprovementIndicatorId;
//                }
//                else
//                {
//                    improvementIndicator.ImprovementIndicatorId = 1;
//                }


//                db.ImprovementIndicators.Add(improvementIndicator);
//                db.SaveChanges();
//                return RedirectToAction("GetImprovementIndicatorsBySubjectId", new { Id = improvementIndicator.SubjectId });
//            }

//            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
//            return View(improvementIndicator);
//        }

//        // GET: ImprovementIndicators/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
//            if (improvementIndicator == null)
//            {
//                return HttpNotFound();
//            }
//            return View(improvementIndicator);
//        }

//        // GET: ImprovementIndicators/Create
//        public ActionResult Create()
//        {
//            ViewBag.ResponsibleEntity = new SelectList(db.Roles, "RoleName", "RoleName");
//            ViewBag.SupportingEntity = new SelectList(db.Roles, "RoleName", "RoleName");
//            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
//            return View();
//        }

//        // POST: ImprovementIndicators/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ImprovementIndicatorId,ImprovementIndicatorName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,SubjectId,ImprovementIndicatorStatus,Notes")] ImprovementIndicator improvementIndicator)
//        {
//            if (ModelState.IsValid)
//            {
//                var getimprovementIndicator = db.ImprovementIndicators.Find(improvementIndicator.ImprovementIndicatorId);
//                if (getimprovementIndicator != null)
//                {
//                    var getimprovementIndicatorId = db.ImprovementIndicators.Select(x => x.ImprovementIndicatorId).Max() + 1;
//                    improvementIndicator.ImprovementIndicatorId = getimprovementIndicatorId;
//                }
//                else
//                {
//                    improvementIndicator.ImprovementIndicatorId = 1;
//                }


//                db.ImprovementIndicators.Add(improvementIndicator);
//                db.SaveChanges();
//                return RedirectToAction("MyIndex");
//            }

//            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
//            return View(improvementIndicator);
//        }

//        // GET: ImprovementIndicators/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
//            if (improvementIndicator == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.ResponsibleEntity = new SelectList(db.Roles, "RoleName", "RoleName", improvementIndicator.ResponsibleEntity);
//            ViewBag.SupportingEntity = new SelectList(db.Roles, "RoleName", "RoleName", improvementIndicator.SupportingEntity);
//            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
//            return View(improvementIndicator);
//        }

//        // POST: ImprovementIndicators/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ImprovementIndicatorId,ImprovementIndicatorName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,SubjectId,ImprovementIndicatorStatus,Notes")] ImprovementIndicator improvementIndicator)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(improvementIndicator).State = EntityState.Modified;
//                db.SaveChanges();

//                return RedirectToAction("Index");
//            }
//            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
//            return View(improvementIndicator);
//        }

//        // GET: ImprovementIndicators/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
//            if (improvementIndicator == null)
//            {
//                return HttpNotFound();
//            }
//            return View(improvementIndicator);
//        }

//        // POST: ImprovementIndicators/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
//            db.ImprovementIndicators.Remove(improvementIndicator);
//            db.SaveChanges();
//            return RedirectToAction("MyIndex");
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
