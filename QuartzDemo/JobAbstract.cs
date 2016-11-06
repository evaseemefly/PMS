using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.IBLL;
using PMS.BLL;

namespace QuartzDemo
{
    public abstract class JobAbstract : IJob
    {
       protected IUserInfoBLL userInfoBLL { get; set; }

        protected IJ_JobInfoBLL jobInfoBLL { get; set; }

        public JobAbstract()
        {
            userInfoBLL = new UserInfoBLL();
            jobInfoBLL = new J_JobInfoBLL();
        }

        public void Execute(IJobExecutionContext context)
        {
            ExceuteBody(context);
            Exceuted(context);
        }

       protected abstract void ExceuteBody(IJobExecutionContext context);

        protected abstract void Exceuted(IJobExecutionContext context);
    }
}
