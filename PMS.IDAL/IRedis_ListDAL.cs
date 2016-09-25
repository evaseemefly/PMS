using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IDAL
{
    public interface IRedis_ListDAL<T>
    {
        /// <summary>
        /// 向指定key的list中写入对象
        /// </summary>
        /// <param name="key_list"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Add(string key_list, T obj);

        /// <summary>
        /// 从右侧向集合中插入对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool RPush(string key, T t, TimeSpan timespan);

        /// <summary>
        /// 获取指定key的list中包含的数据数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long Count(string key);

        /// <summary>
        /// 某个主键的队列中拉出最先进队列的数据值，先进先出原则。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string DequeueItemFromList(string key);

        /// <summary>
        /// 取出集合中的第一个对象并反序列化为指定类型的对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetFirstObj(string key);

        /// <summary>
        /// 读取当前Redis中的集合
        /// </summary>
        /// <returns></returns>
        List<T> GetLast();

        /// <summary>
        /// 取出指定key的集合中的第一个元素
        /// </summary>
        /// <param name="key"></param>
        void Delete(string key);
    }
}
