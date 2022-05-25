using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class TrainingType
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم نوع التدريب")]
        public int TrainingTypeId { get; set; }
        [Display(Name = "اسم نوع التدريب")]
        public string TrainingTypeName { get; set; }
    }
}