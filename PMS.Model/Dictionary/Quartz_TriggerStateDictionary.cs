using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    public class Quartz_TriggerStateDictionary
    {
        /// <summary>
        /// 短信状态字典
        /// </summary>
        private static Dictionary<string, int> dResponseCode;

        /// <summary>
        /// 回去字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, int> GetResponseCode()
        {

            return dResponseCode;
        }

        static Quartz_TriggerStateDictionary()
        {
            dResponseCode = new Dictionary<string, int>();
            dResponseCode.Add("WAITING",2 );
            dResponseCode.Add("COMPLETE", 1); 
            dResponseCode.Add("null", 99);
        }
    }

}
