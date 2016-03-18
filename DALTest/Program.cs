using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.DALSQLSer;
using PMS.BLL;
using PMS.IBLL;

namespace DALTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestModel.PersonInfo perModel = GetPerson();
            //Console.WriteLine(perModel.Id);
            //Console.WriteLine(perModel.Name);
            //Console.WriteLine("------------------");
            //perModel.Name = "屈远";
            //DBContextFactory.SetTestModel(perModel);
            //Console.WriteLine(GetPerson().Id);
            //Console.WriteLine(GetPerson().Name);
            //Console.ReadLine();
            //UserInfoDAL dal = new UserInfoDAL();

            IUserInfoBLL ibll;

            ibll = new UserInfoBLL();

            //List<UserInfo> list= dal.GetListBy(
            //    u => u.DelFlag==false).ToList();

            List<UserInfo> list = ibll.GetListBy(u => u.DelFlag == false&&u.ID==2).ToList();

            //UserInfo userInfo = new UserInfo()
            //{
            //    DelFlag = false,
            //    ModifiedOnTime = DateTime.Now,
            //    Sort =100,
            //    SubTime = DateTime.Now,
            //     Remark="123",
            //    UName ="测试1",
            //    UPwd="123"
            //};
            //dal.Create(userInfo);
            //dal.SaveChange();
            //list.ForEach(a => Console.WriteLine(a.ID + " " + a.UName));
            Console.ReadLine();
        }

        static TestModel.PersonInfo GetPerson()
        {
            
TestModel.PersonInfo perInfo=PMS.DALSQLSer.DBContextFactory.GetTestModel();
            return perInfo;
        }

    }
}
