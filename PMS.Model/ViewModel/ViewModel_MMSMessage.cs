using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
    /// <summary>
    /// 1 提交的短信的相关信息[
    /// 1）联系人id:用父类的
    /// 2）群组id:用父类的
    /// 3）电话号码:用父类的
    /// 4）任务id:用父类的
    /// 5）短信内容:用父类的
    /// 6）Zip包路径：在服务端本地的zip包路径
    /// 7）彩信标题:传入的标题
    /// 2 作业相关信息
    /// </summary>
    public class ViewModel_MMSMessage: ViewModel_Message
    {
        /// <summary>
        /// 6）Zip包路径：在服务端本地的zip包路径
        /// 3月19日添加 by QY
        /// </summary>
        public string ZipUrl { get; set; }

        /// <summary>
        /// 7）彩信标题:传入的标题
        /// 3月19日添加 by QY
        /// </summary>
        public string MMSTitle { get; set; }
    }
}
