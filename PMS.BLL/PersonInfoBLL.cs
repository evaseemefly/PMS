using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using System.Linq.Expressions;

namespace PMS.BLL
{
    public partial class P_PersonInfoBLL : BaseBLL<P_PersonInfo>, IP_PersonInfoBLL
    {
        /// <summary>
        /// 逻辑删除（物理删除）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteLogicPersonInfos(List<int> list)
        {
            var PersonInfoList = this.CurrentDBSession.P_PersonInfoDAL.GetListBy(u => list.Contains(u.PID));
            if(PersonInfoList != null)
            {
                foreach(var person in PersonInfoList)
                {
                    this.CurrentDBSession.P_PersonInfoDAL.Del(person);
                }
            }
            return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftPersonInfos(List<int> list)
        {

                List<P_PersonInfo> list_person = new List<P_PersonInfo>();
                foreach (var person in this.GetListByIds(list))
                {
                    person.isDel = true;
                    list_person.Add(person);
                }
            try
            {
                this.UpdateByList(list_person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的PersonInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<P_PersonInfo> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.PID)).ToList();

        }
    }
}
