using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.DALSQLSer;

namespace DALTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfoDAL dal = new UserInfoDAL();


            List<UserInfo> list= dal.GetListBy(
                u => u.DelFlag==false).ToList();

            UserInfo userInfo = new UserInfo()
            {
                DelFlag = false,
                ModifiedOnTime = DateTime.Now,
                Sort =100,
                SubTime = DateTime.Now,
                 Remark="123",
                UName ="测试1",
                UPwd="123"
            };
            dal.Create(userInfo);
            dal.SaveChange();
            //list.ForEach(a => Console.WriteLine(a.ID + " " + a.UName));
            Console.ReadLine();
        }
    }
}
