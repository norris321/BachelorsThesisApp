using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.WcfServiceReference;
using WebApplication.ServicesConnections;
using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class ModifyUserModel
    {
        public int Id { set; get; }
        public string NewUserName {set;get;}
        public string NewPassword { set; get; }
        public string NewRank { set; get; }

        public string Modify()
        {
            AccessWcfService service = new AccessWcfService("ModifyUser", "PUT");
            UserLoginContract user = new UserLoginContract { Username = NewUserName, Rank = NewRank, Password = NewPassword, ID = Id};
            string inputJson = JsonConvert.SerializeObject(user);
            string returnJson = service.SendJsonToService(inputJson);
            return returnJson;
        }

        public static IEnumerable<SelectListItem> SelectUser()
        {
            AccessWcfService service = new AccessWcfService("GetUsers", "GET");
            var json = service.GetJsonFromService();
            var users = JsonConvert.DeserializeObject<UserContract[]>(json);

            if (users == null)
            {
                yield return new SelectListItem { Text = "null", Value = "null" };
            }
            else
            {
                foreach (UserContract u in users)
                {
                    yield return new SelectListItem
                    { Text = u.Username, Value = u.IdUser.ToString() };
                }
            }

        }


        public string Delete()
        {
            AccessWcfService service = new AccessWcfService("DeleteUser", "DELETE");
            string inputJson = JsonConvert.SerializeObject(Id);
            string returnJson = service.SendJsonToService(inputJson);
            return returnJson;
        }

        public static IEnumerable<SelectListItem> ChooseNewUserRating()
        {
            yield return new SelectListItem { Text = "User", Value = "User" };
            yield return new SelectListItem { Text = "Admin", Value = "Admin" };
        }



    }
}