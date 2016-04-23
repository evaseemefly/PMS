using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
   public partial class P_DepartmentInfo
    {
        /// <summary>
        /// 将P_Department集合转换为EasyUICombobox集合
        /// </summary>
        /// <param name="list_group"></param>
        /// <returns></returns>
        public static List<EasyUIModel.EasyUICombobox> ToEasyUICombobox(ref List<P_DepartmentInfo> list_department, bool IsChecked)
        {
            List<EasyUIModel.EasyUICombobox> list_combox = new List<EasyUIModel.EasyUICombobox>();
            foreach (var item in list_department)
            {
                EasyUIModel.EasyUICombobox combobox = new EasyUIModel.EasyUICombobox()
                {
                    Checked = IsChecked ? true : false,//此处需要加一个判断，若传入的选中的标记参数为true，true，否则为false
                    id = item.DID,
                    remark = item.Remark,
                    text = item.DepartmentName,
                    selected = IsChecked ? true : false
                };
                list_combox.Add(combobox);

            }
            return list_combox;
        }
    }
}
