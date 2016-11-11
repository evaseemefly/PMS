using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    /// <summary>
    /// 发送对象的相关信息
    /// [1)用户账号
    /// 2）账号密码
    /// 3）短信编码（可填）
    /// 4）电话（数组）
    /// 5）短信内容
    /// 6）定时时间]
    /// </summary>
    public class SMSModel_Send
    {
        /// <summary>
        /// 
        /// </summary>
        private string temp { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string account { get; set; }

        /// <summary>
        /// 账号密码，需采用MD5加密(32位小写)
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 该批短信编号(32位UUID)，需保证唯一，必填
        /// </summary>
        public string msgid { get; set; }

        /// <summary>
        /// 接收手机号码，多个手机号码用英文逗号分隔，最多500个，必填
        /// </summary>
        public string[] phones { get; set; }

        /// <summary>
        /// 短信内容，最多350个汉字，必填；
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 短信签名，该签名需要提前报备，生效后方可使用，不可修改，必填，示例如：【新华社】；
        /// </summary>
        public string sign { get { return "【国家海洋预报台】"; } }

        /// <summary>
        /// 短信签名对应子码(供应商提供)+自定义扩展子码(选填)，必须是数字，选填，未填使用签名对应子码；
        /// </summary>
        public string subcode { get; set; }

        /// <summary>
        /// 定时发送时间，格式yyyyMMddHHmm，为空或早于当前时间则立即发送；
        /// </summary>
        public DateTime sendtime { get; set; }

    }
}
