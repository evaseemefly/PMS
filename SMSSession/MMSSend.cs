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

namespace SMSFactory
{
    
    
    public class MMSSend : SMSSend , IMMSSend
    {
        IS_SMSContentBLL smsContentBLL { get; set; }
        IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL { get; set; }

        public MMSSend()
        {
            smsContentBLL = new S_SMSContentBLL();
            smsRecord_CurrentBLL = new S_SMSRecord_CurrentBLL();
        }

        /// <summary>
        /// 在项目目录下生成Zip包
        /// </summary>
        /// <param name="picture_stream"></param>
        /// <param name="fileDirectory"></param>

        public string CreateZip(System.IO.Stream picture_stream, string fileDirectory,string content)
        {
            MMSZipProcessing zipProcessing = new MMSZipProcessing(picture_stream, fileDirectory);
            //CreateZipCompleteCallback callback = new CreateZipCompleteCallback(zipProcessing.GetZipUrl);
            return zipProcessing.CreateZip(content);
            
        }
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

