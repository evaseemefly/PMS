using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Common;

namespace WFTest
{

    public sealed class ReadAppConfig_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        /// <summary>
        /// 线程休眠
        /// </summary>
        public OutArgument<int> SleepTime { get; set; }

        //public OutArgument temp { get; set; }

        /// <summary>
        /// 在Redis中存储的集合的key
        /// </summary>
        public OutArgument<string> Id_list { get; set; }

        public OutArgument<string> Id_list_msgid { get; set; }

        public OutArgument<string> Id_hash { get; set; }

        /// <summary>
        /// 需要判断的时间间隔
        /// </summary>
        public OutArgument<double> Seconds_Interval { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
            ReadAppConfig(context);
        }

        /// <summary>
        /// 读取配置文件中以上配置节的值
        /// </summary>
        private void ReadAppConfig(CodeActivityContext context)
        {

            //为三个输出变量赋值
            context.SetValue(SleepTime, int.Parse(ConfigHelper.GetSettingValue("sleepTime")));
            var key_list = ConfigHelper.GetSettingValue("id_list");
            var key_hash = ConfigHelper.GetSettingValue("id_hash");
            var key_list_msgid = ConfigHelper.GetSettingValue("id_list_msgid");

            context.SetValue(Id_list, key_list);
            context.SetValue(Id_list_msgid, key_list_msgid);
            context.SetValue(Id_hash, key_hash);
            context.SetValue(Seconds_Interval, double.Parse(ConfigHelper.GetSettingValue("seconds_add")));

            //context.SetValue<string>(temp, "123");          

        }

    }
}
