using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServiceReference;

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
            using (MusicServiceClient client = new MusicServiceClient())
            {
                return client.ModifyUser(Id, NewUserName, NewPassword, NewRank);
            }
        }

        public static IEnumerable<SelectListItem> SelectUser()
        {
            using (MusicServiceClient client = new MusicServiceClient())
            {
                var users = client.GetUsers();
                if (users == null)
                {
                    yield return new SelectListItem { Text = "null", Value = "null" };
                }
                else
                {
                    foreach (UserContract u in users)
                    {
                        yield return new SelectListItem
                        { Text = u.Username , Value = u.IdUser.ToString() };
                    }
                }
            }
        }


        public string Delete()
        {
            using (MusicServiceClient client = new MusicServiceClient())
            {
                return client.DeleteUser(Id);
            }
        }

        public static IEnumerable<SelectListItem> ChooseNewUserRating()
        {
            yield return new SelectListItem { Text = "User", Value = "User" };
            yield return new SelectListItem { Text = "Admin", Value = "Admin" };
        }



    }
}