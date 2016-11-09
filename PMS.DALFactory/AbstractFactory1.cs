

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
	 
		#region 创建J_JobInfo的实例
        /// <summary>
        /// 创建J_JobInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IJ_JobInfoDAL CreateJ_JobInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".J_JobInfoDAL";
            return CreateInstance(fullClassName) as IJ_JobInfoDAL;
        }
		#endregion
	 
		#region 创建J_JobTemplate的实例
        /// <summary>
        /// 创建J_JobTemplate的实例
        /// </summary>
        /// <returns></returns>
        public static IJ_JobTemplateDAL CreateJ_JobTemplateDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".J_JobTemplateDAL";
            return CreateInstance(fullClassName) as IJ_JobTemplateDAL;
        }
		#endregion
	 
		#region 创建N_News的实例
        /// <summary>
        /// 创建N_News的实例
        /// </summary>
        /// <returns></returns>
        public static IN_NewsDAL CreateN_NewsDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".N_NewsDAL";
            return CreateInstance(fullClassName) as IN_NewsDAL;
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
	 
		#region 创建QRTZ_TRIGGERS的实例
        /// <summary>
        /// 创建QRTZ_TRIGGERS的实例
        /// </summary>
        /// <returns></returns>
        public static IQRTZ_TRIGGERSDAL CreateQRTZ_TRIGGERSDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".QRTZ_TRIGGERSDAL";
            return CreateInstance(fullClassName) as IQRTZ_TRIGGERSDAL;
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
	 
		#region 创建R_UserInfo_DepartmentInfo的实例
        /// <summary>
        /// 创建R_UserInfo_DepartmentInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IR_UserInfo_DepartmentInfoDAL CreateR_UserInfo_DepartmentInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_UserInfo_DepartmentInfoDAL";
            return CreateInstance(fullClassName) as IR_UserInfo_DepartmentInfoDAL;
        }
		#endregion
	 
		#region 创建R_UserInfo_Group的实例
        /// <summary>
        /// 创建R_UserInfo_Group的实例
        /// </summary>
        /// <returns></returns>
        public static IR_UserInfo_GroupDAL CreateR_UserInfo_GroupDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_UserInfo_GroupDAL";
            return CreateInstance(fullClassName) as IR_UserInfo_GroupDAL;
        }
		#endregion
	 
		#region 创建R_UserInfo_News的实例
        /// <summary>
        /// 创建R_UserInfo_News的实例
        /// </summary>
        /// <returns></returns>
        public static IR_UserInfo_NewsDAL CreateR_UserInfo_NewsDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_UserInfo_NewsDAL";
            return CreateInstance(fullClassName) as IR_UserInfo_NewsDAL;
        }
		#endregion
	 
		#region 创建R_UserInfo_PersonInfo的实例
        /// <summary>
        /// 创建R_UserInfo_PersonInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IR_UserInfo_PersonInfoDAL CreateR_UserInfo_PersonInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_UserInfo_PersonInfoDAL";
            return CreateInstance(fullClassName) as IR_UserInfo_PersonInfoDAL;
        }
		#endregion
	 
		#region 创建R_UserInfo_SMSMission的实例
        /// <summary>
        /// 创建R_UserInfo_SMSMission的实例
        /// </summary>
        /// <returns></returns>
        public static IR_UserInfo_SMSMissionDAL CreateR_UserInfo_SMSMissionDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".R_UserInfo_SMSMissionDAL";
            return CreateInstance(fullClassName) as IR_UserInfo_SMSMissionDAL;
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
	 
		#region 创建S_SMSContent的实例
        /// <summary>
        /// 创建S_SMSContent的实例
        /// </summary>
        /// <returns></returns>
        public static IS_SMSContentDAL CreateS_SMSContentDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".S_SMSContentDAL";
            return CreateInstance(fullClassName) as IS_SMSContentDAL;
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
	 
		#region 创建S_SMSMsgContent的实例
        /// <summary>
        /// 创建S_SMSMsgContent的实例
        /// </summary>
        /// <returns></returns>
        public static IS_SMSMsgContentDAL CreateS_SMSMsgContentDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".S_SMSMsgContentDAL";
            return CreateInstance(fullClassName) as IS_SMSMsgContentDAL;
        }
		#endregion
	 
		#region 创建S_SMSRecord_Current的实例
        /// <summary>
        /// 创建S_SMSRecord_Current的实例
        /// </summary>
        /// <returns></returns>
        public static IS_SMSRecord_CurrentDAL CreateS_SMSRecord_CurrentDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".S_SMSRecord_CurrentDAL";
            return CreateInstance(fullClassName) as IS_SMSRecord_CurrentDAL;
        }
		#endregion
	 
		#region 创建S_SMSRecord_History的实例
        /// <summary>
        /// 创建S_SMSRecord_History的实例
        /// </summary>
        /// <returns></returns>
        public static IS_SMSRecord_HistoryDAL CreateS_SMSRecord_HistoryDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".S_SMSRecord_HistoryDAL";
            return CreateInstance(fullClassName) as IS_SMSRecord_HistoryDAL;
        }
		#endregion
	 
		#region 创建S_SMSType的实例
        /// <summary>
        /// 创建S_SMSType的实例
        /// </summary>
        /// <returns></returns>
        public static IS_SMSTypeDAL CreateS_SMSTypeDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".S_SMSTypeDAL";
            return CreateInstance(fullClassName) as IS_SMSTypeDAL;
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
	 
		#region 创建WF_Query_Instance的实例
        /// <summary>
        /// 创建WF_Query_Instance的实例
        /// </summary>
        /// <returns></returns>
        public static IWF_Query_InstanceDAL CreateWF_Query_InstanceDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".WF_Query_InstanceDAL";
            return CreateInstance(fullClassName) as IWF_Query_InstanceDAL;
        }
		#endregion
	 
		#region 创建WF_Query_StepInfo的实例
        /// <summary>
        /// 创建WF_Query_StepInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IWF_Query_StepInfoDAL CreateWF_Query_StepInfoDAL()
        {
            //获取类的全名称：命名空间+类名
            string fullClassName = NameSpace + ".WF_Query_StepInfoDAL";
            return CreateInstance(fullClassName) as IWF_Query_StepInfoDAL;
        }
		#endregion
	    }
	
}