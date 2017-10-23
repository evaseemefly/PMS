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
        /// <summary>
        /// 导出目录
        /// </summary>
        private static string sourcePath { get; set; }
        /// <summary>
        /// 导入文件的绝对路径
        /// </summary>
        private static string fullPath { get; set; }
        protected static BLL.P_GroupBLL groupBLL { get; set; }

        protected static BLL.P_DepartmentBLL departmentBLL { get; set; }

        protected static BLL.P_PersonBLL personBLL { get; set; }

        protected static PMS.IBLL.IP_PersonInfoBLL r_personBLL { get; set; }

        static void Main(string[] args)
        {
            //MissionImporting.GetMissionList();
            //MissionImporting.Export();

            string option;
            ShowMsg("--------------------------------------------------------------------------");
            ShowMsg("               国家海洋环境预报中心短彩信云平台");
            ShowMsg("               通讯录导入导出程序");
            ShowMsg("--------------------------------------------------------------------------");
            ShowMsg("   说明：通讯录需为TXT格式，文件名为'优先级+群组名称+.txt'，中间去掉'+'号");
            ShowMsg("         ,其中，优先级需要三位数。txt文件中的每一行为一个联系人，格式为'");
            ShowMsg("         所在机构名称，联系人姓名 ,电话'，各项由逗号分隔。");
            ShowMsg("--------------------------------------------------------------------------");
            while (true)
            {
                ShowMsg("请选择操作类型，a：导入通讯录，b：导出通讯录 c:批量导入通讯录 d:导入通讯录（不修改已存在联系人的部门） e:导出所有任务 f:导入任务");
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
                case "a":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              导入通讯录");
                    while (true)
                    {
                        Import();
                    }
                    break;
                case "b":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              导出通讯录");
                    while(true)
                    {
                        Export();
                    }
                    break;
                case "c":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              批量导入文件夹下的通讯录");
                    DImport();
                    break;
                case "d":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              导入通讯录（不修改已存在联系人的部门）");
                    while (true)
                    {
                        ImportNoDpt();
                    }
                    break;
                case "e":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              导出任务");
                    while (true)
                    {
                        MissionImporting.Export();
                    }
                    break;
                case "f":
                    ShowMsg("--------------------------------------------------------------------------");
                    ShowMsg("                              按文件夹导入任务");
                    while (true)
                    {
                        MissionImporting.Import();
                    }
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
            var groupNameList = GetGroupNameList();
            ShowMsg("准备导出群组共：" + groupNameList.Count() + " 个");
            Console.ReadKey();
            foreach (var item in groupNameList)
            {
                var list = DBOperate(item);

                //2.4 写入文件
                SaveFile(sourcePath, list);

                ShowMsg("导出联系人成功！共导出：" + list.Count() + " 人");
            }
            ShowMsg("共导出" + groupNameList.Count() + "个群组，点击任意键退出");
            Console.ReadKey();
        }

        /// <summary>
        /// 批量导入
        /// </summary>
        private static void DImport()
        {
            //文件名
            string fileName;
            //绝对路径
            ShowMsg("请输入文件夹的绝对路径：");
            string folderFullName = Console.ReadLine();
            DirectoryInfo TheFolder = new DirectoryInfo(folderFullName);
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                fullPath = NextFile.FullName;
                fileName = Path.GetFileName(fullPath);
                //2 文件格式验证
                if (Utils.ImportExportUtils.FileFormateValidation(fullPath))
                {
                    groupBLL = new BLL.P_GroupBLL();
                    departmentBLL = new BLL.P_DepartmentBLL();
                    personBLL = new BLL.P_PersonBLL();
                    r_personBLL = new PMS.BLL.P_PersonInfoBLL();
                    var list = LoadFile(fullPath, fileName);
                    if (list.Count < 1)
                    {
                        ShowMsg("文件内容格式错误，请检查联系人信息是否完整，电话位数是否正确，并按说明要求导入");
                    }
                    else
                    {
                        DBOperate(list);
                        ShowMsg("导入联系人成功！共录入：" + list.Count() + " 人");
                    }
                }
                else
                {
                    ShowMsg("文件名格式错误，请按说明要求导入");

                }
            }
                       
            ShowMsg("点击任意键退出");
            Console.ReadLine();
        }

        private static void ImportNoDpt()
        {
            //文件名
            string fileName;
            //绝对路径
            while (true)
            {
                ShowMsg("请输入文件的绝对路径：");
                fullPath = Console.ReadLine();
                fileName = Path.GetFileName(fullPath);
                if (!CheckedFileExist(fullPath))
                {
                    ShowMsg("不存在指定文件，请重新输入");
                    continue;
                }
                else
                {
                    break;
                }

            }

            //2 文件格式验证
            if (Utils.ImportExportUtils.FileFormateValidation(fullPath))
            {
                groupBLL = new BLL.P_GroupBLL();
                departmentBLL = new BLL.P_DepartmentBLL();
                personBLL = new BLL.P_PersonBLL();
                r_personBLL = new PMS.BLL.P_PersonInfoBLL();
                var list = LoadFile(fullPath, fileName);
                if (list.Count < 1)
                {
                    ShowMsg("文件内容格式错误，请检查联系人信息是否完整，电话位数是否正确，并按说明要求导入");
                }
                else
                {
                    DBOperateNoDpt(list);
                    ShowMsg("导入联系人成功！共录入：" + list.Count() + " 人");
                }
            }
            else
            {
                ShowMsg("文件名格式错误，请按说明要求导入");

            }
            ShowMsg("点击任意键退出");
            Console.ReadLine();
        }

        private static void Import()
        {
            //文件名
            string fileName;
            //绝对路径
            while (true)
            {
                ShowMsg("请输入文件的绝对路径：");
                fullPath = Console.ReadLine();
                fileName = Path.GetFileName(fullPath);
                if (!CheckedFileExist(fullPath))
                {
                    ShowMsg("不存在指定文件，请重新输入");
                    continue;
                }
                else
                {
                    break;
                }

            }

            //while (true)
            //{
            //    ShowMsg("请输入文件名：");
            //    fileName = Console.ReadLine();
            //    if (!CheckedFileExist(Path.Combine(sourcePath, fileName)))
            //    {
            //        ShowMsg("不存在指定文件");
            //        continue;
            //    }
            //    else
            //    {
            //        break;
            //    }

            //}
            //string fileName = "999测试群组二.txt";

            //2 文件格式验证
            if (Utils.ImportExportUtils.FileFormateValidation(fullPath))
            {
                groupBLL = new BLL.P_GroupBLL();
                departmentBLL = new BLL.P_DepartmentBLL();
                personBLL = new BLL.P_PersonBLL();
                r_personBLL = new PMS.BLL.P_PersonInfoBLL();
                var list = LoadFile(fullPath, fileName);
                if(list.Count < 1)
                {
                    ShowMsg("文件内容格式错误，请检查联系人信息是否完整，电话位数是否正确，并按说明要求导入");
                }
                else
                {
                    DBOperate(list);
                    ShowMsg("导入联系人成功！共录入：" + list.Count() + " 人");
                }
            }
            else
            {
                ShowMsg("文件名格式错误，请按说明要求导入");

            }
                ShowMsg("点击任意键退出");
                Console.ReadLine();
        }

        private static bool CheckedOption(string option)
        {
            if (option.Equals("a") || option.Equals("b") || option.Equals("c") || option.Equals("d") || option.Equals("e") || option.Equals("f"))
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
        private static List<ViewModel.PersonModel> LoadFile(string fullPath, string fileName)
        {
            //1 将文件以流的形式读取，并转成对象集合



            //去掉file的后缀
            var groupName = fileName.Substring(3, fileName.IndexOf('.')-3);

            var sort = int.Parse(fileName.Substring(0, 3));
            StreamReader sr = new StreamReader(fullPath, Encoding.Default);

            List<ViewModel.PersonModel> list_model = new List<ViewModel.PersonModel>();

            while (!sr.EndOfStream)
            {
                string textLine = sr.ReadLine();
                //数据验证：文件内容验证
                if (!Utils.ImportExportUtils.ContactsValidation(textLine))
                {
                    Console.WriteLine(textLine+"出现错误，请检查！");
                    list_model.Clear();
                    break;
                }
                else
                {
                    try
                    {
                        var obj = BLL.OperateBLL.Array2Obj(textLine, groupName, sort);
                        list_model.Add(obj);
                        //文本处理
                    }
                    catch (IOException ex)
                    {
                    }

                }

            }
            sr.Close();
            return list_model;
            
            //var lines= File.ReadAllLines(path);
        }
        #endregion
        public static void SaveFile(string sourcePath, List<ViewModel.PersonModel> list_model)
        {
            if(list_model.Count < 1)
            {
                ShowMsg("该群组为空");
                return;
            }
            else
            {
                //如果Sort不足三位，则左侧补0补齐至三位
                string sort = list_model.FirstOrDefault().GroupSort.ToString().PadLeft(3, '0');
                string fileName = sort + list_model.FirstOrDefault().GroupName + ".txt";
                string fullPath = Path.Combine(sourcePath, fileName);
                //此构造函数中第二参数是布尔值，如果此值为false，则创建一个新文件，如果存在原文件，则覆盖。如果此值为true，则打开文件保留原来数据，如果找不到文件，则创建新文件。
                try
                {
                    StreamWriter sw = new StreamWriter(fullPath, false,Encoding.Default);
                     foreach(var item in list_model)
                    {
                        string info = item.DepartmentName + "," + item.PersonName + ',' + item.Phone;
                        sw.WriteLine(info);
                        ShowMsg("导入联系人：" + item.PersonName + "- 电话：" + item.Phone + "- 部门：" + item.DepartmentName);
                    }
                     sw.Close();

                }
                catch (IOException ex)
                {
                    throw ex;
                }
            }

        }

        #region 
        public static void DBOperateNoDpt(List<ViewModel.PersonModel> list)
        {
            //17年2月20日新加
            if (!departmentBLL.CheckDepartmentRequired())
            {
                ShowMsg("数据库中没有“顶级父节点”，请先在数据库的部门表中创建顶级父节点，设置其DID为0，设置其ＰＤＩＤ为－１");
                return;
            }
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
            string group_name_required = "全部联系人";
            var group_required= groupBLL.getGroupByName(group_name_required);

            //2.3 批量创建联系人
            foreach (var item in list)
            {
                //2.3.1 判断或创建联系人
                var eunm= personBLL.CheckPersonExist(item.PersonName, item.Phone);
                if(eunm.ToString().Equals("error"))
                {
                    ShowMsg("联系人检查时无法读写" );
                }
                //2.3.2 查找该联系人对象
                int gid = groupBLL.GetGroupId(item.GroupName);
                int did = departmentBLL.GetDepartmentId(item.DepartmentName);
                int[] gids = new int[] { gid, group_required.GID };
                if(eunm.ToString().Equals("isExist"))
                {
                    personBLL.CreatPersonRelationship(item.Phone, gids);
                    ShowMsg("导出联系人：" + item.PersonName + "- 电话：" + item.Phone + "- 部门不变");
                }
                if (eunm.ToString().Equals("ok"))
                {
                    int[] dids = new int[] { did };
                    personBLL.CreatPersonRelationship(item.Phone, gids, dids);
                ShowMsg("导出联系人：" + item.PersonName + "- 电话：" + item.Phone + "- 部门：" + item.DepartmentName);
                }
               
            }
        }

        public static void DBOperate(List<ViewModel.PersonModel> list)
        {
            //17年2月20日新加
            if (!departmentBLL.CheckDepartmentRequired())
            {
                ShowMsg("数据库中没有“顶级父节点”，请先在数据库的部门表中创建顶级父节点，设置其DID为0，设置其ＰＤＩＤ为－１");
                return;
            }
            //2 写入数据库
            //判断是否已经存在群组
            //list 
            //2.1 判断或创建群组对象

            var temp = list.FirstOrDefault();
            var group_name = temp.GroupName;
            var group_sort = temp.GroupSort;
            var enum_group = groupBLL.CheckGroupExist(group_name, group_sort);

            //2.2 判断或创建部门
            //遍历创建部门
            //2.2.1从集合中查找不重复的部门
            var department_names = (from d in list.Distinct(new EqualCompare.DepartmentEqualCompare())
                                    select d.DepartmentName).ToList();

            department_names.ForEach(d => departmentBLL.CheckDepartmentExist(d));
            string group_name_required = "全部联系人";
            var group_required = groupBLL.getGroupByName(group_name_required);

            //2.3 批量创建联系人
            foreach (var item in list)
            {
                //2.3.1 判断或创建联系人
                var eunm = personBLL.CheckPersonExist(item.PersonName, item.Phone);
                //2.3.2 查找该联系人对象
                int gid = groupBLL.GetGroupId(item.GroupName);
                int did = departmentBLL.GetDepartmentId(item.DepartmentName);
                int[] gids = new int[] { gid, group_required.GID };
                int[] dids = new int[] { did };
                personBLL.CreatPersonRelationship(item.Phone, gids, dids);

                ShowMsg("导出联系人：" + item.PersonName + "- 电话：" + item.Phone + "- 部门：" + item.DepartmentName);
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
        public static List<ViewModel.PersonModel> DBOperate(string groupName)
        {
            
            //string groupName;
            P_Group group;
            while (true)
            {
                //ShowMsg("请输入想要导出的群组名称：");
                //groupName = Console.ReadLine();
                group = groupBLL.getGroupByName(groupName);
                //1.检查群组是否存在
                if (group==null)
                {
                    ShowMsg(groupName+"群组不存在请重新输入");
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



        /// <summary>
        /// 获取所有群组名称
        /// </summary>
        /// <returns></returns>
        public static List<string> GetGroupNameList()
        {
            List<string> groupNameList = new List<string>();
            var groupList = groupBLL.getGroupList();
            foreach (var item in groupList)
            {
                groupNameList.Add(item.GroupName);
            }

            return groupNameList;
        }
    }
}
