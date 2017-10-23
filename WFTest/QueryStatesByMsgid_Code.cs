﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.SMSModel;
using PMS.IBLL;
using ISMS;

namespace WFTest
{

    public sealed class QueryStatesByMsgid_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数E:\03协同开发\短信\PMS\0630\PMS\WFTest\QueryStatesByMsgid_Code.cs
        public InArgument<string> Text { get; set; }

        /// <summary>
        /// 查询条件对象
        /// </summary>
        public InArgument<PMS.Model.QueryModel.Redis_SMSContent> Query_model { get; set; }

        /// <summary>
        /// 短信唯一识别码
        /// </summary>
        public InArgument<string> MsgId { get; set; }

        //返回查询状态（先设定为string）类型
        /// <summary>
        /// 查询之后返回的状态
        /// </summary>
        public OutArgument<int> State { get; set; }

        /// <summary>
        /// 输入以及输出的工作流状态
        /// </summary>
        public InOutArgument<int> Result { get; set; }

        /// <summary>
        /// 本次查询的回执
        /// </summary>
        public OutArgument<List<SMSModel_QueryReceive>> List_QueryReceive { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            //string text = context.GetValue(this.Text);

            //进行查询传入的msgid的
            var list = new List<SMSModel_QueryReceive>();
            int state = -1;

            //var model = context.GetValue(Query_model);

            var msgid = context.GetValue(this.MsgId);

            //此处查询只是将msgid传入即可
            ToQuery(msgid, out list, out state);

            context.SetValue(State, state);
            context.SetValue(List_QueryReceive, list);
        }

        /// <summary>
        /// 根据msgid执行查询接收短信状态
        /// </summary>
        /// <param name="msgid"></param>
        public static void ToQuery(string msgid,out List<SMSModel_QueryReceive> list_queryReceive,out int state)
        {
            //IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();
            //以后通过spring .net 实现
            ISMSQuery smsQuery = new SMSFactory.SMSQuery();

            IS_SMSContentBLL smsContentBLL = new PMS.BLL.S_SMSContentBLL();
            IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = new PMS.BLL.S_SMSRecord_CurrentBLL();

            string account = "dh74381"; //账号"dh74381";
            string passWord = "uAvb3Qey";//密码 = "uAvb3Qey";
            //6 查询发送状态(是否加入等待时间？)
            SMSModel_Query queryMsg = new SMSModel_Query()
            {
                account = account,
                password = passWord,
                smsId = msgid,
                //phoneNums=model.PhoneNums
            };
            List<SMSModel_QueryReceive> list_QueryReceive;

            //根据传入的信息进行查询，并有一个状态信息集合
            bool isGetReturnMsg = smsQuery.QueryMsg(queryMsg, out list_QueryReceive);
            //根据传入的状态集合进行判断当前的状态
            var index_state = 0;//smsQuery.GetQueryState(list_QueryReceive);此处已修改

            //为变量赋值
            list_queryReceive = list_QueryReceive;
            state = index_state;

            if (!isGetReturnMsg)
            {
                //查询结果有问题，跳出本次查询
                state = 2;
                return;
                // return Content("服务器错误");
            }
            //当查询返回的集合数量为1，且唯一的对象的desc为成功，则直接跳出，不进行下面的操作，并对state赋值为1
            if (list_QueryReceive.Count() == 1 && list_queryReceive.FirstOrDefault().desc == "成功"&&list_queryReceive.FirstOrDefault().phoneNumber==null)
            {
                //返回的desc=成功
                state = 1;
                             
                //return;
            }
            //7 获取该次发送的SMSContent的ID
            var list = smsContentBLL.GetListBy(p => p.msgId.Equals(msgid));
            int scid = list.FirstOrDefault().ID;
            //向数据库中写入本集合中的对象   
            bool isSaveCurrnetMsgOk = smsRecord_CurrentBLL.SaveReceieveMsg(list_QueryReceive, scid);
            if (list_QueryReceive.Count() == 0)
            {
                state = 99;
                //ToShow("当前取出的对象中接收内容有误");
                //return;
            }           
           
        }
    }
}
