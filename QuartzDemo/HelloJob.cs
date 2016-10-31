using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    public  class HelloJob : JobAbstract
    {       

        protected override void ExceuteBody(IJobExecutionContext context)
        {
            Console.WriteLine("————————Hello Job is Execute,this time is {0}————————", DateTime.Now.ToString());
        }

        protected override void Exceuted(IJobExecutionContext context)
        {
            //向数据库中写入
            //获取JobDataMap
            var data = context.JobDetail.JobDataMap;
            //1 需要传入一个用户id
            if (base.userInfoBLL != null)
            {
                var uid = data.GetString("UID");
                if (uid != null)
                {
                   var user_temp= userInfoBLL.GetListBy(u => u.ID == int.Parse(uid)).FirstOrDefault();
                    //2 根据用户id查询查询该用户所拥有的作业
                    //userInfoBLL
                   var list= userInfoBLL.GetJobListByUser(user_temp.ID);
                    //3 若存在则更新作业状态
                    //4 若不存在则创建新的作业
                }

            }
            
        }
    }
}
