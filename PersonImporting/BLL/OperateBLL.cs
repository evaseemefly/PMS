using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    }
}
