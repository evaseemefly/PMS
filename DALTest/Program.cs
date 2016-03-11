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

            List<UserInfo> list= dal.GetListBy(u => u.ID == 2).ToList();

            list.ForEach(a => Console.WriteLine(a.ID + " " + a.UName));
            Console.ReadLine();
        }
    }
}
