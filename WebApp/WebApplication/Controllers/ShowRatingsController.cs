﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ShowRatingsController : Controller
    {
        // GET: ShowRatings
        public ActionResult Index()
        {
            return View(new ShowRatingsModel());
        }
    }
}