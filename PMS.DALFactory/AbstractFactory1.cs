

using System.Configuration;
using System.Reflection;
using PMS.IDAL;

namespace PMS.DALFactory
{

    public partial class AbstractFactory
    {     
		 
		#region 创建ActionInfo的实例
        /// <summary>
        /// 创建ActionInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IActionInfoDAL CreateActionInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".ActionInfoDAL";
            return CreateInstance(fullClassName) as IActionInfoDAL;
        }
		#endregion
	 
		#region 创建P_DepartmentInfo的实例
        /// <summary>
        /// 创建P_DepartmentInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IP_DepartmentInfoDAL CreateP_DepartmentInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".P_DepartmentInfoDAL";
            return CreateInstance(fullClassName) as IP_DepartmentInfoDAL;
        }
		#endregion
	 
		#region 创建P_Group的实例
        /// <summary>
        /// 创建P_Group的实例
        /// </summary>
        /// <returns></returns>
        public static IP_GroupDAL CreateP_GroupDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".P_GroupDAL";
            return CreateInstance(fullClassName) as IP_GroupDAL;
        }
		#endregion
	 
		#region 创建P_PersonInfo的实例
        /// <summary>
        /// 创建P_PersonInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IP_PersonInfoDAL CreateP_PersonInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".P_PersonInfoDAL";
            return CreateInstance(fullClassName) as IP_PersonInfoDAL;
        }
		#endregion
	 
		#region 创建R_Department_Mission的实例
        /// <summary>
        /// 创建R_Department_Mission的实例
        /// </summary>
        /// <returns></returns>
        public static IR_Department_MissionDAL CreateR_Department_MissionDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_Department_MissionDAL";
            return CreateInstance(fullClassName) as IR_Department_MissionDAL;
        }
		#endregion
	 
		#region 创建R_Group_Mission的实例
        /// <summary>
        /// 创建R_Group_Mission的实例
        /// </summary>
        /// <returns></returns>
        public static IR_Group_MissionDAL CreateR_Group_MissionDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_Group_MissionDAL";
            return CreateInstance(fullClassName) as IR_Group_MissionDAL;
        }
		#endregion
	 
		#region 创建R_UserInfo_ActionInfo的实例
        /// <summary>
        /// 创建R_UserInfo_ActionInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IR_UserInfo_ActionInfoDAL CreateR_UserInfo_ActionInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_UserInfo_ActionInfoDAL";
            return CreateInstance(fullClassName) as IR_UserInfo_ActionInfoDAL;
        }
		#endregion
	 
		#region 创建RoleInfo的实例
        /// <summary>
        /// 创建RoleInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IRoleInfoDAL CreateRoleInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".RoleInfoDAL";
            return CreateInstance(fullClassName) as IRoleInfoDAL;
        }
		#endregion
	 
		#region 创建S_SMSMission的实例
        /// <summary>
        /// 创建S_SMSMission的实例
        /// </summary>
        /// <returns></returns>
        public static IS_SMSMissionDAL CreateS_SMSMissionDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".S_SMSMissionDAL";
            return CreateInstance(fullClassName) as IS_SMSMissionDAL;
        }
		#endregion
	 
		#region 创建UserInfo的实例
        /// <summary>
        /// 创建UserInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IUserInfoDAL CreateUserInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".UserInfoDAL";
            return CreateInstance(fullClassName) as IUserInfoDAL;
        }
		#endregion
	    }
	
}