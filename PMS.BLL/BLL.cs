

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
	}