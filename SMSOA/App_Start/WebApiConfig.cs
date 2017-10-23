using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web;

namespace SMSOA.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "MyTestApi",
            //    routeTemplate: "{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           // config.Routes.MapHttpRoute(
           //    name: "AreaApi",
           //    routeTemplate: "{area}/{controller}/{id}",
           //    defaults: new { id = RouteParameter.Optional }
           //);
        }
    }
}