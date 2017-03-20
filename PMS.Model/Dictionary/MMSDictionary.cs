using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    /// <summary>
    /// 彩信状态字典
    /// </summary>
    public class MMSDictionary
    {
        private static Dictionary<int, string> dResponseCode;

        /// <summary>
        /// 返回字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetResponseCode()
        {

            return dResponseCode;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        static MMSDictionary()
        {
            dResponseCode = new Dictionary<int, string>();
            dResponseCode.Add(0, "提交成功");
            dResponseCode.Add(1, "请求消息ID不正确");
            dResponseCode.Add(2, "非法登录");
            dResponseCode.Add(3, "参数格式错误");
            dResponseCode.Add(4, "非法手机号码");
            dResponseCode.Add(5, "黑名单号码");
            dResponseCode.Add(6, "彩信标题为空");
            dResponseCode.Add(7, "彩信内容为空");
            dResponseCode.Add(8, "服务器端繁忙");
            dResponseCode.Add(9, "该账号无彩信相关产品");
            dResponseCode.Add(10, "服务端异常");
            dResponseCode.Add(11, "运营商网关发送失败");
            dResponseCode.Add(12, "提交失败");
            dResponseCode.Add(13, "彩信过大（建议小于90k）");
            dResponseCode.Add(14, "号码无匹配通道");
            dResponseCode.Add(15, "无匹配彩信业务");
            dResponseCode.Add(16, "IP鉴权失败");
            dResponseCode.Add(17, "彩信被服务端驳回");
            dResponseCode.Add(18, "可发余额不足");
            //自定义
            
            dResponseCode.Add(97, "彩信图片路径为空");
            dResponseCode.Add(98, "手机号列表为空");
            dResponseCode.Add(99, "账号或密码为空");
            dResponseCode.Add(100,"参数预检查通过");
            dResponseCode.Add(100, "未收到服务器返回信息");

        }

    }
}
