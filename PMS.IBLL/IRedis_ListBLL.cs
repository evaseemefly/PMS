using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public interface IRedis_ListBLL<T>
    {
        /// <summary>
        /// 向指定key的list中写入对象
        /// </summary>
        /// <param name="key_list"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool WriteInList_Redis(string key_list, T obj);
    }
}
