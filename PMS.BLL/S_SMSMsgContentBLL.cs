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

       new public bool Update(S_SMSMsgContent model)
        {
            //同删除
            CurrentDAL.Update(model);
            //return idal.SaveChange();
            return CurrentDBSession.SaveChanges();
        }
    }
}
