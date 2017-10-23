using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
        public class SMSUserDictionary
        {

            /// <summary>
            /// 查询用户字典
            /// </summary>
            private static Dictionary<int, string> dSMSUserCode;

        /// <summary>
        /// 查询用户字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetResponseCode()
            {

                return dSMSUserCode;
            }

            static SMSUserDictionary()
            {
                dSMSUserCode = new Dictionary<int, string>();
                dSMSUserCode.Add(0, "全部用户");
                dSMSUserCode.Add(1, "当前用户");
            }
        }
    }

