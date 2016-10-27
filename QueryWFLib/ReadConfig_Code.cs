using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Common;

namespace QueryWFLib
{

    public sealed class ReadConfig_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public OutArgument<string> Id_list_msgid { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        //liu
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
            //context.SetValue(SleepTime, int.Parse(ConfigHelper.GetSettingValue("sleepTime")));
            //var key_list = ConfigHelper.GetSettingValue("id_list");
            //var key_hash = ConfigHelper.GetSettingValue("id_hash");
            var key_list_msgid = ConfigHelper.GetSettingValue("id_list_msgid");

            context.SetValue(Id_list_msgid, key_list_msgid);
            //context.SetValue(Id_hash, key_hash);
            //context.SetValue(Seconds_Interval, double.Parse(ConfigHelper.GetSettingValue("seconds_add")));

        }
    }
    
}
