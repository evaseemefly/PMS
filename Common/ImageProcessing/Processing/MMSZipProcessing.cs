using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{

    
    /// <summary>
    /// 回调函数
    /// </summary>
    /// <returns></returns>
    //public delegate string CreateZipCompleteCallback(string fileName);
    public class MMSZipProcessing: BaseImageProcessing
    {
        public MMSZipProcessing(System.IO.Stream picture_stream, string fileDirectory)
        {
            this.picture_stream = picture_stream;
            this.fileDirectory = fileDirectory;
        }

        //        public string CreateZip(CreateZipCompleteCallback callback)
        //        {
        //            #region 飞飞写的压缩程序，对图片进行压缩
        //            //QuYuan注释 3月13日: 将本地绝对路径改为项目下相对路径

        //            //---------------------图片处理例程--------------------
        //            var guid = Guid.NewGuid();
        //            var guid_str = guid.ToString();
        //            guid_str = guid_str.Replace("-", "");
        //            //需要加载 System.Drawing;
        //            string fileName = guid_str;
        //            string mmsContent = "这是彩信内容，以string方式输入";
        //            PicturePretreatment pp = new PicturePretreatment(picture_stream);//图片预处理实体
        //            bool err = pp.PicturePretreatments();//图片流预处理，暂无法处理动态gif

        //            //注意：处理中的图片格式可能会变化
        //            //得到的pp.picture_stream是处理后的图片流
        //            //byte[] picture_byte = pp.ToBytes();//图片二进制输出
        //            pp.ToFile(fileDirectory + fileName); //图片文件输出file name 不必加扩展名
        //            #endregion

        //            //4.发送
        //            #region 飞飞写的打zip包程序，组成Zip包并返回btye[]

        //            //-----------txt和smil------------------
        //            TxtSmilSynthesis smilFile = new TxtSmilSynthesis(fileDirectory, fileName, pp.picture_format, mmsContent);
        //            smilFile.outputFile();//生成txt和smil文件

        //            //------------------文件压缩例程-------------------------
        //            //需要加载ICSharpCode.SharpZipLib.dll,using ICSharpCode.SharpZipLib.Zip;
        //            ZipTools.ZipFile(fileDirectory + @"Zip\" + fileName + ".zip", fileDirectory, fileName);//压缩匹配的文件
        //            #endregion
        //            return callback(fileName);
        //        }

        //        /// <summary>
        //        /// 获取Zip文件的绝对路径
        //        /// </summary>
        //        /// <param name="fileName"></param>
        //        /// <returns></returns>
        //        public string GetZipUrl(string fileName)
        //        {
        //            #region QuYuan 3月13日修改，从本地读取zip
        //            //暂时发送指定的zip文件            
        //            String fileNameWithExpand = fileName + ".zip";
        //            string path = System.IO.Path.Combine(fileDirectory + @"Zip\", System.IO.Path.GetFileName(fileNameWithExpand));
        //#endregion
        //            return path;
        //        }
        /// <summary>
        /// 对图片进行压缩
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileNameIncludeExt">赋值后返回的 文件名+拓展名</param>
        /// <returns>压缩包存储路径</returns>
            public override string Excute(string content,out string fileNameIncludeExt)
            {
                #region 飞飞写的压缩程序，对图片进行压缩
                //QuYuan注释 3月13日: 将本地绝对路径改为项目下相对路径

                //---------------------图片处理例程--------------------
                var guid = Guid.NewGuid();
                var guid_str = guid.ToString();
                guid_str = guid_str.Replace("-", "");
                //需要加载 System.Drawing;
                string fileName = guid_str;
                string mmsContent = content;
                PicturePretreatment pp = new PicturePretreatment(picture_stream);//图片预处理实体
                bool err = pp.PicturePretreatments();//图片流预处理，暂无法处理动态gif

                //注意：处理中的图片格式可能会变化
                //得到的pp.picture_stream是处理后的图片流
                //byte[] picture_byte = pp.ToBytes();//图片二进制输出
               fileNameIncludeExt= pp.ToFile(fileDirectory + fileName); //图片文件输出file name 不必加扩展名
                #endregion

                //4.发送
                #region 飞飞写的打zip包程序，组成Zip包并返回btye[]

                //-----------txt和smil------------------
                TxtSmilSynthesis smilFile = new TxtSmilSynthesis(fileDirectory, fileName, pp.picture_format, mmsContent);
                smilFile.outputFile();//生成txt和smil文件

                //------------------文件压缩例程-------------------------
                //需要加载ICSharpCode.SharpZipLib.dll,using ICSharpCode.SharpZipLib.Zip;
                ZipTools.ZipFile(fileDirectory + @"Zip\" + fileName + ".zip", fileDirectory, fileName);//压缩匹配的文件
                String fileNameWithExpand = fileName + ".zip";
                string path = System.IO.Path.Combine(fileDirectory + @"Zip\", System.IO.Path.GetFileName(fileNameWithExpand));
            #endregion
                return path;
            }
    }
}
