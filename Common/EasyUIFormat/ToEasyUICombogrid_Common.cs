using PMS.Model;
using PMS.Model.EasyUIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EasyUIFormat
{
    public class ToEasyUICombogrid_Common
    {
        /// <summary>
        /// 设置传入的群组集合的选中状态
        /// </summary>
        /// <param name="list_group"></param>
        /// <param name="IsChecked"></param>
        /// <returns></returns>
        public static List<EasyUICombobox> ToEasyUIDataGrid(Dictionary<int,string> dic, bool IsChecked)
        {

            List<EasyUICombobox> list_combobox = new List<EasyUICombobox>();
            foreach (var item in dic)
            {
                EasyUICombobox combo = new EasyUICombobox()
                {
                    Checked = IsChecked ? true : false,//此处需要加一个判断，若传入的选中的标记参数为true，true，否则为false
                    id = item.Key,
                    text = item.Value,
                    remark = null,
                    selected = false
                };
                list_combobox.Add(combo);
            }
            return list_combobox;
        }
    }
}
