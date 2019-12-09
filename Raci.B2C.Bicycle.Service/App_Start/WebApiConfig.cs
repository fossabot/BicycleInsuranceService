using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Http;
using JwtAuthForWebAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Raci.B2C.Bicycle.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new AuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new SecurityTokenBuilder();
            var jwtHandler = new JwtAuthenticationMessageHandler
            {
                AllowedAudience = "http://www.rac.com.au",
                Issuer = "Satalyst",
                SigningToken = builder.CreateFromKey(ConfigurationManager.AppSettings["ApplicationKey"])
            };

            config.MessageHandlers.Add(jwtHandler);

            JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            JsonSerializerSettings settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.None;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
