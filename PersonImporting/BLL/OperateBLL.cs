using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;


namespace PersonImporting.BLL
{
    public static class OperateBLL
    {

        public static ViewModel.PersonModel Array2Obj(string str,string groupName,int sort)
        {
            //str:海洋局办,王斌,13661037121
            var array= str.Split(',');
            //[海洋局办,王斌,13661037121]

            ViewModel.PersonModel model = new ViewModel.PersonModel()
            {
                DepartmentName = array[0],
                GroupName = groupName,
                GroupSort=sort,
                PersonName = array[1],
                Phone = array[2]
            };
            return model;

        }

        public static ViewModel.MissionModel Array2MObj(string str, string groupName, int sort)
        {
            //str:群组1,g,sms,1
            var array = str.Split(',');
            //[海洋局办,王斌,13661037121]

            ViewModel.MissionModel model = new ViewModel.MissionModel()
            {
                Name = array[0],
                MissionName = groupName,
                MissionSort = sort,
                GroupOrDepartment = array[1],
                IsPass = array[3],
                MSGType=array[2]
            };
            return model;

        }

        /// <summary>
        /// 将DB中联系人的信息封装为TXT需要的模板
        /// </summary>
        /// <param name="person"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static ViewModel.PersonModel getPersonModelFromDB(P_PersonInfo person, P_Group group)
        {
            if (person.P_DepartmentInfo.ToList().Count != 1)
            {
                ViewModel.PersonModel model = new ViewModel.PersonModel()
                {
                    DepartmentName = "部门异常联系人",
                    GroupName = group.GroupName,
                    GroupSort = group.Sort,
                    PersonName = person.PName,
                    Phone = person.PhoneNum
                };
                return model;
            }
            else
            {
                ViewModel.PersonModel model = new ViewModel.PersonModel()
                {
                    DepartmentName = person.P_DepartmentInfo.FirstOrDefault().DepartmentName,
                    GroupName = group.GroupName,
                    GroupSort = group.Sort,
                    PersonName = person.PName,
                    Phone = person.PhoneNum
                };
                return model;
            }
        }
        /// <summary>
        /// 将DB中群组的信息封装为任务TXT需要的模板
        /// </summary>
        /// <param name="group4mission"></param>
        /// <param name="mission"></param>
        /// <returns></returns>
        public static ViewModel.MissionModel getGroup4MissionModelFromDB(R_Group_Mission group4mission, S_SMSMission mission)
        {
            string temp = "bad";
            if (group4mission.isMMS == 0)
            {
                temp = "sms";
            }
            if (group4mission.isMMS == 1)
            {
                temp = "mms";
            }
            ViewModel.MissionModel model = new ViewModel.MissionModel()
            {
                MissionName = mission.SMSMissionName,
                GroupOrDepartment = "g",
                Name = group4mission.P_Group.GroupName,
                MissionSort = mission.Sort,
                MSGType= temp,
                IsPass= group4mission.isPass.ToString()
            };
            return model;
        }
        /// <summary>
        /// 将DB中部门的信息封装为任务TXT需要的模板
        /// </summary>
        /// <param name="group4mission"></param>
        /// <param name="mission"></param>
        /// <returns></returns>
        public static ViewModel.MissionModel getDepartment4MissionModelFromDB(R_Department_Mission department4mission, S_SMSMission mission)
        {
            string temp = "bad";
            if (department4mission.isMMS == 0)
            {
                temp = "sms";
            }
            if (department4mission.isMMS == 1)
            {
                temp = "mms";
            }
            ViewModel.MissionModel model = new ViewModel.MissionModel()
            {
                MissionName = mission.SMSMissionName,
                GroupOrDepartment = "d",
                Name = department4mission.P_DepartmentInfo.DepartmentName,
                MissionSort = mission.Sort,
                //MSGType = department4mission.isMMS==0?"sms":"mms",
                MSGType = temp,
                IsPass = department4mission.isPass.ToString()
            };
            return model;
        }
    }

}
