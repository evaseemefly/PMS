using Common.EasyUIFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model.Dictionary;

namespace SMSOA.Areas.Recycled.Controllers
{
    public class HomeController : Controller
    {
        // GET: Recycled/Home
        public ActionResult Index()
        {
            ViewBag.LoadActionType_ComboGrid = "GetAllRecycled_ComboGrid";
            return View();
        }

        /// <summary>
        /// 读取字典
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRecycledType()
        {
            //根据下拉框选中的id获取该id对应的回收站中内容的种类
            return View();
        }

        /// <summary>
        /// 获取下拉框中应该显示的内容
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllRecycled_ComboGrid()
        {
            //int userId = int.Parse(Request["uid"]);
            //1 获取回收站字典
            var dic = RecycledTypeDictonary.GetRecycledTypeCode();
            //2 将回收站字典转换为easyUI的Combogrid
            var list = ToEasyUICombogrid_Common.ToEasyUIDataGrid(dic, true);
            //3 将combogrid集合序列化并返回
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);

        }

       
    }
}