using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace SendJob
{
    public delegate bool DoJobDelegate(PMS.Model.ViewModel.ViewModel_Message msg);

   public class JobManagement
    {
        public event DoJobDelegate DoJobs;

        public void JobsRun(PMS.Model.ViewModel.ViewModel_Message msg)
        {
            if (DoJobs != null)
            {
                DoJobs(msg);
            }
        }
    }
}
