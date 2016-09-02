using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IBLL;
using PMS.Model;
using PMS.Model.SMSModel;
using PMS.Model.ViewModel;
using PMS.Model.Dictionary;
using System.Text.RegularExpressions;

namespace PMS.BLL
{
    public partial class S_SMSRecord_CurrentBLL:BaseBLL<S_SMSRecord_Current>,IS_SMSRecord_CurrentBLL, IBaseDelBLL
    {
        #region 8月19日 备份之前的
        ///// <summary>
        ///// 将查询结果写入数据库
        ///// </summary>
        ///// <param name="list_queryReceive"></param>
        ///// <param name="scid"></param>
        ///// <returns></returns>
        //public bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive, int scid)
        //{
        //    //1.取得长短信条数-------------------已经在S_SMSContentBLL的saveMsg方法中实现，不需要在这里实现了

        //    if (list_QueryReceive != null)
        //    {

        //        //6月1日此处为空

        //        //将长短信条数存入S_SMSContent
        //        // s_smsContent.smsCount = list_QueryReceive.FirstOrDefault().smsCount;
        //        List<S_SMSRecord_Current> list_current = new List<S_SMSRecord_Current>();
        //        //1. 得到该次短信的所有的Record_Current列表
        //        //!!!注意不要按一下方式写！！！
        //        //S_SMSContentBLL smscontentBLL = new S_SMSContentBLL();
        //        var list_smsRecord_Current = this.CurrentDBSession.S_SMSContentDAL.GetListBy(p => p.ID == scid).FirstOrDefault().S_SMSRecord_Current.ToList();
        //        //2. 遍历查询返回的集合
        //        foreach (var item in list_QueryReceive)
        //        {
        //            //3.得到该条记录的电话号码对应的联系人
        //            var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(item.phoneNumber)).FirstOrDefault();
        //            //3.在数据库中写入数据，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
        //            //7月28日
        //            //思路：连接一次执行批量修改
        //            var record = this.CurrentDBSession.S_SMSRecord_CurrentDAL.GetListBy(r => r.PID == person.PID && r.SCID == scid).FirstOrDefault();
        //            record.StatusCode = int.Parse(item.status);
        //            record.DescContent = item.desc;
        //            list_current.Add(record);

        //        }
        //        //批量更新
        //        this.CurrentDBSession.S_SMSRecord_CurrentDAL.UpdateByList(list_current);
        //        return this.CurrentDBSession.SaveChanges();
        //    }
        //    return false;
        //}
        #endregion

        /// <summary>
        /// 将查询结果写入数据库
        /// </summary>
        /// <param name="list_queryReceive"></param>
        /// <param name="scid"></param>
        /// <returns></returns>
        public bool SaveReceieveMsg(List<SMSModel_QueryReceive> list_QueryReceive, int scid)
        {
            //1.取得长短信条数-------------------已经在S_SMSContentBLL的saveMsg方法中实现，不需要在这里实现了
            if (list_QueryReceive != null)
            {
                //创建回执Desc的字典
                var dictionary = SMSQueryDictionary.GetResponseCode();

                //6月1日此处为空

                //将长短信条数存入S_SMSContent
                // s_smsContent.smsCount = list_QueryReceive.FirstOrDefault().smsCount;
                List<S_SMSRecord_Current> list_current = new List<S_SMSRecord_Current>();
                //1. 得到该次短信的所有的Record_Current列表
                //!!!注意不要按一下方式写！！！
                //S_SMSContentBLL smscontentBLL = new S_SMSContentBLL();
                var list_smsRecord_Current = this.CurrentDBSession.S_SMSContentDAL.GetListBy(p => p.ID == scid).FirstOrDefault().S_SMSRecord_Current.ToList();
                //2. 遍历查询返回的集合
                foreach (var item in list_QueryReceive)
                {
                    //3.得到该条记录的电话号码对应的联系人
                    var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(item.phoneNumber)).FirstOrDefault();
                    //3.在数据库中写入数据，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
                    //7月28日
                    //思路：连接一次执行批量修改
                    string desc = "";
                    //得到回执的desc内容,判断是否为纯数字，如果是数字，就按照字典对应内容存入数据库；否则，直接存入数据库
                    if (Regex.IsMatch(item.desc, @"^\d+$"))
                    {
                        //是数字
                        desc = dictionary[int.Parse(item.desc)];
                    }
                    else
                    {
                        //不是数字
                        desc = item.desc;
                    }

                    var record = this.CurrentDBSession.S_SMSRecord_CurrentDAL.GetListBy(r => r.PID == person.PID && r.SCID == scid).FirstOrDefault();
                    record.StatusCode = int.Parse(item.status);
                    record.DescContent = desc;
                    list_current.Add(record);
                }
                //批量更新
                this.CurrentDBSession.S_SMSRecord_CurrentDAL.UpdateByList(list_current);
                return this.CurrentDBSession.SaveChanges();
            }
            return false;
        }

