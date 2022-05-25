using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class ProgramType
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الرقم نوع التدريب")]
        public int ProgramTypeId { get; set; }
        [Display(Name = "نوع التدريب")]
        public string ProgramTypeName { get; set; }
    }
}