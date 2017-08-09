using EndavaInternship.Api;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EndavaInternship.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}