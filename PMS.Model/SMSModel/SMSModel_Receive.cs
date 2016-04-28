using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
   public class SMSModel_Receive
    {
        /// <summary>
        /// 该批短信编号
        /// eg:"f02adaaa99c54ea58d626aac2f4ddfa8"
        /// </summary>
        public string msgid { get; set; }

        /// <summary>
        /// 该批短信提交结果
        /// eg:"0"
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// 状态描述
        /// eg:"提交成功"
        /// </summary>
        public string desc { get; set; }

        /// <summary>
        /// 如果提交的号码中含有错误（格式）号码将在此显示。
        /// eg:"12935353535,110,130123123"
        /// </summary>
        public string[] failPhones { get; set; }
    }
}
