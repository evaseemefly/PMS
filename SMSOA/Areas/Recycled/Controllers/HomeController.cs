using Common.EasyUIFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model.Dictionary;
using PMS.IBLL;
using RecycledFactory;

namespace SMSOA.Areas.Recycled.Controllers
{
    public class HomeController : Controller
    {
        IBaseDelBLL delBLL { get; set; }

        // GET: Recycled/Home
        public ActionResult Index()
        {
            ViewBag.LoadActionType_ComboGrid = "GetAllRecycled_ComboGrid";
            ViewBag.LoadAllDelInfo_DataGrid = "GetAllDelInfoByType";
            ViewBag.DoDel = "DoDel";
            ViewBag.ConfirmDoDel = "ConfirmDoDel";
            ViewBag.DoRec = "DoRecover";
            return View();
        }

        /// <summary>
        /// 读取字典
        /// </summary>
        /// <returns></returns>
        //public ActionResult GetRecycledType()
        //{
        //    根据下拉框选中的id获取该id对应的回收站中内容的种类
        //    return View();
        //}

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
        public ActionResult DoDel()
        {
            
             var ids = Request.QueryString["ids"];
            //
            var typeId = int.Parse(Request["type"]);

            var myBLL = SimpleRecFactory.CreateBLL(typeId);
            string[] strIds = ids.Split(',');
            var list_ids = strIds.Select(p=>int.Parse(p)).ToList();
            //执行删除操作
            if (myBLL.PhysicsDel(list_ids,true))
            {
                return Content("ok");
            } 
            return Content("confirm");
        }

        /// <summary>
        /// 传入actionType以及要物理删除的对象id数组（用,分割）
        /// </summary>
        /// <returns></returns>
        public ActionResult ConfirmDoDel()
        {

            var ids = Request.QueryString["ids"];
            //
            var typeId = int.Parse(Request["type"]);

            var myBLL = SimpleRecFactory.CreateBLL(typeId);
            string[] strIds = ids.Split(',');
            var list_ids = strIds.Select(p => int.Parse(p)).ToList();
            //执行删除操作
            if (myBLL.PhysicsDel(list_ids))
            {
                return Content("ok");
            }
            return Content("confirm");
        }

        /// <summary>
        /// 传入type的id，根据回收站类型返回该类型的isDel为true全部集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllDelInfoByType(int type)
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            int pageIndex = int.Parse(Request.Form["page"]);
            int rowCount = 0;
            //使用工厂模式实现：
            //1 根据传入的type id获取对应的bll层对象
            // var typeId = int.Parse(Request["type"]);
            var typeId = type;
            var myBLL= SimpleRecFactory.CreateBLL(typeId);
            this.delBLL = myBLL;
            //2 需要向BaseDel父类中添加一个公用的获取全部已删除的集合的方法
            //var list= myBLL.GetIsDelList();
            var list = myBLL.GetIsDelbyPageList(pageIndex,pageSize,ref rowCount); 
            //3 将combogrid集合序列化并返回
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = rowCount,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            //temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }
        /// <summary>
        /// 执行还原方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DoRecover()
        {
            //1.得到传回的选定的id
            var ids = Request.QueryString["ids"];
            var typeId = int.Parse(Request["type"]);
            var myBLL = SimpleRecFactory.CreateBLL(typeId);
            //2.调用还原方法
            string[] Ids = ids.Split(',');
            List<int> list_ids = new List<int>();
            list_ids = Ids.Select(p => int.Parse(p)).ToList();
            try
            {
                myBLL.Recovery(list_ids);
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }

        }
       
       
    }
}