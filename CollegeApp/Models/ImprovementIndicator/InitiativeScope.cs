using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.ImprovementIndicator
{
    public class InitiativeScope
    {
        public int InitiativeScopeId { get; set; }
        [Display(Name = "نطاق المبادرة")]
        public string InitiativeScopeName { get; set; }
    }
}