using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_Indiv.Controllers
{
    [Authorize]     // Setting "[Authorize]" here will require login to use any of the controller methods
    public class HomeController : Controller
    {
        //[AllowAnonymous]    // If we set global authorization in the FilterConfig.cs file, we need to add [AllowAnonymous] to any action methods that we may want to be the exception to the rule.    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // [Authorize]      // Will require the user to login to view the contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}