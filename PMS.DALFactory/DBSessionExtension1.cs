
using PMS.IDAL;

namespace PMS.DALFactory
{
public partial class DBSession
    {
	#region _ActionInfoDAL 属性 
	private IDAL.IActionInfoDAL _ActionInfoDAL;
	#endregion

	#region
        /// <summary>
        /// 获取ActionInfoDAL的实例
        /// </summary>
        public IActionInfoDAL ActionInfoDAL
        {
            get
            {
                if(_ActionInfoDAL==null)
                {
                    _ActionInfoDAL = AbstractFactory.CreateActionInfoDAL();
                }
                return _ActionInfoDAL;
            }

            set
            {
                _ActionInfoDAL = value;
            }
        }
	#endregion
	

		#region _P_DepartmentInfoDAL 属性 
	private IDAL.IP_DepartmentInfoDAL _P_DepartmentInfoDAL;
	#endregion

	#region
        /// <summary>
        /// 获取P_DepartmentInfoDAL的实例
        /// </summary>
        public IP_DepartmentInfoDAL P_DepartmentInfoDAL
        {
            get
            {
                if(_P_DepartmentInfoDAL==null)
                {
                    _P_DepartmentInfoDAL = AbstractFactory.CreateP_DepartmentInfoDAL();
                }
                return _P_DepartmentInfoDAL;
            }

            set
            {
                _P_DepartmentInfoDAL = value;
            }
        }
	#endregion
	

		#region _P_GroupDAL 属性 
	private IDAL.IP_GroupDAL _P_GroupDAL;
	#endregion

	#region
        /// <summary>
        /// 获取P_GroupDAL的实例
        /// </summary>
        public IP_GroupDAL P_GroupDAL
        {
            get
            {
                if(_P_GroupDAL==null)
                {
                    _P_GroupDAL = AbstractFactory.CreateP_GroupDAL();
                }
                return _P_GroupDAL;
            }

            set
            {
                _P_GroupDAL = value;
            }
        }
	#endregion
	

		#region _P_PersonInfoDAL 属性 
	private IDAL.IP_PersonInfoDAL _P_PersonInfoDAL;
	#endregion

	#region
        /// <summary>
        /// 获取P_PersonInfoDAL的实例
        /// </summary>
        public IP_PersonInfoDAL P_PersonInfoDAL
        {
            get
            {
                if(_P_PersonInfoDAL==null)
                {
                    _P_PersonInfoDAL = AbstractFactory.CreateP_PersonInfoDAL();
                }
                return _P_PersonInfoDAL;
            }

            set
            {
                _P_PersonInfoDAL = value;
            }
        }
	#endregion
	

		#region _R_Department_MissionDAL 属性 
	private IDAL.IR_Department_MissionDAL _R_Department_MissionDAL;
	#endregion

	#region
        /// <summary>
        /// 获取R_Department_MissionDAL的实例
        /// </summary>
        public IR_Department_MissionDAL R_Department_MissionDAL
        {
            get
            {
                if(_R_Department_MissionDAL==null)
                {
                    _R_Department_MissionDAL = AbstractFactory.CreateR_Department_MissionDAL();
                }
                return _R_Department_MissionDAL;
            }

            set
            {
                _R_Department_MissionDAL = value;
            }
        }
	#endregion
	

		#region _R_Group_MissionDAL 属性 
	private IDAL.IR_Group_MissionDAL _R_Group_MissionDAL;
	#endregion

	#region
        /// <summary>
        /// 获取R_Group_MissionDAL的实例
        /// </summary>
        public IR_Group_MissionDAL R_Group_MissionDAL
        {
            get
            {
                if(_R_Group_MissionDAL==null)
                {
                    _R_Group_MissionDAL = AbstractFactory.CreateR_Group_MissionDAL();
                }
                return _R_Group_MissionDAL;
            }

            set
            {
                _R_Group_MissionDAL = value;
            }
        }
	#endregion
	

		#region _R_UserInfo_ActionInfoDAL 属性 
	private IDAL.IR_UserInfo_ActionInfoDAL _R_UserInfo_ActionInfoDAL;
	#endregion

	#region
        /// <summary>
        /// 获取R_UserInfo_ActionInfoDAL的实例
        /// </summary>
        public IR_UserInfo_ActionInfoDAL R_UserInfo_ActionInfoDAL
        {
            get
            {
                if(_R_UserInfo_ActionInfoDAL==null)
                {
                    _R_UserInfo_ActionInfoDAL = AbstractFactory.CreateR_UserInfo_ActionInfoDAL();
                }
                return _R_UserInfo_ActionInfoDAL;
            }

            set
            {
                _R_UserInfo_ActionInfoDAL = value;
            }
        }
	#endregion
	

		#region _RoleInfoDAL 属性 
	private IDAL.IRoleInfoDAL _RoleInfoDAL;
	#endregion

	#region
        /// <summary>
        /// 获取RoleInfoDAL的实例
        /// </summary>
        public IRoleInfoDAL RoleInfoDAL
        {
            get
            {
                if(_RoleInfoDAL==null)
                {
                    _RoleInfoDAL = AbstractFactory.CreateRoleInfoDAL();
                }
                return _RoleInfoDAL;
            }

            set
            {
                _RoleInfoDAL = value;
            }
        }
	#endregion
	

		#region _S_SMSMissionDAL 属性 
	private IDAL.IS_SMSMissionDAL _S_SMSMissionDAL;
	#endregion

	#region
        /// <summary>
        /// 获取S_SMSMissionDAL的实例
        /// </summary>
        public IS_SMSMissionDAL S_SMSMissionDAL
        {
            get
            {
                if(_S_SMSMissionDAL==null)
                {
                    _S_SMSMissionDAL = AbstractFactory.CreateS_SMSMissionDAL();
                }
                return _S_SMSMissionDAL;
            }

            set
            {
                _S_SMSMissionDAL = value;
            }
        }
	#endregion
	

		#region _UserInfoDAL 属性 
	private IDAL.IUserInfoDAL _UserInfoDAL;
	#endregion

	#region
        /// <summary>
        /// 获取UserInfoDAL的实例
        /// </summary>
        public IUserInfoDAL UserInfoDAL
        {
            get
            {
                if(_UserInfoDAL==null)
                {
                    _UserInfoDAL = AbstractFactory.CreateUserInfoDAL();
                }
                return _UserInfoDAL;
            }

            set
            {
                _UserInfoDAL = value;
            }
        }
	#endregion
	

		}
}