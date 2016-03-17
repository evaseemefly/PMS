using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using System.Linq.Expressions;

namespace PMS.BLL
{
    public class UserInfoBLL : BaseBLL<UserInfo>, IUserInfo
    {
        public UserInfoBLL()
        {
            //Console.WriteLine("子类构造函数");
        }
        public override void SetCurrentDAL()
        {
            base.CurrentDAL = base.CurrentDBSession.UserInfoDAL;
        }
    }
}
