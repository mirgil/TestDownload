using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TestDownload
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DownloadApi",
                routeTemplate: "Download/{size}/{delay}",
                defaults: new { controller = "Download", delay = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
