using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Encryption
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encryption(string str)
        {
            //1 创建MD5的实现类
            MD5 md5 = MD5.Create();
            //2 将字符串编码为一个字节序列
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            //3 计算哈希值
            byte[] md5Buffer = md5.ComputeHash(buffer);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in md5Buffer)
            {
                sb.Append(b.ToString("x2"));

            }
            md5.Clear();
            return sb.ToString();
        }

        //public static string SHA256Encryption(string str)
        //{
        //    SHA256Managed sha256 = new SHA256Managed();

        //}
        /// <summary>
        /// 图片转base64函数
        /// </summary>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        public static string ToBase64(byte[] binaryData)
        {
            try
            {
                string buffer1 = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
                return buffer1;
            }
            catch (System.ArgumentNullException exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
