using System.Web.Mvc;

namespace SMSOA.Login
{
    public class LoginAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Login_default",
                "Login/{controller}/{action}/{id}",
                new { action = "Index",
                    id = UrlParameter.Optional  },
                new string[1] {"SMSOA.Login"}   //添加外置控制器的命名空间
            );
        }
    }
}