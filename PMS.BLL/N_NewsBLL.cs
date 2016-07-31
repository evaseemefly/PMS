using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.BLL
{
    public partial class N_NewsBLL
    {
        //
        public List<N_News> GetAllNewsListByUser(int uid,int count)
        {
            //1 根据传入的uid查询指定 的用户
            var user = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID==uid).FirstOrDefault();
            //2 根据用户查找对应的消息对象
           var list_news= this.GetPageList(0, count, n => n.isDel == true, u => u.SubDateTime, false).ToList();
            return list_news;
        }
    }
}
