using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.Enum;

namespace PersonImporting.BLL
{
    public class P_PersonBLL
    {
        protected PMS.IBLL.IP_PersonInfoBLL personBLL;

        public P_PersonBLL()
        {
            personBLL = new PMS.BLL.P_PersonInfoBLL();
        }
        public ExistEnum CheckPersonExist(string personName,string phone)
        {
            //根据群组名称获取群组集合
            var personList = personBLL.GetListBy(g => g.PhoneNum == phone).ToList();
            ExistEnum enum_exist = ExistEnum.error;
            //判断集合是否为空
            if (personList.Count() == 0)
            {
                //需要创建
                enum_exist = personBLL.Create(new PMS.Model.P_PersonInfo()
                {
                    PName = personName,
                    PhoneNum = phone,
                    isDel = false,
                    isVIP = false
                }) == true ? ExistEnum.ok : ExistEnum.isExist;
            }
            return enum_exist;
        }

        public bool CreatPersonRelationship(string phone,int gid,int did)
        {
            bool isOk = false;
            //根据电话号码（唯一）查找指定联系人
            isOk = personBLL.UpdatePerson(phone, gid, did);
            #region 8月3日注释掉
            //var list_person = personBLL.GetListBy(p => p.PhoneNum == phone).ToList();
            ////若存在指定联系人
            //if (list_person.Count > 0)
            //{
            //    var pid = list_person.FirstOrDefault().PID;
            //   isOk = personBLL.UpdatePerson(pid, gid, did);
            //}
            #endregion
            return isOk;
        }
    }
}
