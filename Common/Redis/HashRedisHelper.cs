using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Redis
{
    public class HashRedisHelper : BaseRedisHelper
    {
        public HashRedisHelper() : base()
        {
            //redisClient = GetClient();
        }
        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        public bool Exist(string hashId, string key)
        {
            return redis_Client.HashContainsEntry(hashId, key);
        }

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T">写入hash表中的对象类型</typeparam>
        /// <param name="hashId">hash表的id</param>
        /// <param name="key">hash表中存储每一个对象的key</param>
        /// <param name="t">每一个对象key对应的对象实体</param>
        /// <returns></returns>
        public bool Set<T>(string hashId, string key, T t)
        {
            //if(typeof(T) is byte[])
            var value = SerializerHelper.SerializerToString(t);
            


            return redis_Client.SetEntryInHash(hashId, key, value);
        }
        /// <summary>
        /// 移除hash中的某值
        /// </summary>
        public bool Remove(string hashId, string key)
        {
            return redis_Client.RemoveEntryFromHash(hashId, key);
        }
        /// <summary>
        /// 移除整个hash
        /// </summary>
        public bool Remove(string key)
        {
            return redis_Client.Remove(key);
        }
        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        public T Get<T>(string hashId, string key)
        {
            string value = redis_Client.GetValueFromHash(hashId, key);
            return SerializerHelper.DeSerializerToObject<T>(value);
        }
        /// <summary>
        /// 获取整个hash的数据
        /// </summary>
        public List<T> GetAll<T>(string hashId)
        {
            var result = new List<T>();
            var list = redis_Client.GetHashValues(hashId);
            if (list != null && list.Count > 0)
            {
                list.ForEach(x =>
                {
                    var value = SerializerHelper.DeSerializerToObject<T>(x);
                    result.Add(value);
                });
            }
            return result;
        }
        /// <summary>
        /// 设置缓存过期
        /// </summary>
        public void SetExpire(string key, DateTime datetime)
        {
            redis_Client.ExpireEntryAt(key, datetime);
        }
    }
}

