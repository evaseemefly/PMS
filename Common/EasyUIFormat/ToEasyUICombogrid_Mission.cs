using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.EasyUIModel;
using PMS.Model;

namespace Common.EasyUIFormat
{
   public class ToEasyUICombogrid_Mission
    {
        /// <summary>
        /// 设置传入的任务集合的选中状态
        /// </summary>
        /// <param name="list_mission"></param>
        /// <param name="IsChecked"></param>
        /// <returns></returns>
        public static List<EasyUIDataGrid_Mission> ToEasyUIDataGrid(List<S_SMSMission> list_mission, bool IsChecked)
        {

            List<EasyUIDataGrid_Mission> list_datagrid = new List<EasyUIDataGrid_Mission>();
            foreach (var item in list_mission)
            {
                EasyUIDataGrid_Mission datagrid = new EasyUIDataGrid_Mission()
                {
                    Checked = IsChecked ? true : false,//此处需要加一个判断，若传入的选中的标记参数为true，true，否则为false
                    SMID = item.SMID,
                    SMSMissionName = item.SMSMissionName,
                    Remark = item.Remark,
                    Sort = item.Sort,
                    selected = IsChecked ? true : false
                };
                list_datagrid.Add(datagrid);

            }
            return list_datagrid;
        }
    }
}
