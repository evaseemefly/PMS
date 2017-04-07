using SMSOA.Areas.Demo.SendMMS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Fdfs.BLL;
using Fdfs.IBLL;
using PMS.Model;
using PMS.IBLL;
using PMS.BLL;

namespace SMSOA.Areas.Demo.Controllers
{
    public class MMSController : Controller
    {
        //全局变量：唯一识别码

        //以后改为spring的方式实现ioc
        IFdfsUploadBLL uploadBLL=new FdfsUploadBLL();

        IFdfsStorageBLL fdfsStorageBLL = new FdfsStorageBLL();

        IFdfsTrackerBLL fdfsTrackerBLL = new FdfsTrackerBLL();

        IFdfsContentBLL fdfsContentBLL = new FdfsContentBLL();

        IS_SMSContentBLL smsContentBLL = new S_SMSContentBLL();

        // GET: Demo/MMS
        public ActionResult Index()
        {
            //之后改为spring的方式
            //uploadBLL = new FdfsUploadBLL();
            return View();
        }

        public ContentResult FileUp(/*HttpContext context*/)
        {

            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string info;
            //判断是否存在文件
            if (files.Count > 0)
            {
                //1 获取文件集合中的第一个文件(每次只上传一个文件)
                HttpPostedFile file = files[0];
                //定义文件存放的目标路径
                //保存上传的文件到指定路径中
                //2 将上传的文件读取为二进制数组
                //2.1将上传的图片转成二进制图片
                var file_stream = file.InputStream;
                BinaryReader binary_reader = new BinaryReader(file_stream);
                //2.2读取为二进制数组 此处需要使用异步读取吗？
               var content= binary_reader.ReadBytes((int)file_stream.Length);
                var content_str = Convert.ToString(content);
                #region 给飞飞写的demo
                //给飞飞写的图片保存demo      
                //FileStream imagefile_stream = new FileStream("路径", FileMode.Create);
                //imagefile_stream.Write(你的二进制数组, 0, 长度);
                //FileInfo file_new = new FileInfo();
                
                #endregion

                //将二进制写入Redis中
                //file.SaveAs(path);
                //3 二进制写入至缓存中（写入hashtable中） 
                Common.Redis.HashRedisHelper hash_redis = new Common.Redis.HashRedisHelper();
                //3.1 判断缓存中是否已经存在指定hashId-key的值（不用判断了，新创建的fileName—唯一的—guid方式）
                var newfileName = Guid.NewGuid();
                string guid_temp = newfileName.ToString();
                guid_temp = guid_temp.Replace("-", "");

                //3月15日测试的上传的图片guid
                //8401089b60834cf68ad7e54639ad00f1
                //hashId可以通过读取配置文件的方式读取
                //应设置失效时间
                hash_redis.Set<byte[]>("fastdfsfile", guid_temp, content);
               var getvalue= hash_redis.Get<byte[]>("fastdfsfile", guid_temp);
                //ViewBag.guid = newfileName.ToString();
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
        #region 备份发送与上传分离
        //public ContentResult SendMMS()
        //{
        //    string info;
        //    //1. 判断唯一识别码是否被创建(是否传入Redis)
        //    //if (ViewBag.guid == null) { return Content(info = "请重新上传图片"); }
        //    string guid= "8401089b60834cf68ad7e54639ad00f1";
        //    //2. 从Redis中获取图片数据
        //    Common.Redis.HashRedisHelper hash_redis = new Common.Redis.HashRedisHelper();
        //    byte[] imgData = hash_redis.Get<byte[]>("fastdfsfile", guid);

        //    //3.封装进发送model-----------Demo中暂时不做，信息直接封装进XML，正式时再做

        //    #region 飞飞写的压缩程序，对图片进行压缩
        //    //QuYuan注释 3月13日: 将本地绝对路径改为项目下相对路径
        //    string fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/FileUpLoad/");
        //    Stream picture_stream = null;//建立stream
        //    picture_stream = PicturePretreatment.BytesToStream(imgData);
        //    //---------------------图片处理例程--------------------
        //    //需要加载 System.Drawing;
        //    string fileName = guid;
        //    string mmsContent = "这是彩信内容，以string方式输入";
        //    PicturePretreatment pp = new PicturePretreatment(picture_stream);//图片预处理实体
        //    bool err = pp.PicturePretreatments();//图片流预处理，暂无法处理动态gif

        //    //注意：处理中的图片格式可能会变化
        //    //得到的pp.picture_stream是处理后的图片流
        //    byte[] picture_byte = pp.ToBytes();//图片二进制输出
        //    pp.ToFile(fileDirectory + fileName); //图片文件输出file name 不必加扩展名

        //    #endregion

        //    //4.发送
        //    #region 飞飞写的打zip包程序，组成Zip包并返回btye[]

        //    //-----------txt和smil------------------
        //    TxtSmilSynthesis smilFile = new TxtSmilSynthesis(fileDirectory, fileName, pp.picture_format, mmsContent);
        //    smilFile.outputFile();//生成txt和smil文件


        //    //------------------文件压缩例程-------------------------
        //    //需要加载ICSharpCode.SharpZipLib.dll,using ICSharpCode.SharpZipLib.Zip;
        //    ZipTools.ZipFile(fileDirectory + @"Zip\" + fileName + ".zip", fileDirectory, fileName);//压缩匹配的文件

        //    #region QuYuan 3月13日注释
        //    //byte[] zipFileStream = ZipTools.FileToByte(fileDirectory + @"zips\" + fileName + ".zip");//压缩包转为流
        //    #endregion
        //    //4.1 将发送需要的content内容(zip包)转为字符串
        //   //string content = Encoding.ASCII.GetString(zipFileStream);
        //    #endregion
        //    #region QuYuan 3月13日修改，从本地读取zip

        //    //暂时发送指定的zip文件            
        //    String fileNameWithExpand = fileName + ".zip";

        //    string path = System.IO.Path.Combine(fileDirectory+@"Zip\", System.IO.Path.GetFileName(fileNameWithExpand));
        //    #endregion
        //    try
        //    {
        //        //4.2 发送彩信
        //        var res = SMSOA.Areas.Demo.SendMMS.MMSSend.test(path);

        //        //3月14日 修改 
        //        //5.存入fastDFS,获取FileName
        //        var fileNamewithExt = string.Format("{0}.{1}", fileName, "jpg");

        //        var imageParam = new PMS.Model.FdfsParam.ImageUploadParameter(pp.picture_stream, fileNamewithExt, 2);
        //        //此处的result中应加入是否成功的bool值或枚举对象
        //        var result = uploadBLL.UploadImage(imageParam);
        //        //直接调用Fdfs.IBLL接口的实现类即可；以下方法注释
        //        //string fastDFS_fileName = Common.FastDFS.fastDFSTestClient.test(picture_byte);

        //        info = "发送成功且成功存入fastDFS,fileName为" + result.FileName;
        //    }
        //    catch(Exception ex)
        //    {
        //        info = "发送失败或存入FastDFS失败";
        //    }


        //    return Content(info);
        //}
        #endregion

        public ContentResult SendMMS()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string info=null;
            //判断是否存在文件
            if (files.Count > 0)
            {
                //1 获取文件集合中的第一个文件(每次只上传一个文件)
                HttpPostedFile file = files[0];
                //定义文件存放的目标路径
                //保存上传的文件到指定路径中
                //2 将上传的文件读取为二进制数组
                //2.1将上传的图片转成二进制图片
                var file_stream = file.InputStream;
                //file_stream.Flush
                //BinaryReader binary_reader = new BinaryReader(file_stream);
                //2.2读取为二进制数组 *** 此处以后考虑需要使用异步读取
                
                //3.封装进发送model-----------Demo中暂时不做，信息直接封装进XML，正式时再做
                #region 飞飞写的压缩程序，对图片进行压缩
                //QuYuan注释 3月13日: 将本地绝对路径改为项目下相对路径
                string fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/FileUpLoad/");
                Stream picture_stream = file_stream;//建立stream
                //picture_stream = PicturePretreatment.BytesToStream(content);

                //---------------------图片处理例程--------------------
                var guid = Guid.NewGuid();
               var guid_str= guid.ToString();
                guid_str = guid_str.Replace("-", "");
                //需要加载 System.Drawing;
                string fileName = guid_str;
                string mmsContent = "这是彩信内容，以string方式输入";

                BinaryReader reader = new BinaryReader(file_stream);
                var content = reader.ReadBytes((int)file_stream.Length);                
                //BinaryReader reader_test = new BinaryReader(ms);
                //var content_test = reader_test.ReadBytes((int)ms.Length);

                PicturePretreatment pp = new PicturePretreatment(new MemoryStream(content));//图片预处理实体


                bool err = pp.PicturePretreatments();//图片流预处理，暂无法处理动态gif
                //注意：处理中的图片格式可能会变化
                //得到的pp.picture_stream是处理后的图片流
                //byte[] picture_byte = pp.ToBytes();//图片二进制输出
                pp.ToFile(fileDirectory + fileName); //图片文件输出file name 不必加扩展名
                #endregion

                //4.发送
                #region 飞飞写的打zip包程序，组成Zip包并返回btye[]
                
                //-----------txt和smil------------------
                TxtSmilSynthesis smilFile = new TxtSmilSynthesis(fileDirectory, fileName, pp.picture_format, mmsContent);
                smilFile.outputFile();//生成txt和smil文件

                //------------------文件压缩例程-------------------------
                //需要加载ICSharpCode.SharpZipLib.dll,using ICSharpCode.SharpZipLib.Zip;
                ZipTools.ZipFile(fileDirectory + @"Zip\" + fileName + ".zip", fileDirectory, fileName);//压缩匹配的文件
                #endregion

                #region QuYuan 3月13日修改，从本地读取zip
                //暂时发送指定的zip文件            
                String fileNameWithExpand = fileName + ".zip";
                string path = System.IO.Path.Combine(fileDirectory + @"Zip\", System.IO.Path.GetFileName(fileNameWithExpand));
                
                #endregion
                try
                {
                    //4.2 发送彩信
                    //var res = SMSOA.Areas.Demo.SendMMS.MMSSend.test(path);


                    //3月17日
                    //需加入的内容
                    //发送结束后将内容写入S_SMSContent表，并将写入的CID返回
                    //测试用
                    int cid=9306;
                    //3月14日 修改 
                    //5.存入fastDFS,获取FileName
                    var fileNamewithExt = string.Format("{0}.{1}", fileName, "jpg");

                    var imageParam = new PMS.Model.FdfsParam.ImageUploadParameter(new MemoryStream(content), fileNamewithExt, 2);
                    //此处的result中应加入是否成功的bool值或枚举对象
                    Save2Fdfs(imageParam,cid);
                    //var result = uploadBLL.UploadImage(imageParam);
                    //info = "发送成功且成功存入fastDFS,fileName为" + result.FileNameIncludeScroll;
                }
                catch (Exception ex)
                {
                    info = "发送失败或存入FastDFS失败";
                }


                return Content(info);
            }

            return Content("error");
            
        }

        public void Save2Fdfs(PMS.Model.FdfsParam.ImageUploadParameter uploadParam,int cid)
        {
            //1 上传图片
            /*
            ExtName:jpg
            FileName:"wKgBaFjOLt-ATu3XAAAAAAAAAAA319"
            FileNameIncludeExt:"wKgBaFjOLt-ATu3XAAAAAAAAAAA319.jpg"
            FileNameIncludeScroll:"M00/00/00/wKgBaFjOLt-ATu3XAAAAAAAAAAA319.jpg"
            FullFilePath:"http://192.168.1.104/group1/M00/00/00/wKgBaFjOLt-ATu3XAAAAAAAAAAA319.jpg"
            GroupName:"group1"

            TrackerGroup:"group1"
            TrackerPort:"23000"
            TrackerUrl:"192.168.1.104"
            */
            var result = uploadBLL.UploadImage(uploadParam);
            

            //2 根据结果写回FdfsStorage
            //***** 注意先不往storage表中写回数据，上传成功后，并不会返回storage节点的信息 *****
            //2.1 先判断表中是否存在指定的对象
          // var storage_model= fdfsStorageBLL.GetListBy(fs => (fs.GroupName == result.GroupName) && (fs.URL == result.StorageUrl) && (fs.Port == result.StoragePort)).FirstOrDefault();
            FdfsStorage storage_model=null;
            //2.2 没有则创建
            //if (storage_model == null)
            //{
            //    fdfsStorageBLL.Create(new FdfsStorage()
            //    {
            //        GroupName = result.GroupName,
            //        //URL = result.StorageUrl,
            //        //Port = result.StoragePort
            //    });
            //}
            ////2.3 有则取出
            //else
            //{

            //}

            //3 写回FdfsTracker
            //3.1 先判断表中是否存在指定的对象            
            var tracker_model = fdfsTrackerBLL.GetListBy(ft => (ft.URL == result.TrackerUrl) && (ft.GroupName == result.TrackerGroup) && (ft.Port == result.TrackerPort)).FirstOrDefault();
            //3.2 没有则创建
           
            if (tracker_model == null)
            {
                tracker_model = new FdfsTracker()
                {
                    GroupName = result.GroupName,
                    URL = result.TrackerUrl,
                    Port = result.TrackerPort,
                     StorePathIndex=0
                };
                fdfsTrackerBLL.Create(tracker_model);
            }
            //3.3 有则取出
            else
            {

            }

            //4 写回FdfsContent
            int tid = tracker_model.TID;
            int sid = 1;
            //4.1 先判断表中是否存在指定的对象            
            var content_model = fdfsContentBLL.GetListBy(fc => /*(fc.TID == tid) && (fc.SID == sid) && */(fc.FileName == result.FileName)).FirstOrDefault();
            //4.2 没有则创建
            if (content_model == null)
            {
                //4.2.1 找到SMSContent短信内容表中对应的内容
                var smsContent= smsContentBLL.GetListBy(c => c.ID == cid).FirstOrDefault();
                var fdfsContent = new FdfsContent()
                {
                    TID = tid,
                    SID = sid,
                    FileName = result.FileName,
                    ScrollName = result.Scroll,
                    Ext = (int)result.ExtName,

                };
                fdfsContent.S_SMSContent.Add(smsContent);
                fdfsContentBLL.Create(fdfsContent);
            }
            //4.3 有则取出
            else
            {

            }
        }
    }
}