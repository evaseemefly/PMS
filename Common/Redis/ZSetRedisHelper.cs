using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Redis
{
    public class ZSetRedisHelper:BaseRedisHelper
    {
        public ZSetRedisHelper() : base() { }
        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        public int Exist<T>( string key)
        {
            return 0;
        }
        /// <summary>
        /// 存储对象至ZSet中
        /// </summary>
        public bool Add<T>(string key, T t)
        {
            var value = SerializerHelper.SerializerToString(t);
            return redis_Client.AddItemToSortedSet(key, value);
        }

        /// <summary>
        /// 将对象经过序列化存储至有序集合中，并含权重
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool Add<T>(string key,T t,double score)
        {
            var value = SerializerHelper.SerializerToString(t);
            return redis_Client.AddItemToSortedSet(key, value, score);
        }

        /// <summary>
        /// 将value写入ZSet中，不含权重
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(string key,string value)
        {
            return redis_Client.AddItemToSortedSet(key, value);
        }

        /// <summary>
        /// 将value写入ZSet中，不含权重
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool Add(string key,string value,double score)
        {
            return redis_Client.AddItemToSortedSet(key, value, score);
        }
        /// <summary>
        /// 移除ZSet中的某值
        /// </summary>
        public bool DeleteValue(string key,string value)
        {
            return redis_Client.RemoveItemFromSortedSet(key, value);
        }
        /// <summary>
        /// 移除某个key对应的对象
        /// </summary>
        public bool Delete(string key)
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

        public string Get(string key)
        {
            return null;
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
