using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Linq.Expressions;
using PMS.IBLL;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
   public partial class S_SMSMsgContentBLL : BaseBLL<S_SMSMsgContent>, IS_SMSMsgContentBLL, IBaseDelBLL,ICanBeDel
    {
        /// <summary>
        /// 根据用户id以及任务id查询与之相对应的短信模板实体对象
        /// </summary>
        /// <param name="uid">UserID</param>
        /// <param name="mid">MissionID</param>
        /// <param name="isMiddle">是否转成中间实体</param>
        /// <returns></returns>
        public S_SMSMsgContent GetModelByUserAndMission(int uid,int mid,bool isMiddle)
        {
            var model = GetListBy(t => t.UID == uid && t.SMID == mid).FirstOrDefault();
            if(isMiddle)
            {
                return model.ToMiddleModel();
            }
           else
            {
                return model;
            }
        }

        ///<summary>
        ///数据约束:判断当前用户选定任务下是否已经存在模板
        ///</summary>
        ///<param name="name"></param>
        public bool AddValidation(int userID, int SMID)
        {
            //1.获取当前用户
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID == userID, true).FirstOrDefault();
            //2.查看当前用户选定任务下是否已经存在模板
            return user.S_SMSMsgContent.ToList().Exists(u => u.SMID == SMID);
            //不验证是否重名
            //var list_model = this.GetListBy(p => p.isDel == false).ToList();
            //return list_model.Exists(p => p.MsgName.Equals(name));
        }

        ///<summary>
        ///数据约束
        ///</summary>
        ///<param name="name"></param>
        public bool EditValidation(int userID, int SMID)
        {
            //暂时和添加时的约束相同
            return this.AddValidation(userID, SMID);

        //    var list_model = this.GetListBy(p => p.isDel == false && p.TID != id).ToList();
        //    return list_model.Exists(p => p.MsgName.Equals(name));
        }

        /// <summary>
        /// 根据传入的id集合对该集合所包含的模板对象执行软删除操作
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool DelSoftTemplate(List<int> list_ids)
        {
            List<S_SMSMsgContent> list = new List<S_SMSMsgContent>();
            //对传入的id集合遍历删除包含的对象
            foreach (var item in this.GetListByIds(list_ids))
            {
                item.isDel = true;
                
                list.Add(item);
            }
            try
            {
                this.UpdateByList(list);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 还原
        /// </summary>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            return true;
        }

        /// <summary>
        /// 根据传入的id集合执行物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids, bool isCheckCanBeDel = false)
        {
            var list_model = this.GetListByIds(list_ids);
            if(list_model == null) { return false; }
            this.CurrentDAL.DelByList(list_model);
            this.CurrentDAL.SaveChange();
            return true;
        }
        public List<S_SMSMsgContent> GetListByIds(List<int> list_ids)
        {
            return GetListBy(t => list_ids.Contains(t.TID)).ToList();
        }

       new public bool Update(S_SMSMsgContent model)
        {
            //同删除
            CurrentDAL.Update(model);
            //return idal.SaveChange();
            return CurrentDBSession.SaveChanges();
        }

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            return null;
        }

        /// <summary>
        /// 分页获取已经软删除的集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<ViewModel_Recycle_Common> GetIsDelbyPageList(int pageIndex, int pageSize, ref int rowCount)
        {
            var query = base.GetPageList<DateTime>(pageIndex, pageSize, a => a.isDel == true, a => a.SubTime, true);
            rowCount = query.Count();
            return query.ToList().Select(a => a.ToRecycleModel()).ToList();
        }

        public bool CanBeDel(List<int> list_ids)
        {
            throw new NotImplementedException();
        }
    }
}
