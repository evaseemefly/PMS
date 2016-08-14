using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.EasyUIModel;
using PMS.Model;

namespace Common.EasyUIFormat
{
    public class ToEasyUICombogrid_Group
    {
        /// <summary>
        /// 设置传入的群组集合的选中状态
        /// </summary>
        /// <param name="list_group"></param>
        /// <param name="IsChecked"></param>
        /// <returns></returns>
        public static List<EasyUIDataGrid_Group> ToEasyUIDataGrid(List<P_Group> list_group ,bool IsChecked)
        {

            List<EasyUIDataGrid_Group> list_datagrid = new List<EasyUIDataGrid_Group>();
            foreach (var item in list_group)
            {
                EasyUIDataGrid_Group datagrid = new EasyUIDataGrid_Group()
                {
                    Checked = IsChecked ? true : false,//此处需要加一个判断，若传入的选中的标记参数为true，true，否则为false
                    GID = item.GID,
                    GroupName = item.GroupName,
                    Remark = item.Remark,
                    selected = IsChecked ? true : false,
                    forbidDel = item.forbidDel
                };
                list_datagrid.Add(datagrid);
            }
            return list_datagrid;
        }
    }
}
