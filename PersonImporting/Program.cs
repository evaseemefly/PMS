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
            string option;
            ShowMsg("--------------------------------------------------------------------------");
            ShowMsg("               国家海洋环境预报中心短彩信云平台");
            ShowMsg("               通讯录导入导出程序");
            ShowMsg("--------------------------------------------------------------------------");
            ShowMsg("   说明：通讯录需为TXT格式，文件名为'优先级+群组名称+.txt'，中间去掉'+'号");
            ShowMsg("         ,txt文件中的每一行为一个联系人，格式为'所在机构名称，联系人姓名");
            ShowMsg("         ,电话'，各项由逗号分隔。");
            ShowMsg("--------------------------------------------------------------------------");
            while (true)
            {
                ShowMsg("请选择操作类型，A：导入通讯录，B：导出通讯录 C:退出" );
                option = Console.ReadLine();
                if (!CheckedOption(option))
                {
                    ShowMsg("输入错误，请重新输入选项");
                    continue;
                }
                else
                {
                    break;
                }
            }
            //根据选项，执行导入或导出
            switch (option)
            {
                case "A":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              导入通讯录");
                    Import();
                    break;
                case "B":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              导出通讯录");
                    Export();
                    break;
                case "C":
                    break;
                default:
                    break;
                
            }
           
        }
        /// <summary>
        /// 2. 导出通讯录程序
        /// </summary>
        private static void Export()
        {
            //2.1 选择导出路径
            while (true)
            {
                ShowMsg("请输入想要导出的路径：");
                sourcePath = Console.ReadLine();
                if (!CheckedDirExist(sourcePath))
                {
                    ShowMsg("路径不存在请重新输入");
                    continue;
                }
                else
                {
                    break;
                }

            }

            groupBLL = new BLL.P_GroupBLL();
            departmentBLL = new BLL.P_DepartmentBLL();
            personBLL = new BLL.P_PersonBLL();
            r_personBLL = new PMS.BLL.P_PersonInfoBLL();

            //2.3 导出的群组

            var list = DBOperate();

            //2.4 写入文件
            SaveFile(sourcePath,list);

            ShowMsg("导出联系人成功！共导出：" + list.Count() + " 人");
            ShowMsg("点击任意键退出");
            Console.ReadKey();
        }
        private static void Import()
        {
            string fileName;
            while (true)
            {
                ShowMsg("请输入文件所在路径：");
                sourcePath = Console.ReadLine();
                if (!CheckedDirExist(sourcePath))
                {
                    ShowMsg("路径不存在请重新输入");
                    continue;
                }
                else
                {
                    break;
                }

            }

            while (true)
            {
                ShowMsg("请输入文件名：");
                fileName = Console.ReadLine();
                if (!CheckedFileExist(Path.Combine(sourcePath, fileName)))
                {
                    ShowMsg("不存在指定文件");
                    continue;
                }
                else
                {
                    break;
                }

            }
            //string fileName = "999测试群组二.txt";
            groupBLL = new BLL.P_GroupBLL();
            departmentBLL = new BLL.P_DepartmentBLL();
            personBLL = new BLL.P_PersonBLL();
            r_personBLL = new PMS.BLL.P_PersonInfoBLL();
            var list = LoadFile(sourcePath, fileName);
            DBOperate(list);
            ShowMsg("导入联系人成功！共录入：" + list.Count() + " 人");
            ShowMsg("点击任意键退出");
            Console.ReadKey();
        }
        private static bool CheckedOption(string option)
        {
            if (option.Equals("A") || option.Equals("B") || option.Equals("C"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool CheckedDirExist(string path)
        {
           return Directory.Exists(path);
        }

        private static bool CheckedFileExist(string fullpath)
        {
            return File.Exists(fullpath);
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
                catch (IOException ex)
                {

                    throw ex;
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
                ShowMsg("导出联系人：" + item.PersonName + "- 电话：" + item.Phone + "- 部门：" + item.DepartmentName+"                 成功！");
            }
        }
        #endregion


        public static void ShowMsg(string msg)
        {
            Console.WriteLine(msg);
        }



        /// <summary>
        /// 数据库操作----导出通讯录
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="groupName"></param>
        public static List<ViewModel.PersonModel> DBOperate()
        {
            
            string groupName;
            P_Group group;
            while (true)
            {
                ShowMsg("请输入想要导出的群组名称：");
                groupName = Console.ReadLine();
                group = groupBLL.getGroupByName(groupName);
                //1.检查群组是否存在
                if (group==null)
                {
                    ShowMsg("路径不存在请重新输入");
                    continue;
                }
                else
                {
                    break;
                }

            }
            //2.得到该群组下的联系人信息并封装
            List<ViewModel.PersonModel> list_model = new List<ViewModel.PersonModel>();
            List<P_PersonInfo> list_person = group.P_PersonInfo.ToList();
            foreach(var item in list_person)
            {
                var obj = BLL.OperateBLL.getPersonModelFromDB(item, group);
                list_model.Add(obj);
            }

            return list_model;
        }


        public static void SaveFile(string sourcePath, List<ViewModel.PersonModel> list_model)
        {
            if(list_model.Count < 1)
            {
                ShowMsg("该群组为空");
                return;
            }
            else
            {
                string fileName = list_model.FirstOrDefault().GroupSort + list_model.FirstOrDefault().GroupName + ".txt";
                string fullPath = Path.Combine(sourcePath, fileName);
                //此构造函数中第二参数是布尔值，如果此值为false，则创建一个新文件，如果存在原文件，则覆盖。如果此值为true，则打开文件保留原来数据，如果找不到文件，则创建新文件。
                try
                {
                    StreamWriter sw = new StreamWriter(fullPath, true);
                     foreach(var item in list_model)
                    {
                        string info = item.DepartmentName + "," + item.PersonName + ',' + item.PersonName;
                        sw.WriteLine(info);
                        ShowMsg("导入联系人：" + item.PersonName + "- 电话：" + item.Phone + "- 部门：" + item.DepartmentName + "                 成功！");
                    }
                     sw.Close();

                }
                catch (IOException ex)
                {
                    throw ex;
                }
            }

        }

    }
}
