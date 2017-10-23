using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Redis;
using PMS.IDAL;

namespace PMS.DALRedis
{
    public class HashDAL<T> : IRedis_HashDAL<T>
    {

        protected HashRedisHelper redisHashhelper { get; set; }

        public HashDAL()
        {
            redisHashhelper = new HashRedisHelper();
        }
        /// <summary>
        /// 向指定key的hash中写入hash中存储的对象
        /// </summary>
        /// <param name="key_hash">hash在redis中存储时对应的key</param>
        /// <param name="key_hash_obj">msgid——指定key所对应的hash中保存的对象的key</param>
        /// <param name="obj">指定hash中key所对应的对象</param>
        /// <returns></returns>
        public bool Set(string key_hash, string key_hash_obj, T obj)
        {           
            return redisHashhelper.Set<T>(key_hash, key_hash_obj, obj);
        }


        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        public bool Exist(string hashId, string key)
        {
            return redisHashhelper.Exist(hashId, key);
        }

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T">写入hash表中的对象类型</typeparam>
        /// <param name="hashId">hash表的id</param>
        /// <param name="key">hash表中存储每一个对象的key</param>
        /// <param name="t">每一个对象key对应的对象实体</param>
        /// <returns></returns>
        //public bool Set(string hashId, string key, T t)
        //{
        //    return redisHashhelper.Set(hashId, key, t);
        //}
        /// <summary>
        /// 移除hash中的某值
        /// </summary>
        public bool Remove(string hashId, string key)
        {
            return redisHashhelper.Remove(hashId, key);
        }
        /// <summary>
        /// 移除整个hash
        /// </summary>
        public bool Remove(string key)
        {
            return redisHashhelper.Remove(key);
        }
        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        public T Get(string hashId, string key)
        {
            return redisHashhelper.Get<T>(hashId, key);
        }
        /// <summary>
        /// 获取整个hash的数据
        /// </summary>
        public List<T> GetAll<T>(string hashId)
        {
            return redisHashhelper.GetAll<T>(hashId);
        }
        /// <summary>
        /// 设置缓存过期
        /// </summary>
        public void SetExpire(string key, DateTime datetime)
        {
            redisHashhelper.SetExpire(key, datetime);
        }
    }
}
