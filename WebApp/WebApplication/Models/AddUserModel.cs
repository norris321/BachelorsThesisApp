using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServicesConnections;
using WebApplication.WcfServiceReference;

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
            AccessWcfService service = new AccessWcfService("AddUser", "POST");
            UserLoginContract user = new UserLoginContract { Username = this.Username, Password = this.Password, Rank = this.Rank };
            string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            string returnMessage = service.SendJsonToService(inputJson);
            return returnMessage;
        }

    }
}