using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.ImprovementIndicator
{
    public class ImprovementIndicatorSubject
    {
        public int ImprovementIndicatorSubjectId { get; set; }
        [Display(Name = "موضوع خطة التحسين")]
        public string ImprovementIndicatorSubjectName { get; set; }
    }
}