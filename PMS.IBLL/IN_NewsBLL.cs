using PMS.Model;
using PMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IN_NewsBLL
    {
        /// <summary>
        /// 根据登录用户查询该用户所拥有的全部消息（未查看、查看了的都算）——分页查询
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="rowCount">总数</param>
        /// <param name="isMiddleint">是否转成中间变量</param>
        /// <param name="index">页码</param>
        /// <param name="count">页容量（可不填，不填默认为-1），为-1则不进行分页查询</param>
        /// <returns></returns>
        List<N_News> GetAllNewsPageListByUser(int uid, ref int rowCount, bool isMiddleint, int index, int count = -1);

        /// <summary>
        /// 获取最近的几个未读消息（最近5个）——未指定类型
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="isMiddleint"></param>
        /// <returns></returns>
        List<N_News> GetRecentUnReadNewsPageListByUser(int uid, bool isMiddleint);

        /// <summary>
        /// 获取最近的几个全部消息（最近5个——含已阅的消息）——未指定类型
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="isMiddleint"></param>
        /// <returns></returns>
        List<N_News> GetRecentAllNewsPageListByUser(int uid, bool isMiddleint);

        /// <summary>
        /// 通过分页查询的方式获取当前登录用户的
        /// 指定类型的消息
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="index">页码</param>
        /// <param name="isMiddleint">是否为中间变量</param>
        /// <param name="type">消息类型</param>
        /// <param name="count">页容量</param>
        /// <returns></returns>
        List<N_News> GetTargetTypeNewsPageListByUser(int uid, int index, bool isMiddleint, int type, int count = -1);

        

        /// <summary>
        /// 根据snid查找对应的News对象以及已经checked的人员集合
        /// </summary>
        /// <param name="snid"></param>
        /// <param name="toMiddle"></param>
        /// <returns></returns>
        ViewModel_News GetNewsBySNID(int snid, bool toMiddle);



        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        bool DelSoftNews(List<int> list_ids);

        /// <summary>
        /// 将指定用户阅读的指定消息设置为已阅状态
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="nid"></param>
        /// <returns></returns>
        bool IsRead(int uid, int nid);
    }
}
