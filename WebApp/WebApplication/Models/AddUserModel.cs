using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class AddUserModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Rank { set; get; }


        public static IEnumerable<SelectListItem> GetRanks()
        {
            yield return new SelectListItem { Text = "Admin", Value = "Admin" };
            yield return new SelectListItem { Text = "User", Value = "User" };
        }

        public string AddUser()
        {
            using (ServiceReference.MusicServiceClient client = new ServiceReference.MusicServiceClient())
            {
                return client.AddUser(Username, Password, Rank);
            }
        }

    }
}