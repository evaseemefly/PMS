using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
    /// <summary>
    /// 作业对象相关信息
    /// </summary>
    public partial class ViewModel_BaseJob
    {
        public int JID { get; set; }
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string JobClassName { get; set; }
        public int JobState { get; set; }
        public string CronStr { get; set; }
        /// <summary>
        /// 会有前台视图传过来
        /// </summary>
        public System.DateTime StartRunTime { get; set; }
        public System.DateTime EndRunTime { get; set; }
        public System.DateTime NextRunTime { get; set; }
        public string Token { get; set; }
        public string AppID { get; set; }
        public string Remark { get; set; }
        public int InfoState { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public bool isDel { get; set; }
    }
}
