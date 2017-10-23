using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.QueryModel;
using Common.Redis;
using Common;
using PMS.IBLL;
using PMS.BLLRedis;

namespace RedisFactory
{
	public class MinorQueryRedisBLL : BaseRedisBLL<Redis_MinorQueryConfigModel>
    {
        private ListReidsHelper<Redis_ListMsgIdObj> redisListhelper;

        protected ListBLL<Redis_ListMsgIdObj> list_redisBLL { get; set; }

        private HashRedisHelper hash_helper;

        protected HashBLL<Redis_HashWFObj> hash_redisBLL { get; set; }

		/// <summary>
        /// 实现读取配置文件方法，在父类中调用
        /// </summary>
        /// <returns></returns>
        public override Redis_MinorQueryConfigModel ReadAppConfig()
        {
            double interval_QueryAgain;
            double.TryParse(ConfigHelper.GetSettingValue("Interval_QueryAgain"), out interval_QueryAgain);
            double interval_OverTime;
            double.TryParse(ConfigHelper.GetSettingValue("Interval_OverTime"),out interval_OverTime);
            var list_Key = ConfigHelper.GetSettingValue("id_list_msgid");
            var hash_Key = ConfigHelper.GetSettingValue("id_hash");

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

            list_redisBLL = new ListBLL<Redis_ListMsgIdObj>();

            hash_redisBLL = new HashBLL<Redis_HashWFObj>();

            hash_helper = new HashRedisHelper();
        }

        /// <summary>
        /// 执行第二个线程的查询操作
        /// </summary>
        public Redis_HashWFObj  ExecuteQueryGetWFId()
        {
            //反复执行匹配操作，直到提取出第一个不符合时间间隔的对象才跳出
            //1 先执行去除过期对象的操作
            Redis_ListMsgIdObj first_obj;

            //一直从list中取出首元素，并判断是否过期，只要有对象就为true，一直循环到没有对象，即为方法返回为false为止
            while (!CheckFirstObjMatchCondition(out first_obj))
            {
                break;
            }
            //2 判断无过期对象的list中第一个对象是否满足间隔时间
            if (first_obj == null)
            {
                return null;
            }
            //var first_obj = redisListhelper.GetFirstObj(base.model_config.List_Key);
            /*
            2.2 判断当前在list_msgid中的首元素是否已经超过约定的时间间隔
            若未超过，说明仍在符合时间范围内，则继续执行下面操作
            */
            if (!CheckFirstObjOvertime(first_obj, base.model_config.Interval_QueryAgain))
            {
                //根据msgid取出对应的hash表中的对象                
                if (hash_helper.Exist(base.model_config.Hash_Key, first_obj.MsgId))
                {
                    var obj = hash_helper.Get<Redis_HashWFObj>(base.model_config.Hash_Key, first_obj.MsgId);
                    //3.1 取出WF_Id,并根据该id继续书签
                   return obj;
                    //var wf_id = obj.WFId;
                    //return wf_id; 
                }
                
            }
            return null;
        }

        /// <summary>
        /// 从list_msgid中读取msgid及时间，若满足条件则返回该对象(out)
        /// 含MsgId与Dt（创建时间）
        /// 只要list_msgid中包含任意有效的对象则返回true，若集合为空（或集合中对象无效）则返回false
        /// </summary>
        /// <param name="first_obj"></param>
        /// <returns></returns>
        public bool CheckFirstObjMatchCondition(out Redis_ListMsgIdObj first_obj)
        {
            //bool isMatch ;
            //1 从list_msgid中取出第一个对象
            //需要判断当前的redis list集合中是否存在可以封装在redisListhelper.GetFirstObj方法中
            first_obj = redisListhelper.GetFirstObj(base.model_config.List_Key);
            //需要判断第一个对象及第一个对象的msgid是否均不为空        
            if (first_obj!=null&& first_obj.MsgId != null)
            {
                var msgid = first_obj.MsgId;
                //2 判断对象是否过期，若过期则从list_msgid中删除，并删除掉对应的Hash表中的msgid对应的对象
                var isOverTime = CheckFirstObjOvertime(first_obj, base.model_config.Interval_OverTime);
                //2.2 若超过时间则删除list_msgid以及hash表中msgid对应的对象
                hash_helper = new HashRedisHelper();
                if (isOverTime)
                {
                    //(1)删除List_msgid中的指定对象（首元素）
                    redisListhelper.DequeueItemFromList(base.model_config.List_Key);
                    //(2)删除hash表中msgid对应的对象
                    hash_helper.Remove(msgid);                    
                }
                //若未过期，则返回第一个list对象
                return true;
            }            
            return false;
        }

        /// <summary>
        /// 判断传入的首元素的时间是否超过传入的时间间隔
        /// </summary>
        /// <param name="obj">首元素</param>
        /// <param name="ts">允许的最大时间间隔</param>
        /// <returns></returns>
        public bool CheckFirstObjOvertime(Redis_ListMsgIdObj obj, double ts)
        {
            //
            TimeSpan sp_now = new TimeSpan(DateTime.Now.Ticks);

            TimeSpan sp_target = new TimeSpan(obj.Dt.Ticks);

            //若对象内的时间已经超过指定的时间范围，则返回false
            if (sp_now.Subtract(sp_target).Duration().TotalMinutes > ts)
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
