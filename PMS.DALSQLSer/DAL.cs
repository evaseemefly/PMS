
using PMS.Model;
using PMS.IDAL;

namespace PMS.DALSQLSer
{
	#region ActionInfoDAL   
	//ActionInfo数据访问层
	public class ActionInfoDAL:BaseDAL<ActionInfo>,IActionInfoDAL
    {
    }
	#endregion

		#region P_DepartmentInfoDAL   
	//P_DepartmentInfo数据访问层
	public class P_DepartmentInfoDAL:BaseDAL<P_DepartmentInfo>,IP_DepartmentInfoDAL
    {
    }
	#endregion

		#region P_GroupDAL   
	//P_Group数据访问层
	public class P_GroupDAL:BaseDAL<P_Group>,IP_GroupDAL
    {
    }
	#endregion

		#region P_PersonInfoDAL   
	//P_PersonInfo数据访问层
	public class P_PersonInfoDAL:BaseDAL<P_PersonInfo>,IP_PersonInfoDAL
    {
    }
	#endregion

		#region R_Department_MissionDAL   
	//R_Department_Mission数据访问层
	public class R_Department_MissionDAL:BaseDAL<R_Department_Mission>,IR_Department_MissionDAL
    {
    }
	#endregion

		#region R_Group_MissionDAL   
	//R_Group_Mission数据访问层
	public class R_Group_MissionDAL:BaseDAL<R_Group_Mission>,IR_Group_MissionDAL
    {
    }
	#endregion

		#region R_UserInfo_ActionInfoDAL   
	//R_UserInfo_ActionInfo数据访问层
	public class R_UserInfo_ActionInfoDAL:BaseDAL<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDAL
    {
    }
	#endregion

		#region R_UserInfo_DepartmentInfoDAL   
	//R_UserInfo_DepartmentInfo数据访问层
	public class R_UserInfo_DepartmentInfoDAL:BaseDAL<R_UserInfo_DepartmentInfo>,IR_UserInfo_DepartmentInfoDAL
    {
    }
	#endregion

		#region R_UserInfo_GroupDAL   
	//R_UserInfo_Group数据访问层
	public class R_UserInfo_GroupDAL:BaseDAL<R_UserInfo_Group>,IR_UserInfo_GroupDAL
    {
    }
	#endregion

		#region R_UserInfo_PersonInfoDAL   
	//R_UserInfo_PersonInfo数据访问层
	public class R_UserInfo_PersonInfoDAL:BaseDAL<R_UserInfo_PersonInfo>,IR_UserInfo_PersonInfoDAL
    {
    }
	#endregion

		#region R_UserInfo_SMSMissionDAL   
	//R_UserInfo_SMSMission数据访问层
	public class R_UserInfo_SMSMissionDAL:BaseDAL<R_UserInfo_SMSMission>,IR_UserInfo_SMSMissionDAL
    {
    }
	#endregion

		#region RoleInfoDAL   
	//RoleInfo数据访问层
	public class RoleInfoDAL:BaseDAL<RoleInfo>,IRoleInfoDAL
    {
    }
	#endregion

		#region S_SMSContentDAL   
	//S_SMSContent数据访问层
	public class S_SMSContentDAL:BaseDAL<S_SMSContent>,IS_SMSContentDAL
    {
    }
	#endregion

		#region S_SMSMissionDAL   
	//S_SMSMission数据访问层
	public class S_SMSMissionDAL:BaseDAL<S_SMSMission>,IS_SMSMissionDAL
    {
    }
	#endregion

		#region S_SMSRecord_CurrentDAL   
	//S_SMSRecord_Current数据访问层
	public class S_SMSRecord_CurrentDAL:BaseDAL<S_SMSRecord_Current>,IS_SMSRecord_CurrentDAL
    {
    }
	#endregion

		#region S_SMSRecord_HistoryDAL   
	//S_SMSRecord_History数据访问层
	public class S_SMSRecord_HistoryDAL:BaseDAL<S_SMSRecord_History>,IS_SMSRecord_HistoryDAL
    {
    }
	#endregion

		#region UserInfoDAL   
	//UserInfo数据访问层
	public class UserInfoDAL:BaseDAL<UserInfo>,IUserInfoDAL
    {
    }
	#endregion

	
}