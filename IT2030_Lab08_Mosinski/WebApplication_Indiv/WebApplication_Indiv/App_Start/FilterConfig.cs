using System.Web;
using System.Web.Mvc;

namespace WebApplication_Indiv
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());  // indicates that all controllers need an authorization attribute; sets it at the global level
            filters.Add(new HandleErrorAttribute());
        }
    }
}
