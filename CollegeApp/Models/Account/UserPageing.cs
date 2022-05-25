using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class UserPageing
    {
       
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserMobile { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int TotalRows { get; set; }
        public List<int> UserViewIds { get; set; }
    }
}