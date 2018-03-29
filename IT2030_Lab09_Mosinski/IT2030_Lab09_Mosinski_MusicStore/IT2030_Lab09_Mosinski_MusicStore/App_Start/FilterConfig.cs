using System.Web;
using System.Web.Mvc;

namespace IT2030_Lab04_Mosinski_MusicStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
