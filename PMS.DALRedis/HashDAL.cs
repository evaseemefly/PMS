using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Redis;
using PMS.Model.QueryModel;
using PMS.IDAL;

namespace PMS.DALRedis
{
    public class HashDAL<T>:IRedis_HashDAL<T>
    {
        /// <summary>
        /// 向指定key的hash中写入hash中存储的对象
        /// </summary>
        /// <param name="key_hash">hash在redis中存储时对应的key</param>
        /// <param name="key_hash_obj">msgid——指定key所对应的hash中保存的对象的key</param>
        /// <param name="obj">指定hash中key所对应的对象</param>
        /// <returns></returns>
        public bool WriteInHash_Redis(string key_hash,string key_hash_obj, T obj)
        {
            HashRedisHelper redisHashhelper = new HashRedisHelper();
            return redisHashhelper.Set<T>(key_hash, key_hash_obj, obj);
        }
    }
}
