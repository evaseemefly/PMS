using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    public class SMSQueryResultDictionary
    {
        /// <summary>
        /// 短信状态字典
        /// </summary>
        private static Dictionary<int, string> dResponseCode;

        /// <summary>
        /// 回去字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetResponseCode()
        {

            return dResponseCode;
        }

        static SMSQueryResultDictionary()
        {
            dResponseCode = new Dictionary<int, string>();
            //返回多个联系人的消息
            dResponseCode.Add(0, "含有联系人信息");
            //返回成功
            dResponseCode.Add(1, "本次查询已结束");
            dResponseCode.Add(98, "未含返回信息");
            //只返回了一个desc非成功的消息
            dResponseCode.Add(99, "未知原因");
            
        }
    }
}
