using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.BLL
{
    public partial class S_SMSMissionBLL
    {
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的S_SMSMission集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<S_SMSMission> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.SMID)).ToList();

        }

        /// <summary>
        /// 修改指定的S_SMSMission 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftRoleInfos(List<int> list_ids)
        {
            List<S_SMSMission> list = new List<S_SMSMission>();
            //遍历需要查找的Action集合
            foreach (var item in this.GetListByIds(list_ids))
            {
                //修改其中的删除标记
                item.isDel = true;
                //并添加至新创建的集合中
                list.Add(item);
            }
            try
            {
                this.UpdateByList(list);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
