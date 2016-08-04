using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
    public partial class N_NewsBLL
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
        /// 根据登录用户查询该用户所拥有的全部消息（未查看、查看了的都算）——分页查询
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="index">页码</param>
        /// <param name="isMiddleint"></param>
        /// <param name="count">页容量（可不填，不填默认为-1），为-1则不进行分页查询</param>
        /// <returns></returns>
        public List<N_News> GetAllNewsPageListByUser(int uid,int index, bool isMiddleint,int count=-1)
        {
            //1 根据传入的uid查询指定 的用户
            //var user = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID==uid).FirstOrDefault();

            //2 根据用户查找对应的消息对象
            
           var list_newsByUser= GetBaseAllNewsList(uid);

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

        public List<N_News> GetTargetTypeNewsPageListByUser(int uid, int index, bool isMiddleint,int type, int count = -1)
        {            
            //1 根据用户查找对应的消息对象
            var list_newsByUser = GetBaseAllNewsList(uid);

            if (count == -1)
            {

            }
            else
            {
                list_newsByUser = list_newsByUser.Where(n=>n.NewsType==type).Skip((index - 1) * count).Take(count);
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
    }
}
