using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class UserView
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم الصفحة")]
        public int UserViewId { get; set; }
        [Display(Name = "اسم الصفحة")]
        public string UserViewName { get; set; }
    }
}