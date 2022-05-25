using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.Account
{
    public class TraineeUser
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم المستخدم")]
        public int TraineeUserId { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string TraineeUserName { get; set; }
        [Display(Name = "كلمة المرور")]
        public string TraineeUserPassword { get; set; }
        [Display(Name = "البريد الالكتروني")]
        public string TraineeUserEmail { get; set; }
        [Display(Name = "الجوال")]
        public string TraineeUserMobile { get; set; }
        [Display(Name = "رقم القسم")]
        public int DepartmentId { get; set; }
        public Department DepartmentName { get; set; }
        [Display(Name = "حالة المستخدم")]
        public bool TraineeUserStatus { get; set; }
        [Display(Name = "تاريخ الانشاء")]
        public string CreatedDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "تاريخ اخر تحديث")]
        [Required]
        public string DateCv { get; set; }
        [Display(Name = "سنوات الخدمة")]
        [Required]
        public int ExperienceYears { get; set; }
        [Display(Name = "مستوى اللغة الانجليزية")]
        [Required]
        public string EngilshLevel { get; set; }
        [Display(Name = "السطر الاول في العنوان")]
        public string Addressline1 { get; set; }
        [Display(Name = "السطر الثاني في العنوان")]
        public string Addressline2 { get; set; }
        [Display(Name = "السطر الثالث في العنوان")]
        public string Addressline3 { get; set; }

        [Required]
        [Display(Name = "الصورة الشخصية")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public TraineeUser()
        {
            Image = "~/Content/TraineeUser/Images/Default.png";
        }
    }
}