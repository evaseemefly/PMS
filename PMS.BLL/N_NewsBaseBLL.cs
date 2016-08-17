using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.ViewModel;
using PMS.IBLL;

namespace PMS.BLL
{
    public partial class N_NewsBLL: IBaseDelBLL
    {
        /// <summary>
        /// 查询该id登录的用户所拥有的全部消息列表
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        protected IEnumerable<N_News> GetBaseAllNewsList(int uid)
        {
            //1 根据传入的uid查询指定 的用户
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID == uid).FirstOrDefault();

            //2 根据用户查找对应的消息对象
            var list_newsByUser = (from r in user.R_UserInfo_News
                                   orderby r.ID
                                   select r.N_News).OrderByDescending(r => r.SubDateTime);
            return list_newsByUser;
        }

        /// <summary>
        /// 查询该用户id的全部未阅读消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        protected IEnumerable<N_News> GetAllUnReadNewsList(int uid)
        {
            //1 根据传入的uid查询指定 的用户
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID == uid).FirstOrDefault();

            //2 根据用户查找对应的消息对象
            var list_newsByUser = (from r in user.R_UserInfo_News
                                   where r.isCheck==false
                                   orderby r.ID
                                   select r.N_News).OrderByDescending(r => r.SubDateTime);
            return list_newsByUser;

        }

        public bool PhysicsDel(List<int> list_ids)
        {
            return true;
        }

        /// <summary>
        /// 根据id查找对应的News对象
        /// </summary>
        /// <param name="snid"></param>
        /// <returns></returns>
        public ViewModel_News GetNewsBySNID(int snid,bool toMiddle)
        {
            //1 根据id查询news对象
            var news = this.GetListBy(n => n.SNID == snid).FirstOrDefault();
            //2 获取已经查看的（isCheck=true）的用户集合
            var list_checkedUser = news.R_UserInfo_News.Where(n => n.isCheck == true).Select(r=>r.UserInfo).ToList();
            //3 是否需要转换成中间标量
            if (toMiddle)
            {
                list_checkedUser = list_checkedUser.Select(u => u.ToMiddleModel()).ToList();
            }
            return new ViewModel_News
            {
                SNID = snid,
                NewsType = news.NewsType,
                Title = news.Title,
                NewsContent = news.NewsContent,
                SubDateTime = news.SubDateTime,
                list_User = list_checkedUser
            };

        }

        public bool Recovery(List<int> list_ids)
        {
            throw new NotImplementedException();
        }
    }
}
