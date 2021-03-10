﻿using MyFirstAspMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAspMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string userName)
        {
            return View( new HomeModel { Username=userName});
        }
    }
}