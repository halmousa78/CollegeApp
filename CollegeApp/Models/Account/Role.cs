using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class Role
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم الصلاحية")]
        public int RoleId { get; set; }
        [Display(Name = "اسم الصلاحية")]
        public string RoleName { get; set; }
    }
}