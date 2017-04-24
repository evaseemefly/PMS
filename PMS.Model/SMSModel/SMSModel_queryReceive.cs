using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    public class SMSModel_QueryReceive:IModel.SMSModel.IQueryReceive
    {
        /// <summary>
        /// 短信唯一识别码
        /// </summary>
        public string msgId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string phoneNumber { get; set; }
        /// <summary>
        /// 短信发送结果
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 当status为1时，以desc的错误码为准
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 当status为2时，表示运营商网关返回的原始值；
        /// </summary>
        public string wgcode { get; set; }
        /// <summary>
        /// 状态报告接收时间格式为yyyy-MM-ddHH:mm:ss
        /// </summary>
        public string time { get; set; } 
        /// <summary>
        /// 长短信条数
        /// </summary>
        public int smsCount { get; set; }

        // 封装进此对象的smsIndex均为1，此属性不需要
        //public int smsIndex { get; set; }
    }
}
