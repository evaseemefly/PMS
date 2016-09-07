using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Common.Redis;

namespace WFTest
{

    public sealed class GetListFromRedis_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<string> Id_List { get; set; }

        public InArgument<double> Secs_Interval { get; set; }

        public OutArgument<List<PMS.Model.QueryModel.Redis_SMSContent>> List_redis { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            //string text = context.GetValue(this.Text);

            //1 根据传入的参数，获取Redis中的集合对象并返回
            //1.1 获取传入的参数
            string id_list = context.GetValue(Id_List);
            //1.2根据Redis中保存的 集合 的 key 获取该Redis帮助类（实例化）
            ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper = new ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent>(id_list);
            //2 取得Redis中保存的该 Key 所对应的集合对象
            var list_final = redisListhelper.GetLast();
            context.SetValue(List_redis, list_final);
        }
    }
}
