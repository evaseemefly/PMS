

namespace PMS.IDAL
{
 public partial  interface IDBSession
    {
	  
	  #region IActionInfoDAL
      IDAL.IActionInfoDAL ActionInfoDAL { get; set; }
	  #endregion

	  
	  #region IR_UserInfo_ActionInfoDAL
      IDAL.IR_UserInfo_ActionInfoDAL R_UserInfo_ActionInfoDAL { get; set; }
	  #endregion

	  
	  #region IRoleInfoDAL
      IDAL.IRoleInfoDAL RoleInfoDAL { get; set; }
	  #endregion

	  
	  #region IUserInfoDAL
      IDAL.IUserInfoDAL UserInfoDAL { get; set; }
	  #endregion

	  }
}