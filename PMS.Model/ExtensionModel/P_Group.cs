using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
   public partial class P_Group
    {
        /// <summary>
        /// 将P_Group集合转换为EasyUICombobox集合
        /// </summary>
        /// <param name="list_group"></param>
        /// <returns></returns>
        public static List<EasyUIModel.EasyUICombobox> ToEasyUICombobox(List<P_Group> list_group )
        {
            List<EasyUIModel.EasyUICombobox> list_combox = new List<EasyUIModel.EasyUICombobox>();
            foreach (var item in list_group)
            {
                EasyUIModel.EasyUICombobox combobox = new EasyUIModel.EasyUICombobox()
                {
                    id = item.GID,
                    remark = item.Remark,
                    text = item.GroupName
                };
                list_combox.Add(combobox);

            }
            return list_combox;
        }
    }
}
