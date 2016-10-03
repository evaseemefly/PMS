using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Common;
using RedisFactory;
using System.Activities;
using WFTest;

namespace WFFactory
{
    public class MinorQuery_WF : BaseQuery_WF
    {
        //protected QueryHelper query_helper = new QueryHelper();
        //第二次查询时使用到的读写redis的方法类
        protected MinorQueryRedisBLL query_bll = new MinorQueryRedisBLL();

        /// <summary>
        /// 第二次查询的工作流方法
        /// </summary>
        public override void Execute()
        {
            //从redis中查询准备恢复的wf_id
            string wf_id= query_bll.ExecuteQueryGetWFId();
            //3.2 恢复工作流
            Activity workflow_temp = new MainStatistics_Advanced();

            //恢复工作流
            var work_reus = WorkFlowAppHelper.LoadWorkflowApplication(workflow_temp, Guid.Parse(wf_id));

            //3.3 读取WF_Query_Instance表根据指定WF_Id取出对应的State、StepId、WF_Result（或从hash中读取）！！！！！
            var bookmark = new PMS.Model.WFModel.BookMarkObj<int>()
            {
                BookMarkName = "恢复书签",
                State = 1,
                StepId = 1,
                WF_Result = 6
            };
            work_reus.ResumeBookmark("书签1", bookmark);
        }
    }
}
