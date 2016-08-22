using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    public class SMSQueryDictionary
    {

        /// <summary>
        /// 短信查询报告错误码字典
        /// </summary>
        private static Dictionary<int, string> dQueryResponseCode;

        /// <summary>
        /// 回去字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetResponseCode()
        {

            return dQueryResponseCode;
        }

        static SMSQueryDictionary()
        {
            dQueryResponseCode = new Dictionary<int, string>();
            dQueryResponseCode.Add(0, "成功");
            dQueryResponseCode.Add(2, "发送失败: 运营商网关失败");
            dQueryResponseCode.Add(4, "发送失败: 手机号码无效");
            dQueryResponseCode.Add(5, "发送失败: 签名不合法");
            dQueryResponseCode.Add(6, "发送失败: 短信内容超过最大限制");
            dQueryResponseCode.Add(9, "发送失败: 请求来源地址无效");
            dQueryResponseCode.Add(10, "发送失败: 内容包涵敏感词");
            dQueryResponseCode.Add(11, "发送失败: 余额不足");
            dQueryResponseCode.Add(12, "发送失败: 购买产品或订购还未生效或产品已经暂停使用");
            dQueryResponseCode.Add(13, "发送失败: 账号被禁用或禁发");
            dQueryResponseCode.Add(14, "发送失败: 不支持该运营商");
            dQueryResponseCode.Add(16, "发送失败: 发送号码数没有达到该产品的最小发送数");
            dQueryResponseCode.Add(19, "发送失败: 黑名单号码");
            dQueryResponseCode.Add(20, "发送失败: 该模板ID已被禁用");
            dQueryResponseCode.Add(21, "发送失败: 非法模板ID");
            dQueryResponseCode.Add(22, "发送失败: 不支持的MSGFMT");
            dQueryResponseCode.Add(23, "发送失败: 子号码无效");
            dQueryResponseCode.Add(24, "发送失败: 内容为空");
            dQueryResponseCode.Add(25, "发送失败: 号码为空");
            dQueryResponseCode.Add(26, "发送失败: 单个号码相同内容限制");
            dQueryResponseCode.Add(27, "发送失败: 单个号码次数限制");
            dQueryResponseCode.Add(96, "发送失败: 处理失败");
            dQueryResponseCode.Add(97, "发送失败: 接入方式错误");
            dQueryResponseCode.Add(98, "发送失败: 系统繁忙");
            dQueryResponseCode.Add(99, "发送失败: 消息格式错误");
        }
    }
}
