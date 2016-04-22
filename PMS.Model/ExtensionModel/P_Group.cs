using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
   public partial class P_Group
    {
        private bool _checked = false;

        /// <summary>
        /// 选中
        /// </summary>
        public bool Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }
        /// <summary>
        /// 将P_Group集合转换为EasyUICombobox集合
        /// </summary>
        /// <param name="list_group"></param>
        /// <returns></returns>
        public static List<EasyUIModel.EasyUICombobox> ToEasyUICombobox(ref List<P_Group> list_group,bool IsChecked)
        {
            List<EasyUIModel.EasyUICombobox> list_combox = new List<EasyUIModel.EasyUICombobox>();
            foreach (var item in list_group)
            {
                EasyUIModel.EasyUICombobox combobox = new EasyUIModel.EasyUICombobox()
                {
                    Checked = IsChecked ? true : false,//此处需要加一个判断，若传入的选中的标记参数为true，true，否则为false
                    id = item.GID,
                    remark = item.Remark,
                    text = item.GroupName,
                    selected = IsChecked ? true : false
                };
                list_combox.Add(combobox);

            }
            return list_combox;
        }
    }
}
