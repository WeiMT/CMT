using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using User.Service.Pipeline.Filters;
using WebApiContrib.Formatting.Jsonp;

namespace User.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Formatters.Add(new JsonpMediaTypeFormatter(new JsonMediaTypeFormatter()));

            config.Filters.Add(new UserIdRequiredAttribute());
        }
    }
}
