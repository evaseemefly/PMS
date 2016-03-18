
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

		#region UserInfoDAL   
	//UserInfo数据访问层
	public class UserInfoDAL:BaseDAL<UserInfo>,IUserInfoDAL
    {
    }
	#endregion

	
}