using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Message
{
    /// <summary>
    /// 回传的基类消息
    /// </summary>
    public class BaseResponse:IBaseResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
