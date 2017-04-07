using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace ConfigManager
{
    class Program
    {
        static void Main(string[] args)
        {

            //var config= MyConfig.GetConfig();
            //方法一：可行
            // ConfigSection config = (ConfigSection)ConfigurationManager.GetSection("mysection");
            //方法二：
            var config= ConfigSection.GetConfig();

            Console.ReadLine();
        }

        
    }
}
