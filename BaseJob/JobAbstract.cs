using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseJob
{
    public abstract class JobAbstract : IJob
    {
        //protected IUserInfoBLL userInfoBLL { get; set; }

        // protected IJ_JobInfoBLL jobInfoBLL { get; set; }

        // protected IQRTZ_TRIGGERSBLL qrtz_triggerBLL { get; set; }

        public JobAbstract()
        {
            //userInfoBLL = new UserInfoBLL();
            //jobInfoBLL = new J_JobInfoBLL();
            //qrtz_triggerBLL = new QRTZ_TRIGGERSBLL();
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
