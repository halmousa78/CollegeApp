using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class DepartmentType
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم نوع القسم")]
        public string DepartmentTypeId { get; set; }
        [Display(Name = "اسم نوع القسم")]
        public string DepartmentTypeName { get; set; }
    }
}