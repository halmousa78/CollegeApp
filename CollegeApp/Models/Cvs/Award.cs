using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.Cvs
{
    public class Award
    {
        [Display(Name = "رقم")]
        public int AwardId { get; set; }
        [Display(Name = "AwardDate", ResourceType = typeof(CollegeApp.Resource.Resource))]

       // [Required(ErrorMessageResourceType = typeof(CollegeApp.Resource.Resource), ErrorMessageResourceName = "AwardDateRequired")]
        public string AwardDate { get; set; }

        [Display(Name = "AwardDetail", ResourceType = typeof(CollegeApp.Resource.Resource))]
        [Required(ErrorMessageResourceType = typeof(CollegeApp.Resource.Resource), ErrorMessageResourceName = "AwardDetailRequired")]
        public string AwardDetail { get; set; }

        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}