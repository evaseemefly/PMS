using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.ViewModel;
using System.IO;
using PMS.Model;

namespace PersonImporting
{
    class MissionImporting
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

        protected static BLL.MissionBLL missionBLL { get; set; }

        protected static PMS.IBLL.IP_PersonInfoBLL r_personBLL { get; set; }


        public static void Import()
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
                    //personBLL = new BLL.P_PersonBLL();
                    //r_personBLL = new PMS.BLL.P_PersonInfoBLL();
                    missionBLL = new BLL.MissionBLL();
                    var list = LoadFile(fullPath, fileName);
                    if (list.Count < 1)
                    {
                        ShowMsg("文件内容格式错误，请检查任务信息是否完整，并按说明要求导入");
                    }
                    else
                    {
                        DBOperate(list);
                        ShowMsg("导入任务成功！共录入：" + list.Count() + " 个");
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

        public static void Export()
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
            missionBLL = new BLL.MissionBLL();

            //2.3 导出的任务
            var missionNameList = GetMissionNameList();
            ShowMsg("准备导出任务共：" + missionNameList.Count() + " 个");
            Console.ReadKey();
            foreach (var item in missionNameList)
            {
                var list = DBOperate(item);
                //2.4 写入文件
                SaveFile(sourcePath, list);

                ShowMsg("导出任务成功！相关部门和群组共：" + list.Count() + " 个");
            }

            ShowMsg("共导出"+missionNameList.Count()+ "个任务，点击任意键退出");
            Console.ReadKey();
        }

