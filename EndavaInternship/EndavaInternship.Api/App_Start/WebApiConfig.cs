using System.Linq;
using System.Web.Http;
using Swashbuckle.Application;

namespace EndavaInternship.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "EndavaInternship API",
                "",
                null,
                null,
                new RedirectHandler(message => message.RequestUri.ToString().TrimEnd('/'), "swagger/ui/index"));

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            RemoveXmlFormatter(config);
        }

        private static void RemoveXmlFormatter(HttpConfiguration configuration)
        {
            var appXmlType =
                configuration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(
                    t => t.MediaType == "application/xml");

            configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}