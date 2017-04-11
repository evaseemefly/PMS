using PMS.IModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMS.Model.CombineModel
{
    public class BaseMessage_Model: ISendAndMessage_Model
    {
        /// <summary>
        /// 含提交的短信的相关内容及作业相关信息
        /// </summary>
        public ViewModel.ViewModel_Message Model_Message { get; set; }
    }
}
