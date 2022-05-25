using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.ImprovementIndicator
{
    public class Subject
    {
        [Display(Name = "رقم الخطة")]
        public int SubjectId { get; set; }
        [Display(Name = "اسم الخطة")]
        public string SubjectName { get; set; }
        [Display(Name = "وصف الخطة")]
        public string SubjectDescription { get; set; }
        [Display(Name = "فئة الخطة")]
        public int ImprovementIndicatorSubjectId { get; set; }
        public ImprovementIndicatorSubject ImprovementIndicatorSubject { get; set; }
    }
}