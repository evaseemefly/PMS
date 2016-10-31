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
                var uid = data.GetInt("UID");
                if (uid != null)
                {
                    //var uid_int = int.Parse(uid);
                   var user_temp= userInfoBLL.GetListBy(u => u.ID == uid).FirstOrDefault();
                    //2 根据用户id查询查询该用户所拥有的作业
                    //userInfoBLL
                   var list= userInfoBLL.GetJobListByUser(user_temp.ID);

                    
                    //3 取出对应的作业
                    var targetJob = (from j in list
                                     where j.JobName == context.JobDetail.Key.Name && j.JobGroup == context.JobDetail.Key.Group
                                     select j).FirstOrDefault();

                    //4 若存在则更新作业状态
                    if (targetJob != null)
                    {
                       var job_temp= base.jobInfoBLL.GetListBy(j => j.JobName == targetJob.JobName && j.JobGroup == targetJob.JobGroup).FirstOrDefault();
                        //job_temp.JobState=
                        //base.jobInfoBLL.Update()
                    }
                    //4 若不存在则创建新的作业
                }

            }
            
        }
    }
}
