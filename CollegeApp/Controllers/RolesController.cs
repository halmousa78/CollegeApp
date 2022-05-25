using CollegeApp.Data;
using CollegeApp.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class RolesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(int pageNum, string word)
        {
            var role = db.Roles.Where(x => (x.RoleName != null && x.RoleName.Contains(word))).OrderByDescending(x=>x.RoleId).ToList();

            return Json(role, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetViews()
        {
            var views = db.UserViews.ToList();

            return Json(views,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(UserPageing role)
        {
            if (role.RoleId == 0)
            {
                AddUserViewRole(role);
            }
            else
            {
                var userViewRole = db.UserViewRoles.Where(x=>x.RoleId == role.RoleId).ToList();
                db.UserViewRoles.RemoveRange(userViewRole);
                db.SaveChanges();
                AddUserViewRole(role);
            }
            
            return Json("Done");
        }

        public int AddUserViewRole(UserPageing role)
        {
            Role role1 = new Role();
            
            if (role.RoleId == 0)
            {
                var getRoleId = db.Roles.Select(x => x.RoleId).Max() + 1;
                role1.RoleId = getRoleId;
                role1.RoleName = role.RoleName;
                db.Roles.Add(role1);
                db.SaveChanges();

                foreach (var item in role.UserViewIds)
                {
                    UserViewRole userViewRole = new UserViewRole();
                    var getUserViewRoleId = db.UserViewRoles.Select(x => x.UserViewRoleId).Max() + 1;
                    userViewRole.UserViewRoleId = getUserViewRoleId;
                    userViewRole.UserViewId = item;
                    userViewRole.RoleId = (getRoleId);
                    db.UserViewRoles.Add(userViewRole);
                    db.SaveChanges();
                }
            }
            else
            {
                var getRoleId = db.Roles.Where(x => x.RoleId == role.RoleId).Select(x => x.RoleId).FirstOrDefault();
                var getRole = db.Roles.Find(role.RoleId);

                getRole.RoleId = role.RoleId;
                getRole.RoleName = role.RoleName;
                db.SaveChanges();

                foreach (var item in role.UserViewIds)
                {
                    UserViewRole userViewRole = new UserViewRole();
                    var getUserViewRoleId = db.UserViewRoles.Select(x => x.UserViewRoleId).Max() + 1;
                    userViewRole.UserViewRoleId = getUserViewRoleId;
                    userViewRole.UserViewId = item;
                    userViewRole.RoleId = (getRoleId);
                    db.UserViewRoles.Add(userViewRole);
                    db.SaveChanges();
                }
            }

           


            return -1;
        }

        [HttpPost]
        public ActionResult GetRoleById(int Id)
        {
            var role = db.Roles.Find(Id);
            UserPageing userModel = new UserPageing();
            userModel.RoleId = role.RoleId;
            userModel.RoleName = role.RoleName;
            userModel.UserViewIds = db.UserViewRoles.Where(x => x.RoleId == Id).Select(x => x.UserViewId).ToList();
            
            return Json(userModel);
        }

        public ActionResult Delete(long Id)
        {
            try
            {
                var role = db.Roles.Find(Id);

                var userViewRole = db.UserViewRoles.Where(x => x.RoleId == role.RoleId).ToList();
                db.UserViewRoles.RemoveRange(userViewRole);

                db.Roles.Remove(role);
                db.SaveChanges();
                return Json("Done");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
    }
}