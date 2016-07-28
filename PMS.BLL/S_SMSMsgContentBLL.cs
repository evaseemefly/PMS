using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Linq.Expressions;
using PMS.IBLL;

namespace PMS.BLL
{
   public partial class S_SMSMsgContentBLL : BaseBLL<S_SMSMsgContent>, IS_SMSMsgContentBLL
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
        ///数据约束
        ///</summary>
        ///<param name="name"></param>
        public bool AddValidation(string name)
        {
            var list_model = this.GetListBy(p => p.isDel == false).ToList();
            return list_model.Exists(p => p.MsgName.Equals(name));
        }

        ///<summary>
        ///数据约束
        ///</summary>
        ///<param name="name"></param>
        public bool EditValidation(int id, string name)
        {
            var list_model = this.GetListBy(p => p.isDel == false && p.TID != id).ToList();
            return list_model.Exists(p => p.MsgName.Equals(name));
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


    }
}
