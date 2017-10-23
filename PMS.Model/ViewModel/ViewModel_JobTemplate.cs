using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
    public class ViewModel_JobTemplate
    {
        public string JobGroup { get; set; }
        public string JTName { get; set; }
        public int JTID { get; set; }
        public string JobClassName { get; set; }
        public string CronStr { get; set; }
        public int JobType { get; set; }
        public string Remark { get; set; }
        public bool isDel { get; set; }
    }
}
