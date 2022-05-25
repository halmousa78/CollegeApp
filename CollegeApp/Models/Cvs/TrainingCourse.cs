using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.Cvs
{
    public class TrainingCourse
    {
        [Display(Name = "رقم")]
        public int TrainingCourseId { get; set; }
        [Display(Name = "اسم المعهد")]
        //[Required(ErrorMessage = "الرجاء اسم المعهد")]
        public string InstitutionName { get; set; }
        [Display(Name = "تاريخ البداية")]
        //[Required(ErrorMessage = "الرجاء تحديد تاريخ بداية الدورة")]
        public string StartDate { get; set; }
        [Display(Name = "تاريخ النهاية")]
        //[Required(ErrorMessage = "الرجاء تحديد تاريخ نهاية الدورة")]
        public string EndDate { get; set; }
        [Display(Name = "الوصف")]
        [Required(ErrorMessage = "الرجاء ادخال وصف الدورة")]
        public string TrainingCourseDetail { get; set; }

        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}