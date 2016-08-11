using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.Dictionary
{
    public class RecycledTypeDictonary
    {
        private static Dictionary<int, string> recycledType;

        public static Dictionary<int, string> GetRecycledTypeCode()
        {
            return recycledType;
        }

        static RecycledTypeDictonary()
        {
            recycledType = new Dictionary<int, string>();
            recycledType.Add(1, "用户");
            recycledType.Add(2, "角色");
            recycledType.Add(3, "权限");
            recycledType.Add(4, "群组");
            recycledType.Add(5, "部门");
            recycledType.Add(6, "任务");
        }
    }
}
