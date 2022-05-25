using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class Major
    {
        [Required, Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم التخصص")]
        public int MajorId { get; set; }
        [Display(Name = "اسم التخصص")]
        public string MajorName { get; set; }
        [Display(Name = "رقم القسم")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Display(Name = "رقم نوع التدريب")]
        [ForeignKey("TrainingType")]
        public int TrainingTypeId { get; set; }
        public TrainingType TrainingType { get; set; }
        public bool MajorStatus { get; set; }
    }
}