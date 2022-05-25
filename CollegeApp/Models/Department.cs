using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class Department
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم القسم")]
        public int DepartmentId { get; set; }
        [Display(Name = "اسم القسم")]
        public string DepartmentName { get; set; }
        
        [Display(Name = "رقم نوع القسم")]
        public string DepartmentTypeId { get; set; }
        public DepartmentType DepartmentType { get; set; }

        [Display(Name = "حالة القسم")]
        public bool DepartmentStatus { get; set; }
    }
}