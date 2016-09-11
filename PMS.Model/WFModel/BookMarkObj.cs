using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.WFModel
{
    public class BookMarkObj<T>
    {
        public string BookMarkName { get; set; }
        /// <summary>
        /// 步骤Id
        /// </summary>
        public int StepId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public T State { get; set; }
        /// <summary>
        /// 短信唯一识别码
        /// </summary>
        public string MsgId { get; set; }
    }
}
