using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.plan
{
    public class Initiative
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم المبادرة")]
        public int InitiativeId { get; set; }
        [Display(Name = "اسم المبادرة")]
        public string InitiativeName { get; set; }
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

        [Display(Name = "رقم المعيار")]
        public double StandardId { get; set; }
        public Standard Standard { get; set; }
        [Display(Name = "حالة المبادرة")]
        public bool InitiativeStatus { get; set; }
        [Display(Name = "ملاحظات")]
        public string Notes { get; set; }

    }
}