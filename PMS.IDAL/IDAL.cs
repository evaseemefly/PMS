
using PMS.Model;


namespace PMS.IDAL
{
   #region IActionInfoDAL   
	//ActionInfo数据访问层
	/// <summary>
    /// 定义ActionInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IActionInfoDAL:IBaseDAL<ActionInfo>
    {
    }
	#endregion

	   #region IR_UserInfo_ActionInfoDAL   
	//R_UserInfo_ActionInfo数据访问层
	/// <summary>
    /// 定义R_UserInfo_ActionInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_UserInfo_ActionInfoDAL:IBaseDAL<R_UserInfo_ActionInfo>
    {
    }
	#endregion

	   #region IRoleInfoDAL   
	//RoleInfo数据访问层
	/// <summary>
    /// 定义RoleInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IRoleInfoDAL:IBaseDAL<RoleInfo>
    {
    }
	#endregion

	   #region IUserInfoDAL   
	//UserInfo数据访问层
	/// <summary>
    /// 定义UserInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IUserInfoDAL:IBaseDAL<UserInfo>
    {
    }
	#endregion

	
}