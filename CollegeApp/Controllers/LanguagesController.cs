using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CollegeApp.Controllers
{
    public class LanguagesController : Controller
    {
        // GET: Languages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LanguageChange(string languageSelected)
        {
            if (languageSelected != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageSelected);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageSelected);
            }

            HttpCookie cookie = new HttpCookie("NameOflanguage");
            cookie.Value = languageSelected;
            Response.Cookies.Add(cookie);

            return View("Index");
        }
    }
}