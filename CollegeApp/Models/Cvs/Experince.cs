using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.Cvs
{
    public class Experince
    {
        [Display(Name = "رقم")]
        public int ExperinceId { get; set; }
        [Display(Name = "مسمى الوظيفة")]
        //[Required(ErrorMessage = "الرجاء ادخال مسمى الوظيفة")]
        public string JobTitle { get; set; }
        [Display(Name = "اسم الشركة")]
        //[Required(ErrorMessage = "الرجاء ادخال مكان الوظيفة")]
        public string CompanyName { get; set; }
        [Display(Name = "تاريخ البداية")]
        //[Required(ErrorMessage = "الرجاء ادخال تاريخ بدء العمل في الوظيفة")]
        public string StartDate { get; set; }
        [Display(Name = "تاريخ النهاية")]
        //[Required(ErrorMessage = "الرجاء ادخال تاريخ انتهاء العمل في الوظيفة")]
        public string EndDate { get; set; }
        [Display(Name = "الوصف")]
        [Required(ErrorMessage = "الرجاء ادخال تفاصيل الوظيفة")]
        public string ExperinceDetail { get; set; }
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}