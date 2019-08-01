using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Security
{
    public class CustomSerializeModel
    {
        public int IdUser { set; get; }
        public string Username { get; set; }
        public List<string> RoleName { get; set; }
    }
}