using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using PMS.BLL;


namespace RecycledFactory
{
    /// <summary>
    ///  回收站工厂
    /// </summary>
    public class SimpleRecFactory
    {
        public static IBaseDelBLL CreateBLL(int typeID)
        {
            IBaseDelBLL iDelBLL = null;
            switch (typeID) {
                //用户管理
                case 1:
                     iDelBLL = new UserInfoBLL();
                    break;
                //角色管理
                case 2:
                    iDelBLL = new RoleInfoBLL();
                    break;
                //权限管理
                case 3:
                    iDelBLL = new ActionInfoBLL();
                    break;
                //群组管理
                case 4:
                    iDelBLL = new P_GroupBLL();
                    break;
                //部门管理
                case 5:
                    iDelBLL = new P_DepartmentInfoBLL();
                    break;
                //任务管理
                case 6:
                    iDelBLL = new S_SMSMissionBLL();
                    break;
                default:
                    break;
            }


            return iDelBLL;
        }
        
    }
}
