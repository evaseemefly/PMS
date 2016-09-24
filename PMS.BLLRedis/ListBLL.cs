using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.IDAL;
using PMS.IBLL;
using PMS.DALRedis;
namespace PMS.BLLRedis
{
    public class ListBLL<T> : IRedis_ListBLL<T>
    {
        /// <summary>
        /// 使用spring的方式为其实例化
        /// </summary>
        protected IRedis_ListDAL<T> idal { get; set; }

        /// <summary>
        /// 无参的构造函数，为当前的idal赋值
        /// </summary>
        public ListBLL()
        {
            idal = new ListDAL<T>();
        }

        /// <summary>
        /// 向指定的list集合中添加对象
        /// </summary>
        /// <param name="key_list"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool WriteInList_Redis(string key_list, T obj)
        {
            return idal.Add(key_list, obj);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="key_list"></param>
        ///// <returns></returns>
        //public T GetFirstObjFromList(string key_list)
        //{

        //}
    }
}
