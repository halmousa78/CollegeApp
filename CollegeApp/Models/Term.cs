using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class Term
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الرقم")]
        public int TermId { get; set; }

        [Display(Name = "الفصل التدريبي")]
        public string TermName { get; set; }
    }
}