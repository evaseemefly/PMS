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
        bool Set(string key_hash, string key_hash_obj, T obj);


        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        bool Exist(string hashId, string key);
        
        /// <summary>
        /// 移除hash中的某值
        /// </summary>
        bool Remove(string hashId, string key);

        /// <summary>
        /// 移除整个hash
        /// </summary>
        bool Remove(string key);

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        T Get(string hashId, string key);

        /// <summary>
        /// 获取整个hash的数据
        /// </summary>
        List<T> GetAll<T>(string hashId);

        /// <summary>
        /// 设置缓存过期
        /// </summary>
        void SetExpire(string key, DateTime datetime);
    }
}
