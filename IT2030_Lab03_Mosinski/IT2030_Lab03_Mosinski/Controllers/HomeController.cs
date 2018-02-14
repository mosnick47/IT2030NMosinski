using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT2030_Lab02_Mosinski.Controllers
{
    public class HomeController : Controller    // The name of the controller exists right the .com/"" in the URL EX:facebook.com/home - home is the controller
    {
        public ActionResult Index()
        {
            return View("../Other/Details");
        }
        public ActionResult About()
        {
            ViewBag.Message = "About method is being called.";

            return View();
        }

        public string Display()
        {
            return "Display method is being called";
        }
    }
}