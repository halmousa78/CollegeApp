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
using CollegeApp.Models.ImprovementIndicator;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class ImprovementIndicatorsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: ImprovementIndicators
        public ActionResult Index()
        {
            if (!(Session["UserEmail"] == null))
            {
                var getRole = Convert.ToInt32(Session["RoleId"].ToString());
                var getRoleName = db.Roles.Where(x => x.RoleId == getRole).Select(x => x.RoleName).FirstOrDefault();
                var improvementIndicators = db.ImprovementIndicators.Include(i => i.InitiativeScope).Include(i => i.Subject).Where(x => x.ResponsibleEntity == getRoleName);

                ViewBag.RoleId = getRole;
                return View(improvementIndicators.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [ViewPermissionFilter(ViewId = 13)]
        public ActionResult MyIndex()
        {

            var improvementIndicators = db.ImprovementIndicators.Include(i => i.Subject);
            return View(improvementIndicators.ToList());
        }

        public ActionResult GetImprovementIndicatorsBySubjectId(double Id)
        {
            var improvementIndicators = db.ImprovementIndicators.Include(i => i.Subject).Include(z=>z.InitiativeScope).Where(x => x.SubjectId == Id);
            ViewBag.Id = Id;
            TempData["SubjectId"] = Id;

            return View(improvementIndicators.ToList());
        }

        public ActionResult CreateImprovementIndicatorsBySubjectId(double Id)
        {
            ViewBag.ResponsibleEntity = new SelectList(db.Roles, "RoleName", "RoleName");
            ViewBag.SupportingEntity = new SelectList(db.Roles, "RoleName", "RoleName");
            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes , "InitiativeScopeId", "InitiativeScopeName");
            var getSubjectName = db.Subjects.Find(Id);
            ViewBag.SubjectName = getSubjectName.SubjectName;
            ViewBag.SubjectId = Convert.ToString(Id);
            return View();
        }

        [HttpPost]
        public ActionResult CreateImprovementIndicatorsBySubjectId([Bind(Include = "ImprovementIndicatorId,ImprovementIndicatorName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,SubjectId,Notes,InitiativeScopeId")] ImprovementIndicator improvementIndicator)
        {
            if (ModelState.IsValid)
            {

                improvementIndicator.ImprovementIndicatorStatus = "جاري العمل";

                db.ImprovementIndicators.Add(improvementIndicator);
                db.SaveChanges();
                return RedirectToAction("GetImprovementIndicatorsBySubjectId", new { Id = improvementIndicator.SubjectId });
            }

            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes, "InitiativeScopeId", "InitiativeScopeName", improvementIndicator.InitiativeScopeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);

            return View(improvementIndicator);
        }


        // GET: ImprovementIndicators/Details/5
        [ViewPermissionFilter(ViewId = 13)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
            if (improvementIndicator == null)
            {
                return HttpNotFound();
            }
            return View(improvementIndicator);
        }

        // GET: ImprovementIndicators/Create
        public ActionResult Create()
        {
            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes, "InitiativeScopeId", "InitiativeScopeName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: ImprovementIndicators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImprovementIndicatorId,ImprovementIndicatorName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,SubjectId,ImprovementIndicatorStatus,Notes,InitiativeScopeId")] ImprovementIndicator improvementIndicator)
        {
            if (ModelState.IsValid)
            {
                db.ImprovementIndicators.Add(improvementIndicator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes, "InitiativeScopeId", "InitiativeScopeName", improvementIndicator.InitiativeScopeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
            return View(improvementIndicator);
        }

        // GET: ImprovementIndicators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
            if (improvementIndicator == null)
            {
                return HttpNotFound();
            }

            ViewBag.ResponsibleEntity = new SelectList(db.Roles, "RoleName", "RoleName", "RoleName", "RoleName", improvementIndicator.ResponsibleEntity);
            ViewBag.SupportingEntity = new SelectList(db.Roles, "RoleName", "RoleName", "RoleName", "RoleName", improvementIndicator.SupportingEntity);

            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes, "InitiativeScopeId", "InitiativeScopeName", improvementIndicator.InitiativeScopeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
            return View(improvementIndicator);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImprovementIndicatorId,ImprovementIndicatorName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,SubjectId,ImprovementIndicatorStatus,Notes,InitiativeScopeId")] ImprovementIndicator improvementIndicator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(improvementIndicator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetImprovementIndicatorsBySubjectId" , new { id = improvementIndicator.SubjectId });
            }
            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes, "InitiativeScopeId", "InitiativeScopeName", improvementIndicator.InitiativeScopeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
            return View(improvementIndicator);
        }

        public ActionResult EditImprovementIndicators(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
            if (improvementIndicator == null)
            {
                return HttpNotFound();
            }

            ViewBag.ResponsibleEntity = new SelectList(db.Roles, "RoleName", "RoleName", "RoleName", "RoleName", improvementIndicator.ResponsibleEntity);
            ViewBag.SupportingEntity = new SelectList(db.Roles, "RoleName", "RoleName", "RoleName", "RoleName", improvementIndicator.SupportingEntity);

            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes, "InitiativeScopeId", "InitiativeScopeName", improvementIndicator.InitiativeScopeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
            return View(improvementIndicator);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditImprovementIndicators([Bind(Include = "ImprovementIndicatorId,ImprovementIndicatorName,CompletionRequirements,ResponsibleEntity,SupportingEntity,AchievementStandard,DueDate,SubjectId,ImprovementIndicatorStatus,Notes,InitiativeScopeId")] ImprovementIndicator improvementIndicator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(improvementIndicator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyIndex");
            }
            ViewBag.InitiativeScopeId = new SelectList(db.InitiativeScopes, "InitiativeScopeId", "InitiativeScopeName", improvementIndicator.InitiativeScopeId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", improvementIndicator.SubjectId);
            return View(improvementIndicator);
        }


        // GET: ImprovementIndicators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
            if (improvementIndicator == null)
            {
                return HttpNotFound();
            }
            return View(improvementIndicator);
        }

        // POST: ImprovementIndicators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImprovementIndicator improvementIndicator = db.ImprovementIndicators.Find(id);
            db.ImprovementIndicators.Remove(improvementIndicator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UploadFile(int? id)
        {
            ViewBag.ImprovementIndicatorsId = id;

            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(int ImprovementIndicatorsId, HttpPostedFileBase UploadFile)
        {
            var getImprovementIndicatorsById = db.ImprovementIndicators.Find(ImprovementIndicatorsId);

            if (getImprovementIndicatorsById != null)
            {
                if (UploadFile != null)
                {
                                  

                    string filename = Path.GetFileNameWithoutExtension(UploadFile.FileName);
                    string extension = Path.GetExtension(UploadFile.FileName);
                    //filename = filename+DateTime.Now.ToString("yymmssff")+ extension;
                    filename = ImprovementIndicatorsId + extension;

                    getImprovementIndicatorsById.File = "~/Content/ImprovementIndicators/" + filename;


                    UploadFile.SaveAs(Path.Combine(Server.MapPath("~/Content/ImprovementIndicators/"), filename));


                }
                else
                {
                    return View();

                }


                db.Entry(getImprovementIndicatorsById);
                db.SaveChanges();
            }

            return RedirectToAction("MyIndex");
        }

        public ActionResult DownloadFile(string downloadFile)
        {
            if (downloadFile != null)
            {
                //var FileVirtualPath = "~/Content/ImprovementIndicators/" + downloadFile;
                return File(downloadFile, "application/force-download", Path.GetFileName(downloadFile));
            }
           
             return HttpNotFound();
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
