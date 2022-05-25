using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class User
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name = "كلمة المرور")]
        [Required(ErrorMessage ="الرجاء ادخال كلمة المرور")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Display(Name = "البريد الالكتروني")]
        public string UserEmail { get; set; }
        [Display(Name = "الجوال")]
        public string UserMobile { get; set; }
        [Display(Name = "رقم القسم")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Display(Name = "حالة المستخدم")]
        public bool UserStatus { get; set; }
        [Display(Name = "تاريخ الانشاء")]
        public string CreatedDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "تاريخ اخر تحديث")]
        public string DateCv { get; set; }
        [Display(Name = "سنوات الخدمة")]
        public int ExperienceYears { get; set; }
        [Display(Name = "مستوى اللغة الانجليزية")]
        public string EngilshLevel { get; set; }
        [Display(Name = "السطر الاول في العنوان")]
        public string Addressline1 { get; set; }
        [Display(Name = "السطر الثاني في العنوان")]
        public string Addressline2 { get; set; }
        [Display(Name = "السطر الثالث في العنوان")]
        public string Addressline3 { get; set; }
        public string ResetPasswordCode { get; set; }

        [Display(Name = "الصورة الشخصية")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public User()
        {
            Image = "~/Content/Cvs/Images/Default.png";
        }

    }
}