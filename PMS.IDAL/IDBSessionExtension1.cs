

namespace PMS.IDAL
{
 public partial  interface IDBSession
    {
	  
	  #region IActionInfoDAL
      IDAL.IActionInfoDAL ActionInfoDAL { get; set; }
	  #endregion

	  
	  #region IP_DepartmentInfoDAL
      IDAL.IP_DepartmentInfoDAL P_DepartmentInfoDAL { get; set; }
	  #endregion

	  
	  #region IP_GroupDAL
      IDAL.IP_GroupDAL P_GroupDAL { get; set; }
	  #endregion

	  
	  #region IP_PersonInfoDAL
      IDAL.IP_PersonInfoDAL P_PersonInfoDAL { get; set; }
	  #endregion

	  
	  #region IR_Department_MissionDAL
      IDAL.IR_Department_MissionDAL R_Department_MissionDAL { get; set; }
	  #endregion

	  
	  #region IR_Group_MissionDAL
      IDAL.IR_Group_MissionDAL R_Group_MissionDAL { get; set; }
	  #endregion

	  
	  #region IR_UserInfo_ActionInfoDAL
      IDAL.IR_UserInfo_ActionInfoDAL R_UserInfo_ActionInfoDAL { get; set; }
	  #endregion

	  
	  #region IRoleInfoDAL
      IDAL.IRoleInfoDAL RoleInfoDAL { get; set; }
	  #endregion

	  
	  #region IS_SMSMissionDAL
      IDAL.IS_SMSMissionDAL S_SMSMissionDAL { get; set; }
	  #endregion

	  
	  #region IUserInfoDAL
      IDAL.IUserInfoDAL UserInfoDAL { get; set; }
	  #endregion

	  }
}