using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using PMS.IDAL;

namespace PMS.DALSQLSer
{
    /// <summary>
    /// 用户数据访问层继承自IUserInfo接口
    /// </summary>
    public class UserInfoDAL:BaseDAL<UserInfo>, IUserInfoDAL
    {
    }
}
