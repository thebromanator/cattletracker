﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CattleTracker.Controllers
{
    public class AppController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}