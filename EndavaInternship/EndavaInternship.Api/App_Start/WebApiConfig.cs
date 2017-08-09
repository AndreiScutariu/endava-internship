using System.Linq;
using System.Web.Http;
using Swashbuckle.Application;

namespace EndavaInternship.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                "Swagger UI",
                "",
                null,
                null,
                new RedirectHandler(message => message.RequestUri.ToString().TrimEnd('/'), "swagger/ui/index"));

            configuration.RemoveXmlFormatter();
        }

        public static void RemoveXmlFormatter(this HttpConfiguration configuration)
        {
            var appXmlType =
                configuration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(
                    t => t.MediaType == "application/xml");

            configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}