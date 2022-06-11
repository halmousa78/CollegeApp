using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.ImprovementIndicator
{
    public class ImprovementIndicator
    {
        //[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الرقم")]
        public int ImprovementIndicatorId { get; set; }
        [Display(Name = "المبادرة")]
        public string ImprovementIndicatorName { get; set; }
        [Display(Name = "متطلبات الانجاز")]
        public string CompletionRequirements { get; set; }
        [Display(Name = "الجهة المسئولة")]
        public string ResponsibleEntity { get; set; }
        [Display(Name = "الجهة المساندة")]
        public string SupportingEntity { get; set; }
        [Display(Name = "معيار الانجاز")]
        public string AchievementStandard { get; set; }
        [Display(Name = "التاريخ المستهدف")]
        public string DueDate { get; set; }

        [Display(Name = "رقم الموضوع")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [Display(Name = "الحالة")]
        public string ImprovementIndicatorStatus { get; set; }
        [Display(Name = "ملاحظات")]
        public string Notes { get; set; }
        [Display(Name = "نطاق المبادرة")]
        public int InitiativeScopeId { get; set; }
        public InitiativeScope InitiativeScope { get; set; }
        [Display(Name = "ملف الشاهد")]
        public string File { get; set; }

        [NotMapped]
        public HttpPostedFileBase FileUpload { get; set; }

    }
}