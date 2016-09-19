using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model;
using PMS.Model.QueryModel;
using Common.Redis;

namespace WFTest
{

    public sealed class QueryState_BookMark<T> : NativeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public PMS.IBLL.IWF_Query_InstanceBLL wf_queryBLL { get; set; }

        /// <summary>
        /// 工作流名称
        /// </summary>
        public InOutArgument<string> BookMarkName { get; set; }

        /// <summary>
        /// 输出的流程结果
        /// </summary>
        public OutArgument<int> WF_Result { get; set; }

        public OutArgument<int> SetpId { get; set; }

        public OutArgument<T> State { get; set; }

        public InOutArgument<string> MsgId { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            //1 从当前的上下文对象中获取指定名称的书签
            string bookMarkName = context.GetValue(BookMarkName);
            string msgid = context.GetValue(MsgId);
            string key_list=null;
            //2 创建书签
            context.CreateBookmark(bookMarkName, new BookmarkCallback(ContinueExecuteWF));

            //3 将传入的参数转为书签对象（自定义）
            var book_obj= ToBookMarkObj(1, 4, context.WorkflowInstanceId);

            //4.1 写入数据库中的指定表中
            wf_queryBLL = new PMS.BLL.WF_Query_InstanceBLL();
            wf_queryBLL.Create(book_obj);
            //4.2 将发送状态写入Hash表中
            //4.3 将msgid写入List集合中
            Redis_ListMsgIdObj obj_listmsgId = new Redis_ListMsgIdObj()
            {
                 MsgId= msgid,
                 Dt=DateTime.Now
            };

            WriteInList_Redis(key_list, obj_listmsgId);
        }

        /// <summary>
        /// 需要重写此方法并返回true，否则工作流无法执行异步操作
        /// </summary>
        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        private WF_Query_Instance ToBookMarkObj(int state,int wf_result,Guid wf_guid)
        {
            return new WF_Query_Instance()
            {
                 SubTime=DateTime.Now,
                 Status = state,
                 Result=wf_result,
                 ApplicationId= wf_guid
            };
        }

        /// <summary>
        /// 将msgid以及当前时间写入Redis的集合中
        /// </summary>
        /// <param name="key_list"></param>
        /// <param name="obj"></param>
        private void WriteInList_Redis(string key_list, Redis_ListMsgIdObj obj)
        {
            ListReidsHelper<Redis_ListMsgIdObj> redisListhelper = new ListReidsHelper<Redis_ListMsgIdObj>(key_list);
            redisListhelper.Add(obj);
        }

        private void WriteInHash_Redis(string key_hash, Redis_HashWFObj obj)
        {
            HashRedisHelper redisHashhelper = new HashRedisHelper();
            redisHashhelper.Set<Redis_HashWFObj>(key_hash,obj.MsgId,obj);
        }


        /// <summary>
        /// 恢复bookmark后调用的方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        public void ContinueExecuteWF(
    NativeActivityContext context,
    Bookmark bookmark,object value)
        {

            //继续执行查询方法
            var data = (PMS.Model.WFModel.BookMarkObj<T>)value;

            context.SetValue(BookMarkName, data.BookMarkName);

            context.SetValue(SetpId, data.StepId);

            //此时的State是唤醒此书签时传入的对象这种附加的
            //第一次查询结束后写入数据库的数据
            //若第一次查询（循环查询）一直到返回“成功为止”
            //原本的想法是查询此msgid的接收状态若数量为发送的总人数则说明发送成功修改状态，若不等于发送总人数，则修改状态为1
            context.SetValue(State, data.State);

            context.SetValue(MsgId, data.MsgId);

            //执行回调函数时，传入数据库中记录的该工作流的流程Result，
            context.SetValue(this.WF_Result, data.WF_Result);
        }

    }
}
