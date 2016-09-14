using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Redis;
using PMS.Model.QueryModel;
using System.Activities;

namespace WFTest
{
    public class MinorQuery
    {
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

        public MinorQuery()
        {
            //1 创建操作集合的Redis操作类
            redisListhelper = new ListReidsHelper<Redis_ListMsgIdObj>(List_Key);
        }

        /// <summary>
        /// 执行第二个线程的查询操作
        /// </summary>
        public void Execute()
        {
            //反复执行匹配操作，直到提取出第一个不符合时间间隔的对象才跳出
            //1 先执行去除过期对象的操作
            while (CheckFirstObjMatchCondition())
            {

            }
            //2 判断无过期对象的list中第一个对象是否满足间隔时间
            var first_obj = redisListhelper.GetFirstObj(List_Key);
            if(CheckFirstObjOvertime(first_obj, Interval_QueryAgain))
            {
                //根据msgid取出对应的hash表中的对象
                if(hash_helper.Exist(Hash_Key, first_obj.MsgId))
                {
                  var obj=  hash_helper.Get<Redis_HashWFObj>(Hash_Key, first_obj.MsgId);
                    //3.1 取出WF_Id,并根据该id继续书签
                    var wf_id = obj.WFId;

                    //3.2 恢复工作流
                    Activity workflow_temp = new MainStatistics_Advanced();

                    //恢复工作流
                    var work_reus=Common.WorkFlowAppHelper.LoadWorkflowApplication(workflow_temp, Guid.Parse("9c7b78a5-e6f2-496b-9ba9-bc80b48e2aee"));

                    //3.3 读取WF_Query_Instance表根据指定WF_Id取出对应的State、StepId、WF_Result（或从hash中读取）！！！！！
                    var bookmark = new PMS.Model.WFModel.BookMarkObj<int>()
                    {
                        BookMarkName = "恢复书签",
                        State = 1,
                        StepId = 1,
                        WF_Result = 6
                    };
                    work_reus.ResumeBookmark("书签1", bookmark);
                }
            }

        }

        //从list_msgid中读取msgid及时间，若满足条件则返回msgid
        private bool CheckFirstObjMatchCondition()
        {
            //bool isMatch ;
            //1 从list_msgid中取出第一个对象
           var first_obj= redisListhelper.GetFirstObj(List_Key);
            var msgid = first_obj.MsgId;
            //2 判断对象是否过期，若过期则从list_msgid中删除，并删除掉对应的Hash表中的msgid对应的对象
           var isOverTime= CheckFirstObjOvertime(first_obj, Interval_OverTime);
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
        private bool CheckFirstObjOvertime(PMS.Model.QueryModel.Redis_ListMsgIdObj obj,TimeSpan ts)
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
