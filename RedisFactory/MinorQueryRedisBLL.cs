using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.QueryModel;
using Common.Redis;
using Common;

namespace RedisFactory
{
	public class MinorQueryRedisBLL : BaseRedisBLL<Redis_MinorQueryConfigModel>
    {
        private ListReidsHelper<Redis_ListMsgIdObj> redisListhelper;

        private HashRedisHelper hash_helper;

		/// <summary>
        /// 实现读取配置文件方法，在父类中调用
        /// </summary>
        /// <returns></returns>
        public override Redis_MinorQueryConfigModel ReadAppConfig()
        {
            TimeSpan interval_QueryAgain;
            TimeSpan.TryParse(ConfigHelper.GetSettingValue("Interval_QueryAgain"), out interval_QueryAgain); 
            TimeSpan interval_OverTime;
            TimeSpan.TryParse(ConfigHelper.GetSettingValue("Interval_OverTime"),out interval_OverTime);
            var list_Key = ConfigHelper.GetSettingValue("List_Key");
            var hash_Key = ConfigHelper.GetSettingValue("Hash_Key");

            return new Redis_MinorQueryConfigModel()
            {
                Hash_Key = hash_Key,
                List_Key = list_Key,
                Interval_OverTime = interval_OverTime,
                Interval_QueryAgain = interval_OverTime
            };
        }

		public MinorQueryRedisBLL()
        {
            //1 创建操作集合的Redis操作类
            redisListhelper = new ListReidsHelper<Redis_ListMsgIdObj>(base.model_config.List_Key);
            hash_helper = new HashRedisHelper();
        }

        /// <summary>
        /// 执行第二个线程的查询操作
        /// </summary>
        public string ExecuteQueryGetWFId()
        {
            //反复执行匹配操作，直到提取出第一个不符合时间间隔的对象才跳出
            //1 先执行去除过期对象的操作
            Redis_ListMsgIdObj first_obj;
            while ((first_obj = CheckFirstObjMatchCondition())==null)
            {
                break;
            }
            //2 判断无过期对象的list中第一个对象是否满足间隔时间
            //var first_obj = redisListhelper.GetFirstObj(base.model_config.List_Key);
            if (CheckFirstObjOvertime(first_obj, base.model_config.Interval_QueryAgain))
            {
                //根据msgid取出对应的hash表中的对象
                if (hash_helper.Exist(base.model_config.Hash_Key, first_obj.MsgId))
                {
                    var obj = hash_helper.Get<Redis_HashWFObj>(base.model_config.Hash_Key, first_obj.MsgId);
                    //3.1 取出WF_Id,并根据该id继续书签
                    var wf_id = obj.WFId;
                    return wf_id; 
                }
                
            }
            return null;
        }
        
        /// <summary>
        /// 从list_msgid中读取msgid及时间，若满足条件则返回该对象
        /// 含MsgId与Dt（创建时间）
        /// 若不存在则返回空
        /// </summary>
        /// <returns></returns>
        public Redis_ListMsgIdObj CheckFirstObjMatchCondition()
        {
            //bool isMatch ;
            //1 从list_msgid中取出第一个对象
            var first_obj = redisListhelper.GetFirstObj(base.model_config.List_Key);
            var msgid = first_obj.MsgId;
            //2 判断对象是否过期，若过期则从list_msgid中删除，并删除掉对应的Hash表中的msgid对应的对象
            var isOverTime = CheckFirstObjOvertime(first_obj,base.model_config.Interval_OverTime);
            //2.2 若超过时间则删除list_msgid以及hash表中msgid对应的对象
            hash_helper = new HashRedisHelper();
            if (isOverTime)
            {
                //(1)删除List_msgid中的指定对象（首元素）
                redisListhelper.DequeueItemFromList(base.model_config.List_Key);
                //(2)删除hash表中msgid对应的对象
                hash_helper.Remove(msgid);
                return first_obj;
            }
            return null ;
        }

        /// <summary>
        /// 判断传入的首元素的时间是否超过传入的时间间隔
        /// </summary>
        /// <param name="obj">首元素</param>
        /// <param name="ts">允许的最大时间间隔</param>
        /// <returns></returns>
        public bool CheckFirstObjOvertime(PMS.Model.QueryModel.Redis_ListMsgIdObj obj, TimeSpan ts)
        {
            //
            TimeSpan sp_now = new TimeSpan(DateTime.Now.Ticks);

            TimeSpan sp_target = new TimeSpan(obj.Dt.Ticks);

            //若对象内的时间已经超过指定的时间范围，则返回false
            if (sp_now.Subtract(sp_target).Duration() > ts)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
