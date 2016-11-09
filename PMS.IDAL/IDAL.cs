
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

	   #region IJ_JobInfoDAL   
	//J_JobInfo数据访问层
	/// <summary>
    /// 定义J_JobInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IJ_JobInfoDAL:IBaseDAL<J_JobInfo>
    {
    }
	#endregion

	   #region IJ_JobTemplateDAL   
	//J_JobTemplate数据访问层
	/// <summary>
    /// 定义J_JobTemplate实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IJ_JobTemplateDAL:IBaseDAL<J_JobTemplate>
    {
    }
	#endregion

	   #region IN_NewsDAL   
	//N_News数据访问层
	/// <summary>
    /// 定义N_News实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IN_NewsDAL:IBaseDAL<N_News>
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

	   #region IQRTZ_TRIGGERSDAL   
	//QRTZ_TRIGGERS数据访问层
	/// <summary>
    /// 定义QRTZ_TRIGGERS实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IQRTZ_TRIGGERSDAL:IBaseDAL<QRTZ_TRIGGERS>
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

	   #region IR_UserInfo_DepartmentInfoDAL   
	//R_UserInfo_DepartmentInfo数据访问层
	/// <summary>
    /// 定义R_UserInfo_DepartmentInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_UserInfo_DepartmentInfoDAL:IBaseDAL<R_UserInfo_DepartmentInfo>
    {
    }
	#endregion

	   #region IR_UserInfo_GroupDAL   
	//R_UserInfo_Group数据访问层
	/// <summary>
    /// 定义R_UserInfo_Group实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_UserInfo_GroupDAL:IBaseDAL<R_UserInfo_Group>
    {
    }
	#endregion

	   #region IR_UserInfo_NewsDAL   
	//R_UserInfo_News数据访问层
	/// <summary>
    /// 定义R_UserInfo_News实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_UserInfo_NewsDAL:IBaseDAL<R_UserInfo_News>
    {
    }
	#endregion

	   #region IR_UserInfo_PersonInfoDAL   
	//R_UserInfo_PersonInfo数据访问层
	/// <summary>
    /// 定义R_UserInfo_PersonInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_UserInfo_PersonInfoDAL:IBaseDAL<R_UserInfo_PersonInfo>
    {
    }
	#endregion

	   #region IR_UserInfo_SMSMissionDAL   
	//R_UserInfo_SMSMission数据访问层
	/// <summary>
    /// 定义R_UserInfo_SMSMission实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IR_UserInfo_SMSMissionDAL:IBaseDAL<R_UserInfo_SMSMission>
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

	   #region IS_SMSContentDAL   
	//S_SMSContent数据访问层
	/// <summary>
    /// 定义S_SMSContent实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IS_SMSContentDAL:IBaseDAL<S_SMSContent>
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

	   #region IS_SMSMsgContentDAL   
	//S_SMSMsgContent数据访问层
	/// <summary>
    /// 定义S_SMSMsgContent实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IS_SMSMsgContentDAL:IBaseDAL<S_SMSMsgContent>
    {
    }
	#endregion

	   #region IS_SMSRecord_CurrentDAL   
	//S_SMSRecord_Current数据访问层
	/// <summary>
    /// 定义S_SMSRecord_Current实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IS_SMSRecord_CurrentDAL:IBaseDAL<S_SMSRecord_Current>
    {
    }
	#endregion

	   #region IS_SMSRecord_HistoryDAL   
	//S_SMSRecord_History数据访问层
	/// <summary>
    /// 定义S_SMSRecord_History实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IS_SMSRecord_HistoryDAL:IBaseDAL<S_SMSRecord_History>
    {
    }
	#endregion

	   #region IS_SMSTypeDAL   
	//S_SMSType数据访问层
	/// <summary>
    /// 定义S_SMSType实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IS_SMSTypeDAL:IBaseDAL<S_SMSType>
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

	   #region IWF_Query_InstanceDAL   
	//WF_Query_Instance数据访问层
	/// <summary>
    /// 定义WF_Query_Instance实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IWF_Query_InstanceDAL:IBaseDAL<WF_Query_Instance>
    {
    }
	#endregion

	   #region IWF_Query_StepInfoDAL   
	//WF_Query_StepInfo数据访问层
	/// <summary>
    /// 定义WF_Query_StepInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
	public interface IWF_Query_StepInfoDAL:IBaseDAL<WF_Query_StepInfo>
    {
    }
	#endregion

	
}