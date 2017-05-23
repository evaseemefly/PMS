using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.Enum;
using PMS.Model.ViewModel;
using PMS.Model;

namespace PersonImporting.BLL
{
    class MissionBLL
    {
        protected PMS.IBLL.IS_SMSMissionBLL missionBLL;

        public MissionBLL()
        {
            missionBLL = new PMS.BLL.S_SMSMissionBLL();
        }

        public ExistEnum CheckMissionExist(string missionName, int sort)
        {
            //根据群组名称获取群组集合
            var missionList = missionBLL.GetListBy(g => g.SMSMissionName == missionName).ToList();
            ExistEnum enum_exist = ExistEnum.isExist;
            //判断集合是否为空
            if (missionList.Count() == 0)
            {
                //需要创建
                enum_exist = missionBLL.Create(new PMS.Model.S_SMSMission()
                {
                    SMSMissionName = missionName,
                    Sort = sort,
                    isDel = false,
                    SubTime = DateTime.Now,
                    ModifiedOnTime = DateTime.Now,
                    isMMS = false
                }) == true ? ExistEnum.ok : ExistEnum.error;
            }
            return enum_exist;
        }
        /// <summary>
        /// 建立任务-群组关系
        /// </summary>
        /// <param name="smid"></param>
        /// <param name="gids"></param>
        /// <param name="ismms"></param>
        /// <returns></returns>
        public bool CreatGroupRelationship(int smid, List<ViewModel_isPass_Group> gids, bool ismms)
        {
            bool isOk = false;
            isOk = missionBLL.SetSMSMission4Group(smid,gids,ismms);
            return isOk;
        }
        /// <summary>
        /// 建立任务-部门关系
        /// </summary>
        /// <param name="smid"></param>
        /// <param name="dids"></param>
        /// <param name="ismms"></param>
        /// <returns></returns>
        public bool CreatDepartmentRelationship(int smid, List<ViewModel_isPass_Department> dids, bool ismms)
        {
            bool isOk = false;
            isOk = missionBLL.SetSMSMission4Department(smid, dids, ismms);
            return isOk;
        }
        /// <summary>
        /// 获取任务ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetMissionId(string name)
        {
            return missionBLL.GetListBy(p => p.SMSMissionName.Equals(name)).FirstOrDefault().SMID;
        }

        /// <summary>
        /// 通过名称得到任务对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public S_SMSMission getMissionByName(string name)
        {
            //根据任务名称获取任务集合
            return missionBLL.GetListBy(g => g.SMSMissionName.Equals(name)).FirstOrDefault();
        }
        public List<S_SMSMission> getMissionList()
        {
            //获取任务集合
            
            return missionBLL.GetAllList().ToList();
        }

    }
}
