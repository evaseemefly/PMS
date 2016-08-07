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

        /// <summary>
        /// 将DB中联系人的信息封装为TXT需要的模板
        /// </summary>
        /// <param name="person"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static ViewModel.PersonModel getPersonModelFromDB(P_PersonInfo person, P_Group group)
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

}
