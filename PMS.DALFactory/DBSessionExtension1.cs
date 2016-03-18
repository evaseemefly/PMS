
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