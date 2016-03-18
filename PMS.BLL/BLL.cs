

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