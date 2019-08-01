using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Security
{
    public class LoggedUser
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<RoleModel> Roles { get; set; }
    }
}