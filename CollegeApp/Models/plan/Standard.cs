using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.plan
{
    public class Standard
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم المعيار")]
        public double StandardId { get; set; }
        [Display(Name = "اسم المعيار")]
        public string StandardName { get; set; }
        [Display(Name = "وصف المعيار")]
        public string StandardDescription { get; set; }


    }
}