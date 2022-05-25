using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.Cvs
{
    public class Qualification
    {
        [Display(Name = "رقم")]
        public int QualificationId { get; set; }
        [Display(Name = "المؤهل")]
        [Required(ErrorMessage = "الرجاء اختيار المؤهل")]
        public string Degree { get; set; }
        [Display(Name = "جهة المؤهل")]
        [Required(ErrorMessage = "الرجاء ادخال مسمى الجهة المانحة للمؤهل")]
        public string institute { get; set; }
        [Display(Name = "السنة")]
        [Required(ErrorMessage = "الرجاء ادخال سنة الحصول على المؤهل")]
        [RegularExpression(@"^(\d{4})$",
                   ErrorMessage = "صيغة ادخال السنة غير صحيحة ، الصيغة الصحيحة 1443")]
        public string year { get; set; }
        [Display(Name = "التخصص")]
        [Required(ErrorMessage = "الرجاء ادخال مسمى التخصص")]
        public string major { get; set; }

        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}