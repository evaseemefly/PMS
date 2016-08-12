using Common.EasyUIFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model.Dictionary;
using PMS.IBLL;

namespace SMSOA.Areas.Recycled.Controllers
{
    public class HomeController : Controller
    {
        IBaseDelBLL delBLL { get; set; }

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

        /// <summary>
        /// 传入actionType以及要物理删除的对象id数组（用,分割）
        /// </summary>
        /// <returns></returns>
        public ActionResult DoDel(List<int> list_ids)
        {
            //执行删除操作
            delBLL.PhysicsDel(list_ids);
            return Content("");
        }

        /// <summary>
        /// 传入type的id，根据回收站类型返回该类型的isDel为true全部集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllDelInfoByType()
        {
            //使用工厂模式实现：
            //1 根据传入的type id获取对应的bll层对象
            // 在BLL中的各类中已经实现IBaseDelBLL接口（该接口实现：bool PhysicsDel(List<int> list_ids)方法，注意此方法需要自己实现)
            //2 执行物理删除操作调用本控制器中的DoDel方法
            return Content("");
        }
       
    }
}