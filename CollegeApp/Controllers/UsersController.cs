using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Models;
using CollegeApp.Models.Account;
using CollegeApp.Models.Account.ViewModel;
using PagedList;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class UsersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        private IMapper mapper = AutoMapperConfig.Mapper;


        // GET: Users
        public ActionResult Index()
        {
            ViewBag.role = db.Roles.ToList();

            return View();
        }

         [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (user.UserId == 0)
                {
                    if (!(String.IsNullOrEmpty(user.UserName) || String.IsNullOrEmpty(user.UserPassword) || String.IsNullOrEmpty(user.UserEmail) || String.IsNullOrEmpty(user.UserMobile)))
                    {
                        var getUserId = db.Users.Select(x => x.UserId).Max() + 1;
                        user.UserId = getUserId;
                        db.Users.Add(user);
                        db.SaveChanges();
                        return Json("Done");

                    }
                    else
                    {
                        return Json("error");
                    }
                }
                else
                {
                    var GetUser = db.Users.Find(user.UserId);
                    GetUser.UserName = user.UserName;
                    GetUser.UserMobile = user.UserMobile;
                    GetUser.UserEmail = user.UserEmail;
                    GetUser.UserPassword = user.UserPassword;
                    GetUser.RoleId = user.RoleId;

                    db.SaveChanges();
                    return Json("Done");
                }
               



            }
            catch (Exception)
            {
                return Json("error");
            }
        }

        [HttpPost]
        public ActionResult Search(int pageNum ,string word)
        {
            PagedList<User> user = (PagedList<User>)(db.Users.Where(x => (x.UserName != null && x.UserName.Contains(word) ||
                      (x.UserMobile != null && x.UserMobile.Contains(word) ||
                      (x.UserEmail != null && x.UserEmail.Contains(word) ||
                      (x.RoleId != null && x.Role.RoleName.Contains(word)))))).OrderByDescending(x=>x.UserId).ToPagedList(pageNum,10));
            
            List<UserPageing> listUserPageing = CreateUserPageing(user);

            return Json(listUserPageing);
        }

        private List<UserPageing> CreateUserPageing(IPagedList<User> user)
        {
            List<UserPageing> listUserPageing = new List<UserPageing>();
            
            foreach (var item in user)
            {
                UserPageing userPageing = new UserPageing();
                userPageing.UserId = item.UserId;
                userPageing.UserName = item.UserName;
                userPageing.UserPassword = item.UserPassword;
                userPageing.UserMobile = item.UserMobile;
                userPageing.UserEmail = item.UserEmail;
                var getRoleName = db.Roles.Where(x => x.RoleId == item.RoleId).Select(x=>x.RoleName).FirstOrDefault().ToString();
                userPageing.RoleName = getRoleName;
                userPageing.TotalRows = user.TotalItemCount;
                listUserPageing.Add(userPageing);
            }
            return listUserPageing;
        }

        public ActionResult Delete(long Id)
        {
            try
            {
                var user = db.Users.Find(Id);
                db.Users.Remove(user);
                db.SaveChanges();
                return Json("Done");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
          
        }
    
        public ActionResult GetUserById(long Id)
        {
            var user = db.Users.Find(Id);
            return Json(user);
        }

        [ViewPermissionFilter(ViewId = 13)]

        public ActionResult ChangeYourPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ViewPermissionFilter(ViewId = 13)]

        public ActionResult ChangeYourPassword(string UserPassword)
        {
            if (String.IsNullOrEmpty(UserPassword) || String.IsNullOrWhiteSpace(UserPassword))
            {
                return View();
            }
            else
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserData = db.Users.Where(x => x.UserEmail == getUserEmail).FirstOrDefault();
                if (getUserEmail != null && getUserData != null)
                {
                    getUserData.UserPassword = UserPassword;
                    db.Entry(getUserData);
                    db.SaveChanges();
                }
            }

            ViewBag.Msg = "Done";
            return View();
        }
        [ViewPermissionFilter(ViewId = 13)]
        public ActionResult UserCv()
        {
            if (!(Session["UserEmail"] == null))
            {


                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();

                ViewBag.UserInfo = db.Users.Include(x => x.Department).Where(x => x.UserId == getUserId).FirstOrDefault();
                ViewBag.Qualifications = db.Qualifications.Where(x => x.UserId == getUserId).ToList();
                ViewBag.Experinces = db.Experinces.Where(x => x.UserId == getUserId).ToList();
                ViewBag.Awards = db.Awards.Where(x => x.UserId == getUserId).ToList();
                ViewBag.TrainingCourses = db.TrainingCourses.Where(x => x.UserId == getUserId).ToList();

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [ViewPermissionFilter(ViewId = 13)]
        public ActionResult UserUpdate()
        {
            if (!(Session["UserEmail"] == null))
            {
                var getUserEmail = Session["UserEmail"].ToString();
                var getUserId = db.Users.Where(x => x.UserEmail == getUserEmail).Select(x => x.UserId).FirstOrDefault();

                return View(mapper.Map<UserModel>(db.Users.Include(x => x.Department).Where(x => x.UserId == getUserId).FirstOrDefault()));
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        [ViewPermissionFilter(ViewId = 13)]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserUpdate(User user , HttpPostedFileBase Image)
        {
            var getUserEmail = Session["UserEmail"].ToString();
            var getUserData = db.Users.Where(x => x.UserEmail == getUserEmail).FirstOrDefault();

            if (getUserEmail != null && getUserData != null)
            {
                if (Image != null)
                {
                    if (!getUserData.Image.Contains("~/Content/Cvs/Images/Default.png"))
                    {
                        string oldfilePath = getUserData.Image;

                        string fullPath = Request.MapPath(oldfilePath);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                   

                    string filename = Path.GetFileNameWithoutExtension(Image.FileName);
                    string extension = Path.GetExtension(Image.FileName);
                    //filename = filename+DateTime.Now.ToString("yymmssff")+ extension;
                    filename = getUserData.UserId + extension;

                    getUserData.Image = "~/Content/Cvs/Images/" + filename;
                       

                        Image.SaveAs(Path.Combine(Server.MapPath("~/Content/Cvs/Images/"), filename));

                    

                    Session["UserImage"] = null;
                    Session["UserImage"] = getUserData.Image;
                }
                else
                {
                    if (getUserData.Image.Contains("~/Content/Cvs/Images/Default.png"))
                    {
                        ViewBag.ErrorMsg = "الرجاء اختيار صورة شخصية";
                        return View();
                    }
                    //else
                    //{
                    //    getUserData.Image = "~/Content/Cvs/Images/Default.png";
                    //}

                   
                }

                getUserData.UserMobile = user.UserMobile;
                getUserData.ExperienceYears = user.ExperienceYears;
                getUserData.Addressline1 = user.Addressline1;
                getUserData.Addressline2 = user.Addressline2;
                getUserData.Addressline3 = user.Addressline3;
                getUserData.EngilshLevel = user.EngilshLevel;
                getUserData.DateCv = Convert.ToString(DateTime.Now);

                db.Entry(getUserData);
                db.SaveChanges();
            }

            return RedirectToAction("UserCv");
        }

       

    }
}
