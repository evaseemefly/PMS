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
        }
    }
}