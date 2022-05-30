using CollegeApp.Data;
using CollegeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId =1)]
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            ViewBag.UserTotal = db.Users.Count();
            return View();
        }
        [ViewPermissionFilter(ViewId = 13)]
        public ActionResult MyIndex()
        {
            var getTrainingGuides = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
            var getRole = Convert.ToInt32(Session["RoleId"].ToString());
            var getUserRole = db.Users.Where(x => x.RoleId == getRole).Select(x => x.RoleId).FirstOrDefault();
            var getUser = Session["UserName"].ToString();
            var getUserId = db.Users.Where(x => x.UserName == getUser).Select(x => x.UserId).FirstOrDefault();

            ViewBag.UserTotal = db.Users.Count();
            ViewBag.TrainingGuidesTotal = db.TrainingGuides.Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).Count();
            ViewBag.TrainingGuidesCompletedTotal = db.TrainingGuides.Where(x=>x.ExplanationOfTheTrainingPlan == true && x.RegistrationOfCoursesAccordingToTheTrainingPlan==true && x.TrainingLevel == true && x.TrainingAverageLevel).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).Count();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PrintA4()
        {
            
            return View(db.Users.ToList());
        }
    }
}