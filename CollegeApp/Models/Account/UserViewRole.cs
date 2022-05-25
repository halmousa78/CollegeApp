using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class UserViewRole
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserViewRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserViewId { get; set; }
        public Role Role { get; set; }
        public UserView UserView { get; set; }


    }
}