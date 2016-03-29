using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
   public abstract class BaseDelBLL<T>
    {

        public abstract List<T> GetListByIds(List<int> list_ids);

        public abstract List<T> EditDelFlag(List<int> list_ids);

        /// <summary>
        /// 修改指定的ActionId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftInfos(List<int> list_ids)
        {
            List<T> list = new List<T>();
            //遍历需要查找的Action集合
            list = EditDelFlag(list_ids);
            try
            {
                //this.UpdateByList(list);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
