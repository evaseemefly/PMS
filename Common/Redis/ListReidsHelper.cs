using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Redis
{
    public class ListReidsHelper<T>:BaseRedisHelper
    {
        private string list_id;
        public ListReidsHelper() : base() { }

        public ListReidsHelper(string list_id) : base()
        {
            this.list_id = list_id;
        }
        public bool Add<T> (T t,string id="-999")
        {
            //序列化
            var model = Common.SerializerHelper.SerializerToString(t);
            if (id != "-999")
            {
                try
                {

                    redis_Client.AddItemToList(id, model);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    redis_Client.AddItemToList(this.list_id, model);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
           
        }

        /// <summary>
        /// 从右侧向集合中插入对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool RPush<T>(string key,T t,TimeSpan timespan)
        {
            //序列化
            var model = Common.SerializerHelper.SerializerToString(t);
            try
            {

                redis_Client.EnqueueItemOnList(key, model);
                //redis_client.ExpireEntryIn(key, timespan);
                //redis_client.Expire(key, timespan);
                //redis_client.ExpireEntryAt
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        /// <summary>
        /// 获取指定key的list中包含的数据数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Count(string key)
        {
            return redis_Client.GetListCount(key);
        }

        /// <summary>
        /// 某个主键的队列中拉出最先进队列的数据值，先进先出原则。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string DequeueItemFromList(string key)
        {
           return redis_Client.DequeueItemFromList(key);

        }

        /// <summary>
        /// 取出集合中的第一个对象并反序列化为指定类型的对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetFirstObj(string key)
        {
            //9月23日修改
            //1 判断当前key对应的集合中是否长度不为0
            if (this.Count(key) == 0)
            {
                return default(T);
            }
            //若集合中有值采取出该集合中第一个对象，并进行反序列化
            else
            {
                return Common.SerializerHelper.DeSerializerToObject<T>(redis_Client.GetItemFromList(key, 0));
            }
           
        }
        /// <summary>
        /// 读取当前Redis中的集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetLast()
        {
            var list_temp= redis_Client.GetAllItemsFromList(this.list_id);
            //反序列化
            List<T> list_final = new List<T>();
            list_temp.ForEach(p => list_final.Add(Common.SerializerHelper.DeSerializerToObject<T>(p)));
            return list_final;
        }

        /// <summary>
        /// 取出指定key的集合中的第一个元素
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            //redis_Client.pop
            //redis_Client.LPop(key);
        }
    }
}
