using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace umekou.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "UMEKOU";

            return View();
        }




        public ActionResult About()
        {
            return View();
        }

        public ActionResult Activity()
        {
            return View();
        }
        public ActionResult Story()
        {
            return View();
        }
        public ActionResult Youth()
        {
            return View();
        }
        public ActionResult Mission()
        {
            return View();
        }
    }
}
