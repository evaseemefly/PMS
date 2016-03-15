using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IDAL;

namespace PMS.DALFactory
{
    public partial class DBSession
    {
        private IDAL.IUserInfoDAL userInfoDAL;

        /// <summary>
        /// 获取UserInfoDAL的实例
        /// </summary>
        public IUserInfoDAL UserInfoDAL
        {
            get
            {
                if(userInfoDAL==null)
                {
                    userInfoDAL = AbstractFactory.CreateUserInfoDAL();
                }
                return userInfoDAL;
            }

            set
            {
                userInfoDAL = value;
            }
        }
    }
}
