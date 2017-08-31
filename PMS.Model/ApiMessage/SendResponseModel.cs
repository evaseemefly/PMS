using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ApiMessage
{
    /// <summary>
    /// 执行发送api后返回给客户端的响应结果，可添加其他属性
    /// </summary>
    public class SendResponseModel
    {
        public string ResultCode { get; set; }

        public DateTime ResponseDate { get; set; }


    }
}
