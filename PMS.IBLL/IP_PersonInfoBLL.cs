using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IP_PersonInfoBLL
    {
        /// <summary>
        /// 从数据库中根据id集合查询返回指定的PersonInfo集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        List<P_PersonInfo> GetListByIds(List<int> list_ids);

        /// <summary>
        /// 逻辑删除（物理删除）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteLogicPersonInfos(List<int> list);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftPersonInfos(List<int> list_ids);

        /// <summary>
        /// 6月15日新添加
        /// 根据传入的Person ID集合软删除删除该ID集合内的Person对象
        /// 且清除这些Person对象与部门及群组的外键关系
        /// </summary>
        /// <param name="list">Person ID 集合</param>
        /// <returns></returns>
        bool DelSoftPersonAndOtherRelation(List<int> list);


        /// <summary>
        /// 6月15日发现的添加联系人的bug做如下修改
        /// 执行新建联系人的操作
        /// </summary>
        /// <param name="PName"></param>
        /// <param name="PhoneNum"></param>
        /// <param name="list_group_ids"></param>
        /// <param name="id_department"></param>
        /// <returns></returns>
        bool DoAddPerson(string PName, string PhoneNum, List<int> list_group_ids, int id_department);

        /// <summary>
        /// 对指定联系人执行修改操作
        /// </summary>
        /// <param name="pid">联系人ID</param>
        /// <param name="PName">姓名</param>
        /// <param name="PhoneNum">电话号码</param>
        /// <param name="Remark">备注</param>
        /// <param name="isVip"></param>
        /// <param name="isDel"></param>
        /// <param name="list_group_ids">该联系人所拥有的群组id集合</param>
        /// <param name="id_department">该联系人所拥有的部门id</param>
        /// <returns></returns>
        bool DoEditPerson(int pid, string PName, string PhoneNum, string Remark, bool isVip, bool isDel, List<int> list_group_ids, int id_department);

        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的联系人对象
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="list_departmentIds"></param>
        /// <returns></returns>
        bool SetPerson4Department(int personId, List<int> list_departmentIds);

        /// <summary>
        /// 将传入的部门id集合赋给传入的Id对应的联系人对象
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="list_departmentIds"></param>
        /// <returns></returns>
        bool SetPerson4Group(int personId, List<int> list_groupIds);

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        bool AddValidation(String phoneNum);
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        bool EditValidation(int id, String phoneNum);
    }
}
