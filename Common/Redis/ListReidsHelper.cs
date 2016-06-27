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
        public bool Add<T>(T t,string id="-999")
        {
            //序列化
            var model = Common.SerializerHelper.SerializerToString(t);
            if (id != "-999")
            {
                try
                {
                    
                    redis_client.AddItemToList(id, model);
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
                    redis_client.AddItemToList(this.list_id, model);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
           
        }


        /// <summary>
        /// 读取当前Redis中的集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetLast()
        {
            var list_temp= redis_client.GetAllItemsFromList(this.list_id);
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
            redis_client.LPop(key);
        }
    }
}
