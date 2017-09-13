using PersonImporting.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerSys
{
    public partial class GroupManagment : Form
    {
        public GroupManagment()
        {
            InitializeComponent();
        }
        static P_GroupBLL groupBLL = new P_GroupBLL();
        private void GroupManagment_Load(object sender, EventArgs e)
        {
            var groupList = groupBLL.getGroupList();
            dataGridView1.DataSource = groupList;
            LT1.Text = "共 " + groupList.Count().ToString() + " 条记录";
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int GID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //查找所属的联系人
            var belongingPersonList = groupBLL.GetBelongingPerson(GID);
            dataGridView3.DataSource = belongingPersonList;
            LT3.Text = "共 " + belongingPersonList.Count().ToString() + " 条记录";
            //查找归属的任务
            var belongingMissionList = groupBLL.GetBelongMission(GID);
            dataGridView2.DataSource = belongingMissionList;
            LT2.Text = "共 " + belongingMissionList.Count().ToString() + " 条记录";
        }
    }
}
