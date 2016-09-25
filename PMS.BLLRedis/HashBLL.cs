using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.IBLL;
using PMS.IDAL;
using PMS.DALRedis;

namespace PMS.BLLRedis
{
    public class HashBLL<T> : IRedis_HashBLL<T>
    {
        protected IRedis_HashDAL<T> idal { get; set; }

        /// <summary>
        /// 无参的构造函数，为当前的idal赋值
        /// </summary>
        public HashBLL()
        {
            idal = new HashDAL<T>();
        }

        /// <summary>
        /// 向指定的hash中写入指定集合
        /// </summary>
        /// <param name="key_hash"></param>
        /// <param name="key_hash_obj"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool WriteInHash_Redis(string key_hash, string key_hash_obj, T obj)
        {
           return idal.Set(key_hash, key_hash_obj, obj);
        }
    }
}
