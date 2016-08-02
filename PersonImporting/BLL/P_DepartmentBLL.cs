using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.Enum;

namespace PersonImporting.BLL
{
    public class P_DepartmentBLL
    {
        protected PMS.IBLL.IP_DepartmentInfoBLL departmentBLL;

        public P_DepartmentBLL()
        {
            departmentBLL = new PMS.BLL.P_DepartmentInfoBLL();
        }
        public ExistEnum CheckDepartmentExist(string departmentName)
        {
            //根据群组名称获取群组集合
            var groupList = departmentBLL.GetListBy(g => g.DepartmentName == departmentName).ToList();
            ExistEnum enum_exist = ExistEnum.error;
            //判断集合是否为空
            if (groupList.Count() == 0)
            {
                //需要创建
                enum_exist = departmentBLL.Create(new PMS.Model.P_DepartmentInfo()
                {

                    DepartmentName = departmentName,
                    Area=1,
                    PDID= 1032,
                    isDel = false,
                }) == true ? ExistEnum.ok : ExistEnum.isExist;
            }
            return enum_exist;
        }

        /// <summary>
        /// 根据部门名称得到Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetDepartmentId(string name)
        {
            return departmentBLL.GetListBy(p => p.DepartmentName.Equals(name)).FirstOrDefault().DID;
        }
    }
}
