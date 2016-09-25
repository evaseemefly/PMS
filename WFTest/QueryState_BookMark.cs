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

        public PMS.IBLL.IRedis_ListBLL<Redis_ListMsgIdObj> redis_list_bll { get; set; }

        public PMS.IBLL.IRedis_HashBLL<Redis_HashWFObj> redis_hash_bll { get; set; }

        /// <summary>
        /// 工作流名称
        /// </summary>
        public InOutArgument<string> BookMarkName { get; set; }

        public InArgument<string> Id_list_msgid { get; set; }

        public InArgument<string> Id_hash { get; set; }

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
            string key_list=context.GetValue(Id_list_msgid);
            string key_hash = context.GetValue(Id_hash);

            //2 
            redis_list_bll=new PMS.BLLRedis.ListBLL<Redis_ListMsgIdObj>();
            redis_hash_bll = new PMS.BLLRedis.HashBLL<Redis_HashWFObj>();

            int state = 1;
            int wf_result = 1;
            //2 创建书签
            context.CreateBookmark(bookMarkName, new BookmarkCallback(ContinueExecuteWF));

            //3 将传入的参数转为书签对象（自定义）
            var book_obj= ToBookMarkObj(1, 4, context.WorkflowInstanceId);

            //4.1 写入数据库中的指定表中
            wf_queryBLL = new PMS.BLL.WF_Query_InstanceBLL();
            wf_queryBLL.Create(book_obj);

            //4.2 创建要写入redis中的两个对象（hash与list中保存数据的对象）
            //（1）hash中存储的对象
            Redis_HashWFObj obj_hashWF = new Redis_HashWFObj()
            {
                Dt = DateTime.Now,
                MsgId = msgid,
                WF_Result = wf_result,
                WFId = context.WorkflowInstanceId.ToString("N")
            };
            //（2）list中存储的对象
            Redis_ListMsgIdObj obj_listmsgId = new Redis_ListMsgIdObj()
            {
                MsgId = msgid,
                Dt = DateTime.Now
            };

            //4.3
            //（1）将发送状态写入Hash表中
            //redis_hash_bll.WriteInHash_Redis(key_hash, obj_hashWF.MsgId,obj_hashWF);
            WriteInHash_Redis(key_hash, obj_hashWF);
            //（2）将msgid写入List集合中
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

        /// <summary>
        /// 根据输入的参数返回书签对象
        /// </summary>
        /// <param name="state"></param>
        /// <param name="wf_result"></param>
        /// <param name="wf_guid"></param>
        /// <returns></returns>
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
        private bool WriteInList_Redis(string key_list, Redis_ListMsgIdObj obj)
        {
            return redis_list_bll.WriteInList_Redis(key_list, obj);
            //ListReidsHelper<Redis_ListMsgIdObj> redisListhelper = new ListReidsHelper<Redis_ListMsgIdObj>(key_list);
            //return redisListhelper.Add(obj);
        }

        /// <summary>
        /// 向指定key的hash中写入hash中存储的对象
        /// </summary>
        /// <param name="key_hash"></param>
        /// <param name="obj"></param>
        private bool WriteInHash_Redis(string key_hash, Redis_HashWFObj obj)
        {
           return this.redis_hash_bll.WriteInHash_Redis(key_hash, obj.MsgId, obj);
            //HashRedisHelper redisHashhelper = new HashRedisHelper();
            //return redisHashhelper.Set<Redis_HashWFObj>(key_hash,obj.MsgId,obj);
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
