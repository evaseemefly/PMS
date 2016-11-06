using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IJ_JobInfoBLL
    {

        /// <summary>
        /// 获取全部的作业
        /// </summary>
        /// <returns></returns>
        List<J_JobInfo> GetAllNullDelJobInfo();

        /// <summary>
        /// 根据角色查询该角色拥有的模板（暂未实现）
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<J_JobInfo> GetJobInfoByUser(int uid);

        /// <summary>
        /// 分页查询指定用户或全部用户的
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowCount">返回的总页数</param>
        /// <param name="isAsc">是否降序</param>
        /// <param name="isMiddle">是否转成中间变量</param>
        /// <param name="uid">若不填则默认为-1，查询所有的用户</param>
        /// <returns></returns>
        List<J_JobInfo> GetJobInfoByPage(int pageIndex, int pageSize, ref int rowCount, bool isAsc, bool isMiddle, int uid = -1);

        /// <summary>
        /// 创建作业实例
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddJobInfo(J_JobInfo model);

        /// <summary>
        /// 编辑（暂未实现）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool EditJobInfo();

        /// <summary>
        /// 根据指定id暂停某作业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool PauseJob(int id);

        /// <summary>
        /// 根据id集合批量获取作业集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        List<J_JobInfo> GetListByIds(List<int> list_ids);
        

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        bool DelJobInfo(int JID);

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool PhysicsDel(List<int> list_ids);

        /// <summary>
        /// 还原（不使用此功能）
        /// </summary>
        /// <param name="list_id"></param>
        /// <returns></returns>
        bool Recovery(List<int> list_id);

        bool EditValidation(int id, String name);
    }
}
