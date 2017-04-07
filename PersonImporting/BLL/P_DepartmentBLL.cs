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
        public bool CheckDepartmentRequired()
        {
            //17年2月20日修改：先判断有没有顶级父节点，没有则提示创建(DID为0)
            var department = departmentBLL.GetListBy(g => g.DepartmentName == "顶级父节点").FirstOrDefault();
            if (department == null) { return false; }
                //17年2月20日修改：先判断有没有无归属部门，没有则创建
            var department_Unassigned = departmentBLL.GetListBy(g => g.DepartmentName == "无归属部门").FirstOrDefault();
            if (department_Unassigned == null)
            {
                departmentBLL.Create(new PMS.Model.P_DepartmentInfo()
                {
                    DepartmentName = "无归属部门",
                    Area = 1,
                    PDID = 0,
                    isDel = false,
                });
                
            }
            return true;
        }
        public ExistEnum CheckDepartmentExist(string departmentName)
        {

            //根据群组名称获取群组集合
            //17年2月20日修改：获取无归属部门的DID
            var PDID = departmentBLL.GetListBy(g => g.DepartmentName == "无归属部门").FirstOrDefault().DID;
   
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
                    PDID= PDID,
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
