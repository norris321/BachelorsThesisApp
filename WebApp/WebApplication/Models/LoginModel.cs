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
        public string Username { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}