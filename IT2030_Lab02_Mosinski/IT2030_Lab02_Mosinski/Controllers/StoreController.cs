using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT2030_Lab02_Mosinski.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        // /Store
        public string Index()
        {
            return "Hello from the Store.";
        }

        // /Store/Browse/   (by genre)
        //          /Store/Browse?genre=country     called a Querystring when you have a controller method + ? + parameter + = "". (/Store/Browse?genre=country)
        public string Browse(string genre)
        {
            return HttpUtility.HtmlEncode("Hello from Store.Browse(), Genre is " + genre);  // HtmlEncode method ensures the literal string
        }                                                                                   // causes no issues in the Html; escapes any characters
                                                                                            // that would alter the html and cause an error
        // /Store/Details/#(id param)     Much cleaner way of using parameters with action methods
        public string Details(int id)
        {
            return "Hello from Store.Details(), ID=" +id;
        }
    }
}