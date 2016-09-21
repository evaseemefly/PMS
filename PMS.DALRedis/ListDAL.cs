using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Redis;
using PMS.Model.QueryModel;
using PMS.IDAL;

namespace PMS.DALRedis
{
    public class ListDAL<T>:IRedis_ListDAL<T>
    {
        /// <summary>
        /// 向指定key的list中写入对象
        /// </summary>
        /// <param name="key_list"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool WriteInList_Redis(string key_list, T obj)
        {
            ListReidsHelper<T> redisListhelper = new ListReidsHelper<T>(key_list);
            return redisListhelper.Add(obj);
        }
    }
}
