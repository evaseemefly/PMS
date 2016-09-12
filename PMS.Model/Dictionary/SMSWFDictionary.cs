using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    /// <summary>
    /// 工作流执行字典
    /// </summary>
    public class SMSWFDictionary
    {
        /// <summary>
        /// 工作流状态字典
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

        static SMSWFDictionary()
        {
            dResponseCode = new Dictionary<int, string>();
            //工作流结束
            dResponseCode.Add(1, "首元素符合条件");
            //工作流结束
            dResponseCode.Add(2, "首元素为空");
            //当前队列中没有规定时间内的对象
            dResponseCode.Add(3, "当前队列中没有规定时间内的对象");

            dResponseCode.Add(4, "流程挂起");
            //工作流结束
            dResponseCode.Add(6, "流程结束");
            dResponseCode.Add(44, "指定key的缓存集合为空");
            
            //出现了未知错误
            dResponseCode.Add(99, "未知原因");

        }
    }
}
