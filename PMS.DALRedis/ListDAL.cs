using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Redis;
using PMS.IDAL;

namespace PMS.DALRedis
{
    public class ListDAL<T> : IRedis_ListDAL<T>
    {
        protected ListReidsHelper<T> redisListhelper { get; set; }

        public ListDAL()
        {
            redisListhelper = new ListReidsHelper<T>();
        }

        /// <summary>
        /// 向指定key的list中写入对象
        /// </summary>
        /// <param name="key_list"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(string key_list, T obj)
        {            
            return redisListhelper.Add(obj,key_list);
        }        

        /// <summary>
        /// 从右侧向集合中插入对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool RPush(string key, T t, TimeSpan timespan)
        {
           return redisListhelper.RPush(key, t, timespan);
        }

        /// <summary>
        /// 获取指定key的list中包含的数据数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Count(string key)
        {
            return redisListhelper.Count(key);
        }

        /// <summary>
        /// 某个主键的队列中拉出最先进队列的数据值，先进先出原则。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string DequeueItemFromList(string key)
        {
            return redisListhelper.DequeueItemFromList(key);

        }

        /// <summary>
        /// 取出集合中的第一个对象并反序列化为指定类型的对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetFirstObj(string key)
        {
            return GetFirstObj(key);
        }
        /// <summary>
        /// 读取当前Redis中的集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetLast()
        {
            return redisListhelper.GetLast();
        }

        /// <summary>
        /// 取出指定key的集合中的第一个元素
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            redisListhelper.Delete(key);
        }
    }
}
