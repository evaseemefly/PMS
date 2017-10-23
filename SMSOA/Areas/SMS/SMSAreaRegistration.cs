using System.Web.Mvc;

namespace SMSOA.Areas.SMS
{
    public class SMSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SMS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SMS_default",
                "SMS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            //context.MapRoute(
            //    "SMS_apidefault",
            //    "SMS/Api/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}