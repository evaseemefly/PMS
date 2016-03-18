

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