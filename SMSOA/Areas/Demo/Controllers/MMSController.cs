using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SMSOA.Areas.Demo.Controllers
{
    public class MMSController : Controller
    {
        // GET: Demo/MMS
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult FileUp(/*HttpContext context*/)
        {

            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string info;
            //判断是否存在文件
            if (files.Count > 0)
            {
                //获取文件集合中的第一个文件(每次只上传一个文件)
                HttpPostedFile file = files[0];
                //定义文件存放的目标路径
                string targetDir = System.Web.HttpContext.Current.Server.MapPath("~/FileUpLoad/Product");
                //创建目标路径
                Directory.CreateDirectory(targetDir);
                //Files.CreateDirectory(targetDir);
                //组合成文件的完整路径
                string path = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file.FileName));
                //保存上传的文件到指定路径中
                file.SaveAs(path);
                info = "上传成功";
            }
            else
            {
                info = "上传失败";
            }


            // string fjssmk = context.Request["fjssmk"];
            ////string userid = Utility.GetCurrentUser().zybh + "";
            //HttpFileCollection httpFileCollection = context.Request.Files;
            //HttpPostedFile file = null;
            // if (httpFileCollection.Count > 0)
            //      file = httpFileCollection[0];
            // FileInfo fileex = new FileInfo(file.FileName);
            return Content(info);
        }
        public ContentResult SendMMS()
        {
            string targetDir = System.Web.HttpContext.Current.Server.MapPath("~/FileUpLoad/Product");
            //暂时发送指定的zip文件
            String fileName = "u=605198921,4238220254&fm=21&gp=0.zip";
            string path = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(fileName));
            var res = SMSOA.Areas.Demo.SendMMS.MMSSend.test(path);
            return Content("ok");
        }

    }
}