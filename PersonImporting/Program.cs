using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PMS.IBLL;

using PMS.Model;

namespace PersonImporting
{
    class Program
    {
        private static string sourcePath { get; set; }
        protected static BLL.P_GroupBLL groupBLL { get; set; }

        protected static BLL.P_DepartmentBLL departmentBLL { get; set; }

        protected static BLL.P_PersonBLL personBLL { get; set; }

        protected static PMS.IBLL.IP_PersonInfoBLL r_personBLL { get; set; }

        static void Main(string[] args)
        {
            sourcePath = @"C:\Users\evase\Documents\20160620统计表\";
            string fileName = "101海啸警报及解除.txt";
            groupBLL = new BLL.P_GroupBLL();
            departmentBLL = new BLL.P_DepartmentBLL();
            personBLL = new BLL.P_PersonBLL();
            r_personBLL = new PMS.BLL.P_PersonInfoBLL();
          var list=  LoadFile(sourcePath,fileName);
            DBOperate(list);
        }


        #region 读取文件并转成对象集合，并返回
        private static List<ViewModel.PersonModel> LoadFile(string path, string fileName)
        {
            //1 将文件以流的形式读取，并转成对象集合
            string fullPath = Path.Combine(path, fileName);
            //去掉file的后缀
            var groupName = fileName.Substring(3, fileName.IndexOf('.') - 3);

            var sort = int.Parse(fileName.Substring(0, 3));
            StreamReader sr = new StreamReader(fullPath, Encoding.Default);

            List<ViewModel.PersonModel> list_model = new List<ViewModel.PersonModel>();

            while (!sr.EndOfStream)
            {
                string textLine = sr.ReadLine();
                try
                {
                    var obj = BLL.OperateBLL.Array2Obj(textLine, groupName, sort);
                    list_model.Add(obj);
                    //文本处理
                }
                catch (Exception)
                {

                    throw;
                }

            }
            sr.Close();
            return list_model;
            
            //var lines= File.ReadAllLines(path);
        }
        #endregion

        #region 
        public static void DBOperate(List<ViewModel.PersonModel> list)
        {
            //2 写入数据库
            //判断是否已经存在群组
            //list 
            //2.1 判断或创建群组对象
            var temp = list.FirstOrDefault();
            var group_name= temp.GroupName;
            var group_sort = temp.GroupSort;
            var enum_group= groupBLL.CheckGroupExist(group_name, group_sort);

            //2.2 判断或创建部门
            //遍历创建部门
            //2.2.1从集合中查找不重复的部门
            var department_names = (from d in list.Distinct(new EqualCompare.DepartmentEqualCompare())
                                   select d.DepartmentName).ToList();

            department_names.ForEach(d => departmentBLL.CheckDepartmentExist(d));

            //2.3 批量创建联系人
            foreach (var item in list)
            {
                //2.3.1 判断或创建联系人
                var eunm= personBLL.CheckPersonExist(item.PersonName, item.Phone);
                //2.3.2 查找该联系人对象
                int gid = groupBLL.GetGroupId(item.GroupName);
                int did = departmentBLL.GetDepartmentId(item.DepartmentName);
                personBLL.CreatPersonRelationship(item.Phone, gid,did);
            }
        }
        #endregion

    }
}
