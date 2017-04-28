using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.SMS.Models
{
    public class ViewModel_StatisticsLast10
    {
        /// <summary>
        /// 发送人
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 短信任务名称
        /// </summary>
        public string MissionName { get; set; }

        /// <summary>
        /// 短信内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 短信内容id
        /// </summary>
        public int ContentID { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendDateTime { get; set; }

        /// <summary>
        /// 应接收人员总数
        /// </summary>
        public int TotalOfReceiveNum { get; set; }

        /// <summary>
        /// 未收到人员总数
        /// </summary>
        public int NotReceiveNum { get; set; }

        /// <summary>
        /// 类型：短信/彩信
        /// </summary>
        public bool MessageType { get; set; }
    }
}