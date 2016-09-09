using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Common.Redis;

namespace WFTest
{

    public sealed class GetObjFromListByCheck_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<List<PMS.Model.QueryModel.Redis_SMSContent>> List_redis { get; set; }

        public InArgument<string> Key_RedisList { get; set; }

        public InArgument<double> Secs_Interval { get; set; }

        public OutArgument<PMS.Model.QueryModel.Redis_SMSContent> First_Obj { get; set; }
                ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent> redisListhelper;

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            //string text = context.GetValue(this.Text);
            //1 取出传入的集合和时间间隔变量
            var list = context.GetValue(List_redis);
            var secs = context.GetValue(Secs_Interval);
            var key = context.GetValue(Key_RedisList);
            redisListhelper = new ListReidsHelper<PMS.Model.QueryModel.Redis_SMSContent>(key);
            //2 获取超出时间间隔的第一个对象
            //var first = new PMS.Model.QueryModel.Redis_SMSContent();
            var first =  CheckTimeOut_RedisList(list, secs,key);
            if (first != null)
            {
                //3 为传出变量赋值
                context.SetValue(this.First_Obj, first);
                //first = new PMS.Model.QueryModel.Redis_SMSContent();
            }
            
           
        }

        public PMS.Model.QueryModel.Redis_SMSContent CheckTimeOut_RedisList(List<PMS.Model.QueryModel.Redis_SMSContent> list_final, double seconds_add,string key_redis)
        {
            //3 判断集合第一个对象的时间是否已经超过规定的时间
            if (list_final.Count > 0)
            {
                if (list_final.First().Dt < DateTime.Now.AddSeconds(seconds_add))
                {
                    //7月28日添加若发送人数超过一百人需要连续进行两次查询
                    Console.WriteLine("*******首元素满足条件*******");
                    var model = list_final.First();
                    //context.SetValue(First_Obj, model);
                    //3.2 并从redis中删除第一个对象
                   // redisListhelper.Delete(key_redis);
                    Console.WriteLine("删除首元素！！");
                    return model;
                }
                else
                {
                    //ToShow("现有Redis集合中以没有时间范围内的对象");
                    //ToShow("现Redis集合中共有:" + list_final.Count());
                    return null;
                }
            }
            //直到出现集合第一个对象时间已经不再超过规定时间则跳出
            else
            {
                //ToShow("现有Redis集合中以没有时间范围内的对象");
                //ToShow("现Redis集合中共有:" + list_final.Count());
                return null;
            }
        }
    }
}
