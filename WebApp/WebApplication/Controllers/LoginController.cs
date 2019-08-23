using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;
using WebApplication.Security;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = AddCookie(model);

                if(user == null)
                {
                    ViewBag.Message = "Something Wrong : Username or Password invalid";
                    return View(new LoginModel());
                }

                if (user.Roles.Count == 2)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Roles.Count == 1)
                {
                    return RedirectToAction("Index", "User");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public CustomMembershipUser AddCookie(LoginModel model)
        {
            if (Membership.ValidateUser(model.Username, model.Password))
            {
                var user = (CustomMembershipUser)Membership.GetUser(model.Username, false);
                if (user != null)
                {
                    CustomSerializeModel userModel = new Security.CustomSerializeModel()
                    {
                        IdUser = user.UserId,
                        Username = user.FirstName,
                        RoleName = user.Roles.Select(r => r.RoleName).ToList()
                    };

                    string userData = JsonConvert.SerializeObject(userModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                        (
                        1, model.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                        );

                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                    Response.Cookies.Add(faCookie);
                }

                return user;
            }
            else
            {
                return null;
            }
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login", null);
        }
    }
}