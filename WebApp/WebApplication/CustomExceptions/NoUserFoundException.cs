using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.CustomExceptions
{
    public class NoUserFoundException : Exception
    {
        public NoUserFoundException(string message) : base(message)
        {

        }
    }
}