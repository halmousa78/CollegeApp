using CollegeApp.Data;
using CollegeApp.Models;
using CollegeApp.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CollegeApp.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string UserEmail, string UserPassword, string RememberMe)
        {
            if (ModelState.IsValid)
            {
                var UserData = db.Users.FirstOrDefault(x => x.UserEmail == UserEmail && x.UserPassword == UserPassword);
                var TraineeUserData = db.TraineeUsers.FirstOrDefault(x => x.TraineeUserEmail == UserEmail && x.TraineeUserPassword == UserPassword);

                if (UserData != null)
                {
                    Session["UserId"] = UserData.UserId;
                    Session["RoleId"] = UserData.RoleId;
                    Session["UserName"] = UserData.UserName;
                    Session["UserEmail"] = UserData.UserEmail;
                    Session["UserImage"] = UserData.Image;
                    ViewModel viewModel = new ViewModel();
                    var view = db.UserViewRoles.Where(x => x.RoleId == UserData.RoleId).ToList();
                    viewModel.ViewIds = view.Select(x => x.UserViewId).ToList();
                    viewModel.RoleId = UserData.RoleId;
                    Session["ViewPermission"] = viewModel;

                    if (UserData.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        return RedirectToAction("MyIndex", "Home");

                    }
                }
                else if (TraineeUserData != null)
                {
                    Session["UserId"] = TraineeUserData.TraineeUserId;
                    Session["RoleId"] = TraineeUserData.RoleId;
                    Session["UserName"] = TraineeUserData.TraineeUserName;
                    Session["UserEmail"] = TraineeUserData.TraineeUserEmail;
                    Session["UserImage"] = UserData.Image;
                    ViewModel viewModel = new ViewModel();
                    var view = db.UserViewRoles.Where(x => x.RoleId == TraineeUserData.RoleId).ToList();
                    viewModel.ViewIds = view.Select(x => x.UserViewId).ToList();
                    viewModel.RoleId = TraineeUserData.RoleId;
                    Session["ViewPermission"] = viewModel;

                    if (UserData.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        return RedirectToAction("MyIndex", "Home");

                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }

            return View();
        }

        

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string UserEmail)
        {
            //Verify Email ID
            //Generate Reset password link 
            //Send Email 
            string message = "";
            bool status = false;

            var account = db.Users.Where(a => a.UserEmail == UserEmail).FirstOrDefault();
            if (account != null)
            {
                //Send email for reset password
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(account.UserEmail, resetCode, "ResetPassword");
                account.ResetPasswordCode = resetCode;
                //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                //in our model class in part 1
                //dc.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                message = "تم ارسال رابط اعادة التعيين الى البريد الالكتروني الخاص بك";
            }
            else
            {
                message = "البريد الالكتروني غير مسجل";
            }

            TempData["message"] = message;
            return RedirectToAction("Login");
        }

        // https://support.google.com/accounts/answer/6010255?hl=en
        // If "Less secure app access" is on for your account -->  Less secure app access
        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Account/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("collegesystemact@gmail.com", "تغيير كلمة المرور");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "HANI2021"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "تغيير كلمة المرور";
                body = "مرحبا,<br/><br/>تم تلقي طلب لتغيير كلمة المرور الخاصة بك. الرجاء اضغط على الرابط التالي لتغيير كلمة المرور الخاصة بك" +
                    "<br/><br/><a href=" + link + ">اضغط هنا</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                //Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }


            var user = db.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
            if (user != null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.ResetCode = id;
                
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
               
                    var user = db.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                    //user.UserPassword = Crypto.Hash(model.NewPassword);
                        user.UserPassword = model.NewPassword;
                        user.ResetPasswordCode = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "New password updated successfully";
                    }
                
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return RedirectToAction("Login");
        }
    }
}