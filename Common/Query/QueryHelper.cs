using Common.Redis;
using PMS.Model.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Query
{
    /// <summary>
    /// 第二次查询
    /// </summary>
     public class QueryHelper
    {
        /// <summary>
        /// 查询休眠时间
        /// </summary>
        private int sleepTime { get; set; }

        /// <summary>
        /// 第二次查询List_msgid的key
        /// </summary>
        private string key_listmsgid { get; set; }

        private string key_hash { get; set; }


        private ListReidsHelper<Redis_ListMsgIdObj> redisListhelper;

        private HashRedisHelper hash_helper;

        /// <summary>
        /// 第二线程读取对象判断的时间间隔
        /// </summary>
        private TimeSpan Interval_QueryAgain { get; set; }

        private TimeSpan Interval_OverTime { get; set; }

        private string List_Key { get; set; }

        private string Hash_Key { get; set; }

        // private TimeSpan ts { get; set; }

        public QueryHelper()
        {
            //1 创建操作集合的Redis操作类
            redisListhelper = new ListReidsHelper<Redis_ListMsgIdObj>(List_Key);
        }

        /// <summary>
        /// 执行第二个线程的查询操作
        /// </summary>
        public void Execute()
        {
           

        }

        //从list_msgid中读取msgid及时间，若满足条件则返回msgid
        public bool CheckFirstObjMatchCondition()
        {
            //bool isMatch ;
            //1 从list_msgid中取出第一个对象
            var first_obj = redisListhelper.GetFirstObj(List_Key);
            var msgid = first_obj.MsgId;
            //2 判断对象是否过期，若过期则从list_msgid中删除，并删除掉对应的Hash表中的msgid对应的对象
            var isOverTime = CheckFirstObjOvertime(first_obj, Interval_OverTime);
            //2.2 若超过时间则删除list_msgid以及hash表中msgid对应的对象
            hash_helper = new HashRedisHelper();
            if (isOverTime)
            {
                //(1)删除List_msgid中的指定对象（首元素）
                redisListhelper.DequeueItemFromList(List_Key);
                //(2)删除hash表中msgid对应的对象
                hash_helper.Remove(msgid);
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
