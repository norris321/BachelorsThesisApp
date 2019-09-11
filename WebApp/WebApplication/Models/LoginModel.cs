using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(30)]
        public string Username { set; get; }

        [Required]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        public string Password { set; get; }


        /*[System.Diagnostics.Conditional("DEBUG")]
        public static void DebugLogIn(string rank)
        {
            Controllers.LoginController
        }*/
    }
}