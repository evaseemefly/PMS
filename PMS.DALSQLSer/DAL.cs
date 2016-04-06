
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

		#region RoleInfoDAL   
	//RoleInfo数据访问层
	public class RoleInfoDAL:BaseDAL<RoleInfo>,IRoleInfoDAL
    {
    }
	#endregion

		#region S_SMSMissionDAL   
	//S_SMSMission数据访问层
	public class S_SMSMissionDAL:BaseDAL<S_SMSMission>,IS_SMSMissionDAL
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