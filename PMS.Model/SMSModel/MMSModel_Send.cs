using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.SMSModel
{
    /// <summary>
    /// 发送对象的相关信息
    /// [1)用户账号:用父类的
    /// 2）账号密码:用父类的
    /// 3）短信编码（可填）:用父类的
    /// 4）电话（数组）:用父类的
    /// 5）短信内容:用父类的，此处为彩信内容
    /// 6）定时时间]:用父类的，彩信暂不支持定时发送，这里留作以后扩展
    /// 7）Zip包的路径
    /// 8）彩信标题
    /// </summary>
    public class MMSModel_Send:SMSModel_Send
    {
        public string zipUrl { get; set; }

        public string MMSTitle { get; set; }
    }
}
