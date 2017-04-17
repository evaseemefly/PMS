using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using SMSFactory;
using ISMS;
using PMS.IBLL;
using PMS.Model.SMSModel;
using Common.Config;
using Common;
using Common.Redis;
using PMS.Model.CombineModel;
using JobManagement;
using PMS.BLL;
using Common.Ioc;

namespace SMSFactory
{

    

    public class MMSSend : SMSSend , IMMSSend
    {
        IS_SMSContentBLL smsContentBLL { get; set; }
        IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL { get; set; }

        public MMSSend()
        {
            smsContentBLL = UnityServiceLocator.Instance.GetService<IS_SMSContentBLL>();
            smsRecord_CurrentBLL = UnityServiceLocator.Instance.GetService<IS_SMSRecord_CurrentBLL>();
        }

        /// <summary>
        /// 在项目目录下生成Zip包
        /// </summary>
        /// <param name="picture_stream"></param>
        /// <param name="fileDirectory"></param>
        /// <param name="content"></param>
        /// <param name="fileName">赋值后返回的 文件名+拓展名</param>
        /// <returns>压缩包路径</returns>

        public string CreateZip(System.IO.Stream picture_stream, string fileDirectory,string content,out string fileName)
        {
            ImageProcessingManagement management = new ImageProcessingManagement();
            //根据不同的业务实例化不同的图片处理类（可用工厂模式改进）
            BaseImageProcessing processing = new MMSZipProcessing(picture_stream, fileDirectory);
            
            management.processingEvent += processing.Excute;
            return management.DoImageProcessing(content, out fileName);
            
            
            //MMSZipProcessing zipProcessing = new MMSZipProcessing(picture_stream, fileDirectory);
            //return zipProcessing.Excute(content,out fileName);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        public MMSModel_Send ToSendModel(PMS.Model.SMSModel.MMSModel_Send model, List<string> list_phones)
        {
            //1.获取配置文件中的账号信息等
            SMSSignConfigHelper smsSign = new SMSSignConfigHelper();
            //2.封装进对象
            MMSModel_Send sendMsg = new MMSModel_Send()
            {
                account = smsSign.account,
                password = smsSign.password,
                content = model.content,
                phones = list_phones.ToArray(),
                sendtime = DateTime.Now,
                sign = smsSign.sign,
                ZipUrl = model.ZipUrl,
                MMSTitle = model.MMSTitle
            };
            return sendMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="receive"></param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        public bool AfterSend(PMS.Model.ViewModel.ViewModel_MMSMessage model,MMSModel_Receive receive,List<string> list_phones)
        {
            //5 将发送的短信以及提交响应存入SMSContent
            var mid = model.SMSMissionID;
            var uid = model.UID;
            bool isSaveMsgOk = smsContentBLL.SaveMsg(receive, model.Content, mid, uid,model.MMSTitle);

            return base.AfterSend_Insert2DBAndRedis(receive, list_phones);
        }

    }

    }

