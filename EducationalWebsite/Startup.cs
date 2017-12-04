using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EducationalWebsite.Startup))]
namespace EducationalWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
