using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SerializerHelper
    {
        /// <summary>
        /// 对象序列化——使用Newtonsoft.Json的方式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializerToString(object obj)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            /*jsSettings.ReferenceLoopHandling:
                Gets or sets how reference loops (e.g. a class referencing itself) is handled.
                获取或设置如何处理引用循环（例如引用本身的类）。
                Ignore
                Ignore loop references and do not serialize.
                忽略循环引用和不序列化。
                 Serialize
                序列化循环引用。
             */
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, jsSettings);

            //return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 根据泛型参数反序列化字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeSerializerToObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