        private static bool CheckedDirExist(string path)
        {
            return Directory.Exists(path);
        }
        private static void SaveFile(string sourcePath, List<ViewModel.MissionModel> list_model)
        {
            if (list_model.Count < 1)
            {
                ShowMsg("该任务为空");
                return;
            }
            else
            {
                //如果Sort不足三位，则左侧补0补齐至三位
                string sort = list_model.FirstOrDefault().MissionSort.ToString().PadLeft(3, '0');
                string fileName = sort + list_model.FirstOrDefault().MissionName + ".txt";
                string fullPath = Path.Combine(sourcePath, fileName);
                //此构造函数中第二参数是布尔值，如果此值为false，则创建一个新文件，如果存在原文件，则覆盖。如果此值为true，则打开文件保留原来数据，如果找不到文件，则创建新文件。
                try
                {
                    StreamWriter sw = new StreamWriter(fullPath, false,Encoding.Default);
                    foreach (var item in list_model)
                    {
                        string info = item.Name + "," + item.GroupOrDepartment + ',' + item.MSGType + ',' + item.IsPass;
                        sw.WriteLine(info);
                        ShowMsg("导出任务：" + item.MissionName + "- 关联：" + item.Name + "- 部门/群组：" + item.GroupOrDepartment + "- 类型：" + item.MSGType + "- 启用：" + item.IsPass);
                    }
                    sw.Close();

                }
                catch (IOException ex)
                {
                    throw ex;
                }
            }

        }
        private static List<ViewModel.MissionModel> LoadFile(string fullPath, string fileName)
        {
            //1 将文件以流的形式读取，并转成对象集合



            //去掉file的后缀
            var missionName = fileName.Substring(3, fileName.IndexOf('.')-3);

            var sort = int.Parse(fileName.Substring(0, 3));
            StreamReader sr = new StreamReader(fullPath, Encoding.Default);

            List<ViewModel.MissionModel> list_model = new List<ViewModel.MissionModel>();

            while (!sr.EndOfStream)
            {
                string textLine = sr.ReadLine();
                //数据验证：文件内容验证
                if (!Utils.ImportExportUtils.ContactsValidationM(textLine))
                {
                    Console.WriteLine(textLine + "出现错误，请检查！");
                    list_model.Clear();
                    break;
                }
                else
                {
                    try
                    {
                        var obj = BLL.OperateBLL.Array2MObj(textLine, missionName, sort);
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


        private static void ShowMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        //public static List<ViewModel.MissionModel> DBOperate()
        //{

        //    string groupName;

        //    P_Group group;
        //    while (true)
        //    {
        //        ShowMsg("请输入想要导出的群组名称：");
        //        groupName = Console.ReadLine();
        //        group = groupBLL.getGroupByName(groupName);
        //        //1.检查群组是否存在
        //        if (group == null)
        //        {
        //            ShowMsg("路径不存在请重新输入");
        //            continue;
        //        }
        //        else
        //        {
        //            break;
        //        }

        //    }
        //    //2.得到该群组下的联系人信息并封装
        //    List<ViewModel.PersonModel> list_model = new List<ViewModel.PersonModel>();
        //    List<P_PersonInfo> list_person = group.P_PersonInfo.ToList();
        //    foreach (var item in list_person)
        //    {
        //        var obj = BLL.OperateBLL.getPersonModelFromDB(item, group);
        //        list_model.Add(obj);
        //    }

        //    return list_model;
        //}
        private static void DBOperate(List<ViewModel.MissionModel> list)
        {
            //2 写入数据库
            //判断是否已经存在群组
            //list 
            //2.1 判断或创建群组对象

            var temp = list.FirstOrDefault();
            var mission_name = temp.MissionName;
            var mission_sort = temp.MissionSort;
            var enum_group = missionBLL.CheckMissionExist(mission_name, mission_sort);
            var smid = missionBLL.GetMissionId(mission_name);
            //2.2 判断或创建任务-群组关联
            //2.3 判断或创建任务-部门关联
            foreach (var item in list)
            {
                //对部门的进行操作
                if (item.GroupOrDepartment.Equals("g"))
                {
                    //2.3.1 判断所需组是否存在
                    var eunm = groupBLL.CheckGroupExist(item.Name);
                    if (eunm.ToString().Equals("isExist"))
                    {
                        //2.3.2 建立关系
                        int gid = groupBLL.GetGroupId(item.Name);
                        List <ViewModel_isPass_Group> gids=new List<ViewModel_isPass_Group>();
                        ViewModel_isPass_Group gidTemp = new ViewModel_isPass_Group();
                        gidTemp.gid=gid;
                        gidTemp.isPass = item.IsPass.Equals("1");
                        gids.Add(gidTemp);
                        bool ismms = item.MSGType.Equals("mms");
                        missionBLL.CreatGroupRelationship(smid, gids, ismms);
                        ShowMsg("导入任务：" + item.MissionName + " - 群组：" + item.Name + " -类型："+item.MSGType + " -启用：" + item.IsPass);
                    }
                    else ShowMsg("导入任务：" + item.MissionName + " - 群组："+item.Name+"群组检查时不存在");


                }
                if (item.GroupOrDepartment.Equals("d"))
                {
                    var eunm = departmentBLL.CheckDepartmentExistNoNew(item.Name);
                    if (eunm.ToString().Equals("isExist"))
                    {
                        int did = departmentBLL.GetDepartmentId(item.Name);
                        List<ViewModel_isPass_Department> dids = new List<ViewModel_isPass_Department>();
                        ViewModel_isPass_Department didTemp = new ViewModel_isPass_Department();
                        didTemp.did = did;
                        didTemp.isPass = item.IsPass.Equals("1");
                        dids.Add(didTemp);
                        bool ismms = item.MSGType.Equals("mms");
                        missionBLL.CreatDepartmentRelationship(smid, dids, ismms);
                        ShowMsg("导入任务：" + item.MissionName + "- 部门：" + item.Name + "-类型：" + item.MSGType + "-启用：" + item.IsPass);
                    }
                    else ShowMsg("导入任务：" + item.MissionName + "- 部门：" + item.Name + "部门检查时不存在");
                }
            }






        
        }
        private static List<ViewModel.MissionModel> DBOperate(string missionName)
        {

            //string missionName;
            S_SMSMission mission;
            
            while (true)
            {
                //ShowMsg("请输入想要导出的任务名称：");
                //missionName = Console.ReadLine();
                mission = missionBLL.getMissionByName(missionName);
                //1.检查群组是否存在
                if (mission == null)
                {
                    ShowMsg("该任务不存在请重新输入");
                    continue;
                }
                else
                {
                    break;
                }

            }
            //2.得到该任务下的群组和部门信息并封装
            List<ViewModel.MissionModel> list_model = new List<ViewModel.MissionModel>();
            List<R_Group_Mission> list_group = mission.R_Group_Mission.ToList();
            List<R_Department_Mission> list_department = mission.R_Department_Mission.ToList();
            foreach (var item in list_group)
            {
                var obj = BLL.OperateBLL.getGroup4MissionModelFromDB(item, mission);
                list_model.Add(obj);
            }
            foreach (var item in list_department)
            {
                var obj = BLL.OperateBLL.getDepartment4MissionModelFromDB(item, mission);
                list_model.Add(obj);
            }
            return list_model;
        }
        public  static List<string> GetMissionNameList()
        {
            List<string> missionNameList = new List<string>();
            var missionList = missionBLL.getMissionList();
            foreach (var item in missionList)
            {
                missionNameList.Add(item.SMSMissionName);
            }

            return missionNameList;
        }
    }
}
