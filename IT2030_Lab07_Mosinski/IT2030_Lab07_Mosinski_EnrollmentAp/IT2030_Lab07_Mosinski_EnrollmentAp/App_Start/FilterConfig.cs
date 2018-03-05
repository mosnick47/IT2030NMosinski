using System.Web;
using System.Web.Mvc;

namespace IT2030_Lab06_Mosinski_EnrollmentAp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
