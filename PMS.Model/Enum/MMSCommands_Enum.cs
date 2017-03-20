using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Enum
{
    /// <summary>
    /// 发送彩信的Bind命令代码
    /// </summary>
    public enum MMSRequestType_Enum : int
    {
        /// <summary>
        /// 账户校验请求
        /// </summary>
        Bind = 1,

        /// <summary>
        /// 账户校验请求响应
        /// </summary>
        Bind_Resp = 801,

        /// <summary>
        /// 下发彩信请求
        /// </summary>
        MMS_Submit = 2,

        /// <summary>
        /// 下发彩信请求响应
        /// </summary>
        MMS_Submit_Resp = 802,

        /// <summary>
        /// 获取彩信上行请求
        /// </summary>
        MMS_Deliver = 3,

        /// <summary>
        /// 获取彩信上行请求响应
        /// </summary>
        MMS_Deliver_Resp = 803,

        /// <summary>
        /// 获取彩信状态请求
        /// </summary>
        MMS_Report = 4,

        /// <summary>
        /// 获取彩信状态请求响应
        /// </summary>
        MMS_Report_Resp = 804,
    }
}
