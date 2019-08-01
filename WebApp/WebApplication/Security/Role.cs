using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Security
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<LoggedUser> Users { get; set; }

        public RoleModel(string role)
        {
            if(role == "User" || role == "user")
            {
                RoleId = 1;
                RoleName = "User";
            }
            else if(role == "Admin" || role == "admin")
            {
                RoleId = 2;
                RoleName = "Admin";
            }
        }
    }
}