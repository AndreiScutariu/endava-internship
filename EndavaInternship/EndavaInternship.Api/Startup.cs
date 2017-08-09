using System.Configuration;
using System.Web.Http;
using EndavaInternship.Api;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(Startup))]

namespace EndavaInternship.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration {IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always};

            configuration.EnableSwagger(
                c =>
                {
                    var rootUrl = ConfigurationManager.AppSettings["RootUrl"];

                    if (!string.IsNullOrEmpty(rootUrl))
                        c.RootUrl(req => rootUrl);

                    c.SingleApiVersion("v1", "EndavaInternship API");
                }).EnableSwaggerUi();

            app.UseWebApi(configuration);
        }
    }
}