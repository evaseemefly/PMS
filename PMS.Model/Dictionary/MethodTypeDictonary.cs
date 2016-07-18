using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    public class MethodTypeDictonary
    {
        private static Dictionary<int, string> methodType;

        public static Dictionary<int,string> GetMethodTypeCode()
        {
            return methodType;
        }

        static MethodTypeDictonary()
        {
            methodType = new Dictionary<int, string>();
            methodType.Add(1, "普通权限");
            methodType.Add(2, "编辑当前toolbar权限");
            methodType.Add(3, "编辑联系人toolbar权限");
        }
    }
}
