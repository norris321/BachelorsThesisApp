using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication.ServiceReference;

namespace WebApplication.Security
{
    public class CustomMembershipUser : MembershipUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<RoleModel> Roles { get; set; }


        public CustomMembershipUser(UserContract user) : base("CustomMembership", user.Username, user.IdUser, string.Empty, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.IdUser;
            FirstName = user.Username;
            Roles = new List<RoleModel>();
            if(user.Rank == "user")
            {
                Roles.Add(new RoleModel("User"));
            }
            else if(user.Rank == "admin")
            {
                Roles.Add(new RoleModel("User"));
                Roles.Add(new RoleModel("Admin"));
            }
        }
    }
}