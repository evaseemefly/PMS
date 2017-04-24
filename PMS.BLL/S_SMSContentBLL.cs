using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PMS.IBLL;
using PMS.Model;
using PMS.Model.SMSModel;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
    public partial class S_SMSContentBLL : BaseBLL<S_SMSContent>, IS_SMSContentBLL, IBaseDelBLL,ICanBeDel
    {
        /// <summary>
        /// 将短信存入SMSMsgContent
        /// </summary>
        /// <param name="smsContent"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public bool SaveMsg(SMSModel_Receive receive, string smsContent, string mid, int uid/*,string title,Model.Enum.MMS_Enum isMMS=Model.Enum.MMS_Enum.sms*/)
        {
            //计算字数要加上{国家海洋预报台}
            double count = ((double)smsContent.Length + 9 )/ 70;
            //S_SMSContent s_smsContent = new S_SMSContent()
            //{   UID = uid,
            //    SMSContent = smsContent,
            //    msgId = receive.msgid,
            //    SendDateTime = DateTime.Now,
            //    SMID = int.Parse(mid),
            //    BlackList =receive.failPhones==null?string.Empty:string.Join(",", receive.failPhones),
            //    ResultCode = int.Parse(receive.result),//此处有错误
            //    smsCount = (int)Math.Ceiling(count),
            //    isMMS=(isMMS==Model.Enum.MMS_Enum.sms?false:true),
            //    MSTitle=(isMMS == Model.Enum.MMS_Enum.sms ?null:title)
            //};
            S_SMSContent s_smsContent = new S_SMSContent()
            {
                UID = uid,
                SMSContent = smsContent,
                msgId = receive.msgid,
                SendDateTime = DateTime.Now,
                SMID = int.Parse(mid),
                BlackList = receive.failPhones == null ? string.Empty : string.Join(",", receive.failPhones),
                ResultCode = int.Parse(receive.result),//此处有错误
                smsCount = (int)Math.Ceiling(count)
            };

            //6月1日：此处有错，此时创建 短信内容对象，其中的id为默认值
            try
            {
                this.Create(s_smsContent);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 彩信存入
        /// </summary>
        /// <param name="receive"></param>
        /// <param name="smsContent"></param>
        /// <param name="mid"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool SaveMsg(MMSModel_Receive receive, string smsContent, string mid, int uid,string MMSTitle)
        {
            //计算字数要加上{国家海洋预报台}
            //double count = ((double)smsContent.Length + 9) / 70;
            S_SMSContent s_smsContent = new S_SMSContent()
            {
                UID = uid,
                SMSContent = smsContent,
                msgId = receive.msgid,
                SendDateTime = DateTime.Now,
                SMID = int.Parse(mid),
                BlackList = receive.failPhones == null ? string.Empty : string.Join(",", receive.failPhones),
                ResultCode = int.Parse(receive.result),//此处有错误
                smsCount = 1,
                isMMS = true,
                MSTitle = MMSTitle

            };

            //6月1日：此处有错，此时创建 短信内容对象，其中的id为默认值
            try
            {
                this.Create(s_smsContent);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 对传入的S_SMSContent集合进行分页查询（并排序以及转为中间变量）
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        private List<S_SMSRecord_Current> ToListByPage(List<S_SMSRecord_Current> query, int pageIndex, int pageSize, ref int rowCount, bool isAsc, bool isMiddle)
        {
            if (isAsc)
            {
                query = query.OrderBy(c => c.PID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                query = query.OrderByDescending(c => c.PID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }

            //3
            if (isMiddle)
            {
                return query.Select(s => s.ToMiddleModel()).ToList();
            }
            else
            {
                return query;
            }
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
        public bool PhysicsDel(List<int> list_ids, bool isCheckCanBeDel = false)
        {
            return true;
        }

        /// <summary>
        /// 根据联系人名称以及电话号码进行多条件查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="model">包含 电话号码 以及 联系人名称 的查询实体对象</param>
        /// <param name="cid"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        public List<S_SMSRecord_Current> GetSMSRecordListByQuery(int pageIndex, int pageSize, ref int rowCount, PMS.Model.ViewModel.ViewModel_RecordQueryInfo model, int cid, bool isAsc, bool isMiddle)
        {
            //根据cid找到对应的短信内容对象
            var smsContent = GetListBy(c => c.ID == cid).FirstOrDefault();
            //******注意此处若不转成中间变量 PersonName与PhoneNum属性会不被赋值
            var query = smsContent.S_SMSRecord_Current.Select(c=>c.ToMiddleModel()).ToList();
            //2 找到其的发送记录
            if (model.PersonName!=null)
            {
                query = query.Where(c => c.PersonName.Contains(model.PersonName)).ToList();
            }
            if(model.PhoneNum!=null)
            {
                query = query.Where(c => c.PhoneNum.Contains(model.PhoneNum)).ToList();
            }
            rowCount = query.Count();
            return ToListByPage(query, pageIndex, pageSize, ref rowCount, isAsc, false);

        }


        /// <summary>
        /// 将黑名单中短信的号码及姓名存入结果集
        /// </summary>
        /// <returns></returns>
        public void getResult(SMSModel_Receive receive,SMSModel_MsgResult result)
        {
                for (var i = 0; i < receive.failPhones.Length; i++)
                {
                    //根据电话号码查找对应联系人
                    var person = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(r => r.PhoneNum.Equals(receive.failPhones[i])).FirstOrDefault();
                    SMSModel_Blacklist blacklist = new SMSModel_Blacklist()
                    {
                        name = person.PName,
                        phoneNumber = receive.failPhones[i]
                    };
                    result.list_Blacklist.Add(blacklist);
                }
        }

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            return null;
        }

        /// <summary>
        /// 分页获取已经软删除的集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<ViewModel_Recycle_Common> GetIsDelbyPageList(int pageIndex, int pageSize, ref int rowCount)
        {
            var query = base.GetPageList<DateTime>(pageIndex, pageSize, a => a.isDel == true, a => a.SendDateTime, true);
            rowCount = query.Count();
            return query.ToList().Select(a => a.ToRecycleModel()).ToList();
        }

        public bool CanBeDel(List<int> list_ids)
        {
            throw new NotImplementedException();
        }
    }
}
