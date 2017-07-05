using System.Web;
using System.Web.Mvc;

namespace SMSOA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //为全局过滤器添加自定义的异常过滤器
            filters.Add(new Filters.RangeExceptionAttribute());
        }
    }
}
