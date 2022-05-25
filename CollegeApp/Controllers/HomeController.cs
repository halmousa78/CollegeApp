using CollegeApp.Data;
using CollegeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            ViewBag.UserTotal = db.Users.Count();
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