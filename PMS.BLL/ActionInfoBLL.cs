using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;

namespace PMS.BLL
{
   public partial class ActionInfoBLL: IBaseDelBLL
    {
        /// <summary>
        /// 根据id集合批量删除action
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteLogicActionInfos(List<int> list)
        {
            var actionInfoList = this.CurrentDBSession.ActionInfoDAL.GetListBy(u => list.Contains(u.ID));
            if(actionInfoList != null)
            {
                foreach (var action in actionInfoList)
                {
                    this.CurrentDBSession.ActionInfoDAL.Del(action);
                }
            }
            return this.CurrentDBSession.SaveChanges();
        }
        /// <summary>
        /// 还原
        /// </summary>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            var list_model = this.GetListByIds(list_id);
            list_model.ForEach(p => p.DelFlag = false);
            try
            {
                this.UpdateByList(list_model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids)
        {
            //1. 得到所有要删除的实体集合
            var list_model = this.GetListByIds(list_ids);
            if (list_model == null) { return false; }
            foreach (var item in list_model)
            {
                //2.清除关系表中的数据
                item.R_UserInfo_ActionInfo.Clear();
                item.RoleInfo.Clear();
            }
            try
            {
                //3. 从数据库中删除这些实体对象
                this.CurrentDAL.UpdateByList(list_model);
                this.CurrentDAL.DelByList(list_model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 从数据库中根据id集合查询返回指定的ActionInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<ActionInfo> GetListByIds(List<int> list_ids)
        {
            
          return  GetListBy(a => list_ids.Contains(a.ID)).ToList();
            
        }


        /// <summary>
        /// 修改指定的ActionId 的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftActionInfos(List<int> list_ids)
        {
            List<ActionInfo> list = new List<ActionInfo>();
            //遍历需要查找的Action集合
            foreach (var item in this.GetListByIds(list_ids))
            {
                //修改其中的删除标记
                 item.DelFlag = true;
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
        //数据验证
        public bool AddValidation(String name)
        {
            var list_model = this.GetListBy(r => r.DelFlag == false).ToList();
            return list_model.Exists(r => r.ActionInfoName.Equals(name));
        }
        //数据验证
        public bool EditValidation(int id, String name)
        {
            var list_model = this.GetListBy(r => r.ID != id && r.DelFlag == false).ToList();
            return list_model.Exists(r => r.ActionInfoName.Equals(name));
        }
    }
}
