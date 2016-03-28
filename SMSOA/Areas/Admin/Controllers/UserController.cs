
using PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model;

namespace SMSOA.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserInfoBLL userInfoBLL { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        ///<summary>
        ///获取用户集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserInfo()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;

            //查询所有用户
            var list_user = userInfoBLL.GetPageList(pageIndex, pageSize, a => a.DelFlag == false, a => a.Sort, true).ToList();
            PMS.Model.EasyUIModel.EasyUIDataGrid dgModel = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list_user,
                footer = null
            };

            //将用户列表转换为Json格式
            return Content(Common.SerializerHelper.SerializerToString(dgModel));
        }

    }
}