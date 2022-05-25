using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.Account.ViewModel
{
    public class UserModel
    {
        [Required]
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name = "كلمة المرور")]
        [Required(ErrorMessage = "الرجاء ادخال كلمة المرور")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال اسم المستخدم")]
        [EmailAddress(ErrorMessage ="الرجاء ادخال صيغة بريد الالكتروني صحيح")]
        [Display(Name = "البريد الالكتروني")]
        public string UserEmail { get; set; }
        [Display(Name = "الجوال")]
        [Required(ErrorMessage ="الرجاء ادخل رقم جوال صحيح")]
        [RegularExpression(@"^(\d{10})$",
                   ErrorMessage = "صيغة الجوال المدخلة للجوال غير صحيحة")]
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
        [Required(ErrorMessage = "الرجاء ادخل عدد سنوات الخدمة")]
        public int ExperienceYears { get; set; }
        [Display(Name = "مستوى اللغة الانجليزية")]
        [Required(ErrorMessage = "الرجاء اختيار مستوى اللغة الانجليزية")]
        public string EngilshLevel { get; set; }
        [Display(Name = "السطر الاول في العنوان")]
        [Required(ErrorMessage = "الرجاء ادخل السطر الاول في العنوان")]
        public string Addressline1 { get; set; }
        [Display(Name = "السطر الثاني في العنوان")]
        [Required(ErrorMessage = "الرجاء ادخل السطر الثاني في العنوان")]
        public string Addressline2 { get; set; }
        [Display(Name = "السطر الثالث في العنوان")]
        [Required(ErrorMessage = "الرجاء ادخل السطر الثالث في العنوان")]
        public string Addressline3 { get; set; }
        public string ResetPasswordCode { get; set; }

        [Display(Name = "الصورة الشخصية")]
        //[Required(ErrorMessage = "الرجاء تحميل صورة شخصية")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public UserModel()
        {
            Image = "~/Content/Cvs/Images/Default.png";
        }

    }
}