
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

	   #region IP_DepartmentInfoDAL   
	//P_DepartmentInfo数据访问层
	/// <summary>
    /// 定义P_DepartmentInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IP_DepartmentInfoDAL:IBaseDAL<P_DepartmentInfo>
    {
    }
	#endregion

	   #region IP_GroupDAL   
	//P_Group数据访问层
	/// <summary>
    /// 定义P_Group实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IP_GroupDAL:IBaseDAL<P_Group>
    {
    }
	#endregion

	   #region IP_PersonInfoDAL   
	//P_PersonInfo数据访问层
	/// <summary>
    /// 定义P_PersonInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IP_PersonInfoDAL:IBaseDAL<P_PersonInfo>
    {
    }
	#endregion

	   #region IR_Department_MissionDAL   
	//R_Department_Mission数据访问层
	/// <summary>
    /// 定义R_Department_Mission实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_Department_MissionDAL:IBaseDAL<R_Department_Mission>
    {
    }
	#endregion

	   #region IR_Group_MissionDAL   
	//R_Group_Mission数据访问层
	/// <summary>
    /// 定义R_Group_Mission实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_Group_MissionDAL:IBaseDAL<R_Group_Mission>
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

	   #region IS_SMSMissionDAL   
	//S_SMSMission数据访问层
	/// <summary>
    /// 定义S_SMSMission实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IS_SMSMissionDAL:IBaseDAL<S_SMSMission>
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