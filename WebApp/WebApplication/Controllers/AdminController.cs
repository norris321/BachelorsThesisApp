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
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin
        public ActionResult ShowAlbums()
        {
            return View(new ShowAlbumsModel());
        }

        public ActionResult AddUser()
        {
            return View(new AddUserModel());
        }

        [HttpPost]
        public ActionResult AddUser(AddUserModel model)
        {
            string msg = model.AddUser();
            ViewBag.Message = msg;
            return View();
        }

        public ActionResult ModifyAlbum()
        {
            return View(new ModifyAlbumModel());
        }


        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ModifyAlbum")]
        public ActionResult ModifyAlbum(ModifyAlbumModel model)
        {
            var msg = model.Modify();
            ViewBag.Message = msg;
            return View("ModifyAlbum");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "DeleteAlbum")]
        public ActionResult DeleteAlbum(ModifyAlbumModel model)
        {
            var msg = model.Delete();
            ViewBag.Message = msg;
            return View("ModifyAlbum");
        }

        public ActionResult ModifyUser()
        {
            return View(new ModifyUserModel());
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ModifyUser")]
        public ActionResult ModifyUser(ModifyUserModel model)
        {
            var msg = model.Modify();
            ViewBag.Message = msg;
            return View("ModifyUser");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "DeleteUser")]
        public ActionResult DeleteUser(ModifyUserModel model)
        {
            var msg = model.Delete();
            ViewBag.Message = msg;
            return View("ModifyUser");
        }


        /*[HttpPost]
        public ActionResult ModifyUser(ModifyUserModel model)
        {
            var msg = model.Modify();
            ViewBag.Message = msg;
            return View(new ModifyUserModel());
        }*/

    }
}