        /// <summary>
        /// 在数据库中写入数据，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
        /// </summary>
        /// <param name="msgid"></param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        public bool CreateReceieveMsg(string msgid, List<string> list_phones)
        {
            if (list_phones != null && !msgid.Equals(""))
            {
                //!!!注意不要按照如下注释掉的方式写！！                
                //S_SMSContentBLL smscontentBLL = new S_SMSContentBLL();
                //1.获取对应的smscontent表的ID
                var scid = this.CurrentDBSession.S_SMSContentDAL.GetListBy(p => p.msgId.Equals(msgid)).FirstOrDefault().ID;

                foreach (var item in list_phones)
                {
                    //2.获取每一个发出电话号码对应的联系人ID
                    var personID = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(item)).FirstOrDefault().PID;
                    //3.在数据库中写入数据，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
                    //屈远的
                    S_SMSRecord_Current smsRecord_Current = new S_SMSRecord_Current()
                    {
                        SCID = scid,
                        PID = personID,
                        StatusCode = 98,
                        DescContent = "暂时未收到查询回执"
                    };
                    this.CurrentDBSession.S_SMSRecord_CurrentDAL.Create(smsRecord_Current);
                }
            }
            return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            return true;
        }


        /// <summary>
        /// 根据传入的id集合执行物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids)
        {
            return true;
        }

        #region 暂时不使用了
        ///<summary>
        ///在current表中存入发送信息，在query之前，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
        ///</summary>
        ///<param name="list_phones"></param>
        ///<param name="scid"></param>
        //public bool SaveTempReceieveMsg(string msgid, List<string> list_phones) {
        //    if(list_phones != null && !msgid.Equals(""))
        //    {
        //        S_SMSContentBLL smscontentBLL = new S_SMSContentBLL();
        //        List<S_SMSRecord_Current> list_current = new List<S_SMSRecord_Current>();
        //        //1.获取对应的smscontent表的ID
        //        var scid =  smscontentBLL.GetListBy(p => p.msgId.Equals(msgid)).FirstOrDefault().ID;
        //        foreach(var item in list_phones)
        //        {
        //            //2.获取每一个发出电话号码对应的联系人ID
        //            var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(item)).FirstOrDefault();
        //            //3.在数据库中写入数据，表中的StatusCode默认为98，DescContent默认为"暂时未收到查询回执"
        //            //7月28日
        //            //思路：连接一次执行批量修改
        //            var record= this.CurrentDBSession.S_SMSRecord_CurrentDAL.GetListBy(r => r.PID == person.PID && r.SCID == scid).FirstOrDefault();
        //            record.StatusCode = int.Parse(item.status);
        //            record.DescContent = item.desc;
        //            list_current.Add(record);

        //        }

        //        //批量更新
        //        this.CurrentDBSession.S_SMSRecord_CurrentDAL.UpdateByList(list_current);
        //        return this.CurrentDBSession.SaveChanges();
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        #endregion



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

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            return null;
        }
    }
}
