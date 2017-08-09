using EndavaInternship.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EndavaInternship.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}