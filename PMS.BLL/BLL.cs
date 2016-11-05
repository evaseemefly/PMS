

using PMS.Model;
using PMS.IBLL;

namespace PMS.BLL
{
   #region	ActionInfoBLL
    public partial class ActionInfoBLL : BaseBLL<ActionInfo>, IActionInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为ActionInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.ActionInfoDAL;
        }
    }
	#endregion
	   #region	J_JobInfoBLL
    public partial class J_JobInfoBLL : BaseBLL<J_JobInfo>, IJ_JobInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为J_JobInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.J_JobInfoDAL;
        }
    }
	#endregion
	   #region	N_NewsBLL
    public partial class N_NewsBLL : BaseBLL<N_News>, IN_NewsBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为N_NewsDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.N_NewsDAL;
        }
    }
	#endregion
	   #region	P_DepartmentInfoBLL
    public partial class P_DepartmentInfoBLL : BaseBLL<P_DepartmentInfo>, IP_DepartmentInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为P_DepartmentInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.P_DepartmentInfoDAL;
        }
    }
	#endregion
	   #region	P_GroupBLL
    public partial class P_GroupBLL : BaseBLL<P_Group>, IP_GroupBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为P_GroupDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.P_GroupDAL;
        }
    }
	#endregion
	   #region	P_PersonInfoBLL
    public partial class P_PersonInfoBLL : BaseBLL<P_PersonInfo>, IP_PersonInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为P_PersonInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.P_PersonInfoDAL;
        }
    }
	#endregion
	   #region	Quartz_JobBLL
    public partial class Quartz_JobBLL : BaseBLL<Quartz_Job>, IQuartz_JobBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为Quartz_JobDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.Quartz_JobDAL;
        }
    }
	#endregion
	   #region	R_Department_MissionBLL
    public partial class R_Department_MissionBLL : BaseBLL<R_Department_Mission>, IR_Department_MissionBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_Department_MissionDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_Department_MissionDAL;
        }
    }
	#endregion
	   #region	R_Group_MissionBLL
    public partial class R_Group_MissionBLL : BaseBLL<R_Group_Mission>, IR_Group_MissionBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_Group_MissionDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_Group_MissionDAL;
        }
    }
	#endregion
	   #region	R_UserInfo_ActionInfoBLL
    public partial class R_UserInfo_ActionInfoBLL : BaseBLL<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_UserInfo_ActionInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_UserInfo_ActionInfoDAL;
        }
    }
	#endregion
	   #region	R_UserInfo_DepartmentInfoBLL
    public partial class R_UserInfo_DepartmentInfoBLL : BaseBLL<R_UserInfo_DepartmentInfo>, IR_UserInfo_DepartmentInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_UserInfo_DepartmentInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_UserInfo_DepartmentInfoDAL;
        }
    }
	#endregion
	   #region	R_UserInfo_GroupBLL
    public partial class R_UserInfo_GroupBLL : BaseBLL<R_UserInfo_Group>, IR_UserInfo_GroupBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_UserInfo_GroupDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_UserInfo_GroupDAL;
        }
    }
	#endregion
	   #region	R_UserInfo_NewsBLL
    public partial class R_UserInfo_NewsBLL : BaseBLL<R_UserInfo_News>, IR_UserInfo_NewsBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_UserInfo_NewsDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_UserInfo_NewsDAL;
        }
    }
	#endregion
	   #region	R_UserInfo_PersonInfoBLL
    public partial class R_UserInfo_PersonInfoBLL : BaseBLL<R_UserInfo_PersonInfo>, IR_UserInfo_PersonInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_UserInfo_PersonInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_UserInfo_PersonInfoDAL;
        }
    }
	#endregion
	   #region	R_UserInfo_SMSMissionBLL
    public partial class R_UserInfo_SMSMissionBLL : BaseBLL<R_UserInfo_SMSMission>, IR_UserInfo_SMSMissionBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为R_UserInfo_SMSMissionDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.R_UserInfo_SMSMissionDAL;
        }
    }
	#endregion
	   #region	RoleInfoBLL
    public partial class RoleInfoBLL : BaseBLL<RoleInfo>, IRoleInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为RoleInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.RoleInfoDAL;
        }
    }
	#endregion
	   #region	S_SMSContentBLL
    public partial class S_SMSContentBLL : BaseBLL<S_SMSContent>, IS_SMSContentBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为S_SMSContentDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.S_SMSContentDAL;
        }
    }
	#endregion
	   #region	S_SMSMissionBLL
    public partial class S_SMSMissionBLL : BaseBLL<S_SMSMission>, IS_SMSMissionBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为S_SMSMissionDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.S_SMSMissionDAL;
        }
    }
	#endregion
	   #region	S_SMSMsgContentBLL
    public partial class S_SMSMsgContentBLL : BaseBLL<S_SMSMsgContent>, IS_SMSMsgContentBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为S_SMSMsgContentDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.S_SMSMsgContentDAL;
        }
    }
	#endregion
	   #region	S_SMSRecord_CurrentBLL
    public partial class S_SMSRecord_CurrentBLL : BaseBLL<S_SMSRecord_Current>, IS_SMSRecord_CurrentBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为S_SMSRecord_CurrentDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.S_SMSRecord_CurrentDAL;
        }
    }
	#endregion
	   #region	S_SMSRecord_HistoryBLL
    public partial class S_SMSRecord_HistoryBLL : BaseBLL<S_SMSRecord_History>, IS_SMSRecord_HistoryBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为S_SMSRecord_HistoryDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.S_SMSRecord_HistoryDAL;
        }
    }
	#endregion
	   #region	S_SMSTypeBLL
    public partial class S_SMSTypeBLL : BaseBLL<S_SMSType>, IS_SMSTypeBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为S_SMSTypeDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.S_SMSTypeDAL;
        }
    }
	#endregion
	   #region	UserInfoBLL
    public partial class UserInfoBLL : BaseBLL<UserInfo>, IUserInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为UserInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.UserInfoDAL;
        }
    }
	#endregion
	   #region	WF_Query_InstanceBLL
    public partial class WF_Query_InstanceBLL : BaseBLL<WF_Query_Instance>, IWF_Query_InstanceBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为WF_Query_InstanceDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.WF_Query_InstanceDAL;
        }
    }
	#endregion
	   #region	WF_Query_StepInfoBLL
    public partial class WF_Query_StepInfoBLL : BaseBLL<WF_Query_StepInfo>, IWF_Query_StepInfoBLL
    {	

		/// <summary>
        /// 为当前的DAL对象赋值，赋值为WF_Query_StepInfoDAL
        /// </summary>
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.WF_Query_StepInfoDAL;
        }
    }
	#endregion
	}