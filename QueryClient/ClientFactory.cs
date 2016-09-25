using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IFactoryBLL;
using Spring.Context;
using Spring.Context.Support;

namespace QueryClient
{
    public class ClientFactory
    {
        IWFBLL wf_bll { get; set; }
        IApplicationContext ctx = ContextRegistry.GetContext();
        public ClientFactory(int index)
        {
            switch (index)
            {
                case 1:
                    CreateFirstQuery_WF();
                    break;
                case 2:
                    CreateMinorQuery_WF();
                    break;
                default:
                    break;
            }
            //wf_bll =ctx.GetObject("")
        }

        private void CreateFirstQuery_WF()
        {
            //wf_bll = ctx.GetObject("wf_bll") as IWFBLL;
            wf_bll = ctx.GetObject("firstQueryServer") as IWFBLL;
        }

        private void CreateMinorQuery_WF()
        {
            wf_bll = ctx.GetObject("minorQueryServer") as IWFBLL;
        }

        public void Execute()
        {
            wf_bll.Execute();
        }
    }
}
