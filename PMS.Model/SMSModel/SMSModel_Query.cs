using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    /// <summary>
    /// 查询发送结果的数据包的实体类
    /// </summary>
    public class SMSModel_Query:PMS.IModel.SMSModel.IQuerySign
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string account {get; set;}
        
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 下行短信编号，选填
        /// </summary>
        public string smsId { get; set; }

        /// <summary>
        /// 查询命令代码
        /// </summary>
        public string cmdid { get; set; }
        //public string phoneNums { get; set; }
    }
}
