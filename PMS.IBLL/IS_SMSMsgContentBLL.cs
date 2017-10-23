﻿using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
   public partial interface IS_SMSMsgContentBLL:IBaseDelBLL
    {
        /// <summary>
        /// 根据用户id以及任务id查询与之相对应的短信模板实体对象
        /// </summary>
        /// <param name="uid">UserID</param>
        /// <param name="mid">MissionID</param>
        /// <param name="isMiddle">是否转成中间实体</param>
        /// <returns></returns>
        S_SMSMsgContent GetModelByUserAndMission(int uid, int mid, bool isMiddle);

        /// <summary>
        /// 根据传入的id集合对该集合所包含的模板对象执行软删除操作
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftTemplate(List<int> list_ids);



        ///<summary>
        ///数据验证
        ///</summary>
        ///<param name="name"></param>
        bool AddValidation(int userID,int SMID);

        ///<summary>
        ///数据验证
        ///</summary>
        ///<param name="name"></param>
        ///<returns></returns>
        bool EditValidation(int userID, int SMID,int TID);
    }
}
