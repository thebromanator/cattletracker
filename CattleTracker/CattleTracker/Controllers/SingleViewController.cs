using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CattleTracker.Controllers
{
    public class SingleViewController : Controller
    {
        // GET: SingleView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Management()
        {
            return View();
        }

        public ActionResult Health()
        {
            return View();
        }
        public ActionResult Sales()
        {
            return View();
        }
    }
}