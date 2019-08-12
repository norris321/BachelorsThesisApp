using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult ModifyAlbum(ModifyAlbumModel model)
        {
            var msg = model.Modify();
            ViewBag.Message = msg;
            return View(new ModifyAlbumModel());
        }

        public ActionResult ModifyUser()
        {
            return View(new ModifyUserModel());
        }

        [HttpPost]
        public ActionResult ModifyUser(ModifyUserModel model)
        {
            var msg = model.Modify();
            ViewBag.Message = msg;
            return View(new ModifyUserModel());
        }

    }
}