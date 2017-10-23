using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;

namespace QueryWFLib
{
    public abstract class BaseCodeActivity : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            MyExecute(context);
        }

        protected void LogIn(Action action)
        {

        }

        protected abstract void MyExecute(CodeActivityContext context);
    }
}

