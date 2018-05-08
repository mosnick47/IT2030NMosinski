using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT2030_FinalProject_Mosinski.Startup))]
namespace IT2030_FinalProject_Mosinski
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
