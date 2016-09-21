using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IDAL
{
    public interface IRedis_HashDAL<T>
    {
        /// <summary>
        /// 向指定key的hash中写入hash中存储的对象
        /// </summary>
        /// <param name="key_hash">hash在redis中存储时对应的key</param>
        /// <param name="key_hash_obj">指定key所对应的hash中保存的对象的key</param>
        /// <param name="obj">指定hash中key所对应的对象</param>
        /// <returns></returns>
        bool WriteInHash_Redis(string key_hash, string key_hash_obj, T obj);
    }
}
