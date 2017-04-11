using ISMS;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISMS
{
    public interface IMMSSend:ISMSSend
    {
        /// <summary>
        /// 在项目目录下生成Zip包
        /// </summary>
        /// <param name="picture_stream">图片流</param>
        /// <param name="fileDirectory">存储的目录</param>
        /// <param name="content">彩信内容</param>
        /// <param name="fileName">赋值后返回的 文件名+拓展名</param>
        /// <returns>压缩包路径</returns>
        string CreateZip(System.IO.Stream picture_stream, string fileDirectory,string content, out string fileName);
        //MMSModel_Send ToSendModel(PMS.Model.ViewModel.ViewModel_MMSMessage model, List<string> list_phones);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        MMSModel_Send ToSendModel(PMS.Model.SMSModel.MMSModel_Send model, List<string> list_phones);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="receive"></param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        bool AfterSend(PMS.Model.ViewModel.ViewModel_MMSMessage model, MMSModel_Receive receive, List<string> list_phones);

  
    }
}
