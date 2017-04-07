using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    public class BaseModel_Receive
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
    }
}
