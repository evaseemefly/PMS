using System.Web.Mvc;

namespace SMSOA.Areas.Recycled
{
    public class RecycledAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Recycled";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Recycled_default",
                "Recycled/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}