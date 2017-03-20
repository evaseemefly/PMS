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

namespace SMSFactory
{
    
    
    public class MMSSend : SMSSend , IMMSSend
    {
        IS_SMSContentBLL smsContentBLL { get; set; }
        IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL { get; set; }
        /// <summary>
        /// 在项目目录下生成Zip包
        /// </summary>
        /// <param name="picture_stream"></param>
        /// <param name="fileDirectory"></param>

        public string CreateZip(System.IO.Stream picture_stream, string fileDirectory)
        {
            MMSZipProcessing zipProcessing = new MMSZipProcessing(picture_stream, fileDirectory);
            //CreateZipCompleteCallback callback = new CreateZipCompleteCallback(zipProcessing.GetZipUrl);
            return zipProcessing.CreateZip();
            
        }
        public MMSModel_Send ToSendModel(PMS.Model.ViewModel.ViewModel_MMSMessage model, List<string> list_phones)
        {
            //1.获取配置文件中的账号信息等
            SMSSignConfigHelper smsSign = new SMSSignConfigHelper();
            //2.封装进对象
            MMSModel_Send sendMsg = new MMSModel_Send()
            {
                account = smsSign.account,
                password = smsSign.password,
                content = model.Content,
                phones = list_phones.ToArray(),
                sendtime = DateTime.Now,
                sign = smsSign.sign,
                zipUrl = model.ZipUrl,
                MMSTitle = model.MMSTitle
            };
            return sendMsg;
        }
        public bool AfterSend(PMS.Model.ViewModel.ViewModel_MMSMessage model,MMSModel_Receive receive,List<string> list_phones,string redis_list_id,int redis_expirationDate = 72)
        {
            //5 将发送的短信以及提交响应存入SMSContent
            var mid = model.SMSMissionID;
            var uid = model.UID;
            bool isSaveMsgOk = smsContentBLL.SaveMsg(receive, model.Content, mid, uid,model.MMSTitle);

            //在current表中存入发送信息，在query之前，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
            //7月28日 注意此处已修改方法为：CreateReceieveMsg！！！
            if (!smsRecord_CurrentBLL.CreateReceieveMsg(receive.msgid, list_phones))
            {
                return false;
            }
            /*步骤六：
                    写入redis缓存中
                    （此处应放在SMSFactory.SendMsg中或写在JobInstance中的SendJob.Exceuted）
            */
            ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper = new ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent>(redis_list_id);
            //2017-1-22 加入判断，若msgid为""或电话集合为空，则不写入redis中
            if (!receive.msgid.Equals("") && list_phones != null)
            {
                StringRedisHelper redisStrhelper = new StringRedisHelper();
                redisStrhelper.Set(receive.msgid, "1", DateTime.Now.AddMinutes(redis_expirationDate));
                //2017年2月4日 添加释放资源
                redisStrhelper.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    }

