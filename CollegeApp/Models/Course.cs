using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class Course
    {
        [Required, Key, Column(Order = 1) , DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم المقرر")]
        public string CourseId { get; set; }
        [Display(Name = "رقم المستوى")]
        public int level { get; set; }

        [Display(Name = "اسم المقرر")]
        public string CourseName { get; set; }
        [Display(Name = "محاضرة")]
        public int Lecture { get; set; }
        [Display(Name = "عملي")]
        public int Practical { get; set; }
        [Display(Name = "وحدات معتمدة")]
        public int CreditHours { get; set; }
        [Display(Name = "ساعات اتصال")]
        public int ContactHours { get; set; }
        [Display(Name = "تمارين")]
        public int Tutorial { get; set; }
        [Display(Name = "رقم المقرر المتطلب")]
        public string Prerequisites { get; set; }
        [Display(Name = "رقم التخصص")]
        [Key, Column(Order = 2)]
        public int MajorId { get; set; }
        [Display(Name = "اسم التخصص")]
        [ForeignKey("MajorId")]
        public Major Major { get; set; }

        public bool CourseStatus { get; set; }
    }
}
