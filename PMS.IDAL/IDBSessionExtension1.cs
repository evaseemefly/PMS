

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

	  
	  #region IR_UserInfo_DepartmentInfoDAL
      IDAL.IR_UserInfo_DepartmentInfoDAL R_UserInfo_DepartmentInfoDAL { get; set; }
	  #endregion

	  
	  #region IR_UserInfo_GroupDAL
      IDAL.IR_UserInfo_GroupDAL R_UserInfo_GroupDAL { get; set; }
	  #endregion

	  
	  #region IR_UserInfo_PersonInfoDAL
      IDAL.IR_UserInfo_PersonInfoDAL R_UserInfo_PersonInfoDAL { get; set; }
	  #endregion

	  
	  #region IR_UserInfo_SMSMissionDAL
      IDAL.IR_UserInfo_SMSMissionDAL R_UserInfo_SMSMissionDAL { get; set; }
	  #endregion

	  
	  #region IRoleInfoDAL
      IDAL.IRoleInfoDAL RoleInfoDAL { get; set; }
	  #endregion

	  
	  #region IS_SMSContentDAL
      IDAL.IS_SMSContentDAL S_SMSContentDAL { get; set; }
	  #endregion

	  
	  #region IS_SMSMissionDAL
      IDAL.IS_SMSMissionDAL S_SMSMissionDAL { get; set; }
	  #endregion

	  
	  #region IS_SMSRecord_CurrentDAL
      IDAL.IS_SMSRecord_CurrentDAL S_SMSRecord_CurrentDAL { get; set; }
	  #endregion

	  
	  #region IS_SMSRecord_HistoryDAL
      IDAL.IS_SMSRecord_HistoryDAL S_SMSRecord_HistoryDAL { get; set; }
	  #endregion

	  
	  #region IUserInfoDAL
      IDAL.IUserInfoDAL UserInfoDAL { get; set; }
	  #endregion

	  }
}