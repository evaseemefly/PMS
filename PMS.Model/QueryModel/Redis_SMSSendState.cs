using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.QueryModel
{
    /// <summary>
    /// Redis中当第一次查询结束后向Redis中写入的对象
    /// 此对象包含msgId以及短信发送时间和查询状态
    /// </summary>
    public class Redis_SMSSendState
    {
        /// <summary>
        /// 查询短信唯一识别码
        /// </summary>
        public string msgid { get; set; }

        /// <summary>
        /// 短信创建时间
        /// 超过72小时后会删除（不会再查询
        /// </summary>
        public DateTime Dt { get; set; }

        /// <summary>
        /// 查询状态（每次执行一次查询工作流后会重新更新其查询状态）
        /// </summary>
        public int State { get; set; }



    }
}
