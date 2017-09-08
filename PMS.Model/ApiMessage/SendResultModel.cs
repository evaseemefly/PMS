using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ApiMessage
{
    /// <summary>
    /// 发送api需要提交的内容
    /// </summary>
    public class SendResultModel
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 指定账号密码-md5
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 短信任务名称数组（使用，拼接为一个string）
        /// </summary>
        public string SMSMissionNames { get; set; }

        /// <summary>
        /// 短信群组名称数组（使用，拼接为一个string）
        /// </summary>
        public string GroupNames { get; set; } 

        /// <summary>
        /// 短信内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 短信临时电话（暂不使用，拼接为一个string）
        /// </summary>
        public string TmpPhoneNum { get; set; }
    }
}
