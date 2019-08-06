using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class AddUserModel
    {
        [Required]
        [MaxLength(30)]
        public string Username { set; get; }
        [Required]
        [MaxLength(16)]
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