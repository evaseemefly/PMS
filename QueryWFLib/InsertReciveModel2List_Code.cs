using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.SMSModel;

namespace QueryWFLib
{

    public sealed class InsertReciveModel2List_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<SMSModel_QueryReceive> Item { get; set; }

        public InOutArgument<List<SMSModel_QueryReceive>> List_QueryReceive { get; set; }

        /// <summary>
        /// 当前循环中存在符合条件的对象
        /// </summary>
        public InOutArgument<PMS.Model.Enum.MatchCondition_Enum> Match_Enum { get; set; }

        public OutArgument<int> State { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        //qu
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
            var state = context.GetValue(this.Match_Enum);
            Common.LogHelper.WriteLog(string.Format("——执行InsertReciveModel2List_Code事件代码——"));
            List<SMSModel_QueryReceive> list = context.GetValue(List_QueryReceive);
            SMSModel_QueryReceive item = context.GetValue(Item);
            // int state = -1;
            //将拥有符合条件的msgid的item存入list
            Common.LogHelper.WriteLog(string.Format("获取到的集合当前为:{0}个，准备插入的对象为:{1}",list.Count(),Common.SerializerHelper.SerializerToString(item)));
            InsertListModel(item, ref list, ref state);
            Common.LogHelper.WriteLog(string.Format("——加入集合后集合中共有{0}个对象——",list.Count()));
            context.SetValue(Match_Enum, state);
            context.SetValue(List_QueryReceive, list);
            Common.LogHelper.WriteLog(string.Format("——InsertReciveModel2List_Code事件代码执行结束——"));
        }

        /// <summary>
        /// 根据传入的item将item插入集合中
        /// </summary>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <param name="state"></param>
        public static void InsertListModel(SMSModel_QueryReceive item, ref List<SMSModel_QueryReceive> list, ref PMS.Model.Enum.MatchCondition_Enum state)
        {
            if(item != null)
            {
                //将拥有符合条件的msgid的item存入list
                list.Add(item);
                state = PMS.Model.Enum.MatchCondition_Enum.conform;
            }
            else
            {
                
            }
        }
    }
}
