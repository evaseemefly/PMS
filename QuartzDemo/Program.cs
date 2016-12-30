using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartzJobFactory;
using PMS.Model;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString());
            //InDBExmaple example = new InDBExmaple();
            //example.Run();
            //无法通过WCF的方式使用反射的对象
            //ServiceReference_Job.IJobService jobSer = new ServiceReference_Job.JobServiceClient();
            PMS.BLL.J_JobInfoBLL job_temp = new PMS.BLL.J_JobInfoBLL();
            var temp =job_temp.GetListBy(j => j.JID == 36).FirstOrDefault();


            temp.JobState = 1;

            PMS.BLL.UserInfoBLL userBLL = new PMS.BLL.UserInfoBLL();
            var user_temp = userBLL.GetListBy(u => u.ID == 3).FirstOrDefault();
            var list = userBLL.GetJobListByUser(user_temp.ID);
            var targetJob = (from j in list
                             where j.JID ==41 
                             select j).FirstOrDefault();
            if (targetJob != null)
            {
                    targetJob.JobState = 1;
                  
            }            
            job_temp.Update(temp);
            //11月8日测试更新数据库，暂时注释掉
            //IJobService jobSer = new JobService();
            //var job_id = "test1" + Guid.NewGuid().ToString();
            //var job_group = "group1";
            //J_JobInfo job = new J_JobInfo()
            //{
            //    JobName = job_id,
            //    JobGroup = job_group,
            //    JobClassName = "HelloJob",
            //    StartRunTime = DateTime.Now.AddSeconds(2),
            //    EndRunTime = DateTime.Now.AddSeconds(3),
            //    UID = 3
            //};
            //jobSer.AddScheduleJob(job);


            //MyJobListener listener = new MyJobListener();
            //jobSer.AddListener(listener, job_id, job_group);
            //jobSer.ResumeAllJob();
            Console.ReadLine();
        }
    }
}
