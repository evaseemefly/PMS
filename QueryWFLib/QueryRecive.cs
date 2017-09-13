using Common.Ioc;
using Common.Redis;
using PMS.IBLL;
using PMS.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.SMSModel;
using PMS.Model.Enum;
using PMS.Model;

namespace QueryWFLib
{
    public class QueryRecive
    {
        /// <summary>
        /// 短信的查询结果
        /// （只能在构造函数中为其赋值）
        /// </summary>
        public SMSModel_QueryReceive QueryReceive_SMS{get;private set;}
        

        public QueryRecive(SMSModel_QueryReceive queryReceive)
        {
            this.QueryReceive_SMS = queryReceive;
        }

        /// <summary>
        /// 1 判断当前查询对象的msgid是否包含在redis中；
        /// 2 判断当前查询对象的电话号码是否包含在数据库中；
        /// 返回是否存在的枚举
        /// </summary>
        /// <returns></returns>
        public ExistEnum Execute()
        {
            ExistEnum enum_exist = ExistEnum.isNotExist;
            //
            Common.LogHelper.WriteLog(string.Format("——执行CheckMsgIdInRedis_Code事件代码——"));
            //在redis中判断 item.msgId  item.phoneNumber是否已经存在于redis中
            if (CheckMsgIdExist(QueryReceive_SMS.msgId))
            {
                //判断当前msgid是否含有对应的电话号码（从数据库中查取）
                enum_exist = CheckTargetMsgIdContainsPhone(QueryReceive_SMS.msgId, QueryReceive_SMS.phoneNumber);
            }
            Common.LogHelper.WriteLog(string.Format("——CheckMsgIdInRedis_Code事件代码执行结束——"));
            return enum_exist;   
        }

        /// <summary>
        /// 判断指定的msgid是否存在于当前redis中
        /// </summary>
        /// <param name="msgid"></param>
        /// <returns></returns>
        private bool CheckMsgIdExist(string msgid)
        {
            //判断redis中的string中是否存有指定的msgid
            StringRedisHelper redis_string = new StringRedisHelper();
            string temp = null;
            //加入日志
            try
            {
                temp = redis_string.Get(msgid);                
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex.ToString());
                //throw ex;
            }

            Common.LogHelper.WriteLog(string.Format("步骤{0}：msgid为{1},{2}在redis缓存中", "3", msgid, temp == null ? "n" : "y"));
            //temp应为1
            if (temp != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 判断指定msgid对应的短信记录中是否包含指定电话
        /// </summary>
        /// <param name="msgid"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        private ExistEnum CheckTargetMsgIdContainsPhone(string msgid, string phone)
        {
            IS_SMSContentBLL contentBLL = UnityServiceLocator.Instance.GetService<IS_SMSContentBLL>();
            //IEnumerable<S_SMSRecord_Current> record_temp;
            //根据指定msgid查询短信内容表
            var content_temp = contentBLL.GetListBy(c => c.msgId == msgid).FirstOrDefault();
            if (content_temp!=null){
                //根据msgid的短信（彩信）内容表查询对应的发送记录（短彩信共用一张表）
                var record_temp = from r in content_temp.S_SMSRecord_Current
                                  where r.PhoneNum == phone
                                  select r;
                //若存在记录，则返回存在，否则返回不存在
                if (record_temp != null)
                {
                    return ExistEnum.isExist;
                }
            }     
            return ExistEnum.isNotExist;
        }
    }
}
