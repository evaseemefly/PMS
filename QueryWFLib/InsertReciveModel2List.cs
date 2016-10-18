using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.SMSModel;

namespace QueryWFLib
{

    public sealed class InsertReciveModel2List : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<SMSModel_QueryReceive> Item { get; set; }

        public InOutArgument<List<SMSModel_QueryReceive>> List_QueryReceive { get; set; }
        public OutArgument<int> State { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        //qu
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
            List<SMSModel_QueryReceive> list = context.GetValue(List_QueryReceive);
            SMSModel_QueryReceive item = context.GetValue(Item);
            int state = -1;
            //将拥有符合条件的msgid的item存入list
            InsertListModel(item, ref list, out state);
            context.SetValue(State, state);
            context.SetValue(List_QueryReceive, list);
        }

        public static void InsertListModel(SMSModel_QueryReceive item, ref List<SMSModel_QueryReceive> list, out int state)
        {
            if(item != null)
            {
                //将拥有符合条件的msgid的item存入list
                list.Add(item);
                state = 0;
            }
            else
            {
                state = 2;
            }
        }
    }
}
