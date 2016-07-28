using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IBLL;
using PMS.Model;
using PMS.Model.SMSModel;

namespace PMS.BLL
{
    public partial class S_SMSRecord_CurrentBLL:BaseBLL<S_SMSRecord_Current>,IS_SMSRecord_CurrentBLL
    {
        /// <summary>
        /// 将查询结果写入数据库
        /// </summary>
        /// <param name="list_queryReceive"></param>
        /// <param name="scid"></param>
        /// <returns></returns>
        public bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive,int scid)
        {
            if (list_QueryReceive != null)
            {
                //1.取得长短信条数
                //6月1日此处为空
                var s_smsContent = this.CurrentDBSession.S_SMSContentDAL.GetListBy(r => r.ID == scid).FirstOrDefault();
                //将长短信条数存入S_SMSContent
                s_smsContent.smsCount = list_QueryReceive.FirstOrDefault().smsCount;
                List<S_SMSRecord_Current> list_current = new List<S_SMSRecord_Current>();
                //2. 遍历查询返回的集合
                foreach (var item in list_QueryReceive)
                {
                    //3.得到该条记录的电话号码对应的联系人
                    var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum .Equals (item.phoneNumber)).FirstOrDefault();
                    //7月28日
                    //思路：连接一次执行批量修改
                    var record= this.CurrentDBSession.S_SMSRecord_CurrentDAL.GetListBy(r => r.PID == person.PID && r.SCID == scid).FirstOrDefault();
                    record.StatusCode = int.Parse(item.status);
                    record.DescContent = item.desc;
                    list_current.Add(record);
                    //S_SMSRecord_Current smsRecord_Current = new S_SMSRecord_Current()
                    //{
                    //    SCID = scid,             
                    //    PID = person.PID,
                    //    StatusCode = int.Parse(item.status),
                    //    DescContent = item.desc,
                    //};
                    //this.CurrentDBSession.S_SMSRecord_CurrentDAL.Create(smsRecord_Current);
                }
                //批量更新
                this.CurrentDBSession.S_SMSRecord_CurrentDAL.UpdateByList(list_current);
                return this.CurrentDBSession.SaveChanges();
            }
            return false;
        }

        

        /// <summary>
        /// 将未收到短信的号码及姓名存入结果集
        /// </summary>
        /// <param name="list_QueryReceive"></param>
        /// <param name="result"></param>
        public void getResult(List<SMSModel_QueryReceive> list_QueryReceive, SMSModel_MsgResult result)
        {
            foreach(var item in list_QueryReceive)
            {
                if ("0".Equals(item.status))
                {

                }
                else
                {
                    var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(item.phoneNumber)).FirstOrDefault();
                    SMSModel_SendFails sendFails = new SMSModel_SendFails()
                    {
                        name = person.PName,
                        phoneNumber = item.phoneNumber
                    };
                    result.list_SendFails.Add(sendFails);
                }
            }
        }
    }
}
