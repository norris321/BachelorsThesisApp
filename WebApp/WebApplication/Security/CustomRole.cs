using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication.WcfServiceReference;

namespace WebApplication.Security
{
    public class CustomRole : RoleProvider
    {
        /// <summary>  
        ///   
        /// </summary>  
        /// <param name="username"></param>  
        /// <param name="roleName"></param>  
        /// <returns></returns>  
        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }

        /// <summary>  
        ///   
        /// </summary>  
        /// <param name="username"></param>  
        /// <returns></returns>  
        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            ServicesConnections.AccessWcfService service = new ServicesConnections.AccessWcfService("GetUserByName", "GET", username);
            string json = service.GetJsonFromService();
            UserContract user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserContract>(json);

            string[] userRoles = null;

            if (user.Username != null && user.Rank == "admin" )
            {
                userRoles = new string[2];
                userRoles[0] = "User";
                userRoles[1] = "Admin";
            }
            else if (user.Username != null && user.Rank == "user")
            {
                userRoles = new string[1];
                userRoles[0] = "User";
            }

            return userRoles;

            /*using (ServiceReference.MusicServiceClient client = new ServiceReference.MusicServiceClient())
            {
                var user = client.GetUserByName(username);
                string[] userRoles = null;

                if (user.Username != null && user.Rank == "admin")
                {
                    userRoles = new string[2];
                    userRoles[0] = "User";
                    userRoles[1] = "Admin";
                }
                else if (user.Username != null && user.Rank == "user")
                {
                    userRoles = new string[1];
                    userRoles[0] = "User";
                }

                return userRoles;
            }*/

        }



        #region Overrides of Role Provider  

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}