using IFactoryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSbackground_QueryMinor
{
    class Program
    {
        static void Main(string[] args)
        {

            IWFBLL bll_minor = WFFactory.AbstractFactory.CreateMinorQuery_WF();

            bll_minor.Execute();

            Console.ReadLine();
        }
    }
}
