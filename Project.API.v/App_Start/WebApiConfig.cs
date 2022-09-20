using Newtonsoft.Json.Serialization;
using Project.API.v.Attributes;
using Project.API.v.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Project.API.v
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttribute());
            config.MessageHandlers.Add(new APIKeyHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "service/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
