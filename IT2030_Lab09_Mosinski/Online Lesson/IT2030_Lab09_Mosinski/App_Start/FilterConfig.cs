﻿using System.Web;
using System.Web.Mvc;

namespace IT2030_Lab09_Mosinski
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
