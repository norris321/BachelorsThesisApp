using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.CustomController;
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
            string msg =  model.Rate(User.Identity.Name);
            ViewBag.Message = msg;
            return View();
        }

        public ActionResult ModifyRating()
        {
            try
            {
                //ModifyRatingModel model = new ModifyRatingModel(User.Identity.Name);
                return View(new ModifyRatingModel(User.Identity.Name));
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ModifyRating")]
        public ActionResult ModifyRating(ModifyRatingModel model)
        {
            var msg = model.ModifyRating();
            ViewBag.Message = msg;
            return RedirectToAction("ModifyRating", "User");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "DeleteRating")]
        public ActionResult DeleteRating(ModifyRatingModel model)
        {
            var msg = model.DeleteRating();
            ViewBag.Message = msg;
            return RedirectToAction("ModifyRating", "User");
        }
    }
}