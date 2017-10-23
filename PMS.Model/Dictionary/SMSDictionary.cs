﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    /// <summary>
    /// 短信状态字典
    /// </summary>
   public class SMSDictionary
    {
        /// <summary>
        /// 短信状态字典
        /// </summary>
        private static Dictionary<int, string> dResponseCode ;

        /// <summary>
        /// 回去字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetResponseCode()
        {
           
            return dResponseCode;
        }

        static SMSDictionary()
        {
            dResponseCode = new Dictionary<int, string>();
            //dResponseCode[0] = "123";
            dResponseCode.Add(0, "提交成功");
            dResponseCode.Add(1, "账号无效");
            dResponseCode.Add(2, "密码错误");
            dResponseCode.Add(3, "msgid太长，不得超过32位");
            dResponseCode.Add(5, "手机号码个数超过最大限制(500个)");
            dResponseCode.Add(6, "短信内容超过最大限制(350字)");
            dResponseCode.Add(7, "扩展子号码无效");
            dResponseCode.Add(8, "定时时间格式错误");
            dResponseCode.Add(14, "手机号码为空");
            dResponseCode.Add(19, "用户被禁发或禁用");
            dResponseCode.Add(20, "ip鉴权失败");
            dResponseCode.Add(21, "短信内容为空");
            dResponseCode.Add(22, "数据包大小不匹配");
            dResponseCode.Add(98, "系统正忙");
            dResponseCode.Add(99, "消息格式错误");
            dResponseCode.Add(100, "发送成功");
            dResponseCode.Add(101, "参数不全");
        }
    }
}
