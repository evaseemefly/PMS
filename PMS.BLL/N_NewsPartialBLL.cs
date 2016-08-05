using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public partial class N_NewsBLL
    {
        //继续拓展消息类

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
        public List<N_News> GetTargetTypeNewsPageListByUser(int uid, int index, bool isMiddleint, int type, int count = -1)
        {
            //1 根据用户查找对应的消息对象
            var list_newsByUser = GetBaseAllNewsList(uid);

            if (count == -1)
            {

            }
            else
            {
                list_newsByUser = list_newsByUser.Where(n => n.NewsType == type).Skip((index - 1) * count).Take(count);
                //判断是否要转换成中间变量集合
                if (isMiddleint)
                {
                    list_newsByUser = list_newsByUser.Select(r => r.ToMiddleModel());

                }
                else
                {

                }
            }
            return list_newsByUser.ToList();
        }

        /// <summary>
        /// 根据登录用户查询该用户所拥有的全部消息（未查看、查看了的都算）——分页查询
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="index">页码</param>
        /// <param name="isMiddleint"></param>
        /// <param name="count">页容量（可不填，不填默认为-1），为-1则不进行分页查询</param>
        /// <returns></returns>
        public List<N_News> GetAllNewsPageListByUser(int uid, int index, bool isMiddleint, int count = -1)
        {
            //2 根据用户查找对应的消息对象
            var list_newsByUser = GetBaseAllNewsList(uid);

            if (count == -1)
            {

            }
            else
            {
                list_newsByUser = list_newsByUser.Skip((index - 1) * count).Take(count);
                //判断是否要转换成中间变量集合
                if (isMiddleint)
                {
                    list_newsByUser = list_newsByUser.Select(r => r.ToMiddleModel());
                    //list_newsByUser = (from r in user.R_UserInfo_News

                    //                   orderby r.ID
                    //                   select r.N_News.ToMiddleModel()).OrderByDescending(r => r.SubDateTime).Skip(index - 1 * count).Take(count).ToList();
                }
                else
                {
                    //list_newsByUser = (from r in user.R_UserInfo_News

                    //                   orderby r.ID
                    //                   select r.N_News).OrderByDescending(r => r.SubDateTime).Skip(index - 1 * count).Take(count).ToList();

                }
            }

            //
            //var list_news= this.GetPageList(1, count, n => n.isDel == false, u => u.SubDateTime, false).ToList().Select(n=>n.ToMiddleModel()).ToList();
            return list_newsByUser.ToList();
        }
    }
}
