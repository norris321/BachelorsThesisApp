using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Security;

namespace WebApplication.Controllers
{
    [CustomAuthorize(Roles = "User")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAlbum()
        {
            return View(new AddAlbumModel());
        }

        [HttpPost]
        public ActionResult AddAlbum(AddAlbumModel model)
        {
            string msg = model.AddAlbum();
            ViewBag.Message = msg;
            return View();
        }

        public ActionResult AddRating()
        {
            return View(new AddRatingModel());
        }

        [HttpPost]
        public ActionResult AddRating(AddRatingModel model)
        {
            model.User =  User.Identity.Name;
            string msg =  model.Rate();
            ViewBag.Message = msg;
            return View();
        }
    }
}