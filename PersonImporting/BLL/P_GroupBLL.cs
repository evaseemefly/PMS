using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.Enum;

namespace PersonImporting.BLL
{
   public class P_GroupBLL:DBBaseBLL
    {
        protected PMS.IBLL.IP_GroupBLL groupBLL;

        public P_GroupBLL()
        {
            groupBLL = new PMS.BLL.P_GroupBLL();
        }
        public ExistEnum CheckGroupExist(string groupName,int sort)
        {
            //根据群组名称获取群组集合
            var groupList= groupBLL.GetListBy(g => g.GroupName == groupName).ToList();
            ExistEnum enum_exist=ExistEnum.error;
            //判断集合是否为空
            if (groupList.Count() == 0)
            {
                //需要创建
                enum_exist = groupBLL.Create(new PMS.Model.P_Group()
                {
                    GroupName = groupName,
                    Sort = sort,
                    SubTime = DateTime.Now,
                    ModifiedOnTime = DateTime.Now,
                    isDel = false,
                    forbidDel = false
                }) == true ? ExistEnum.ok : ExistEnum.isExist;
            }
            return enum_exist;
        }
        /// <summary>
        /// 根据群组名称得到Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetGroupId(string name)
        {
            return groupBLL.GetListBy(p => p.GroupName.Equals(name)).FirstOrDefault().GID;
        }
    }
}
