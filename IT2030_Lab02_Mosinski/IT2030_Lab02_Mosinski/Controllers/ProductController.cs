using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT2030_Lab02_Mosinski.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public string Index()
        {
            return "Product/Index is display";
        }

        // /Products/Browse
        public string Browse()
        {
            return "Browse displayed.";
        }

        // Products/Details/105
        public string Details(int id)
        {
            return "Details displayed for Id=105";
        }

        // Products/Location?zip=44124
        public string Locations(string zip)
        {
            return "Location displayed for zip=44142";
        }
    }
}