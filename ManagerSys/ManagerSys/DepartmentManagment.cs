using ManagerSys.BLL;
using ManagerSys.ViewModel;
using PersonImporting.BLL;
using PersonImporting.ViewModel;
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
    public partial class DepartmentManagment : Form
    {
        //protected static DepartmentBLL departmentBLL { get; set; };// = new DepartmentBLL();
        public DepartmentManagment()
        {
            InitializeComponent();
        }
        static P_DepartmentBLL departmentBLL = new P_DepartmentBLL();
        private void DepartmentManagment_Load(object sender, EventArgs e)
        {
            var departmentList = departmentBLL.GetDeparments();
            dataGridView1.DataSource = departmentList;
            LT1.Text = "共 " + departmentList.Count().ToString() + " 条记录";
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int PID = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            int DID = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            textBox1.Text = departmentBLL.GetDepartmentName(PID);
            var sonDepartmentsList = departmentBLL.GetSonDeparments(DID);
            dataGridView2.DataSource = sonDepartmentsList;
            LT2.Text = "共 " + sonDepartmentsList.Count().ToString() + " 条记录";
            //查找所属的联系人
            var belongingPersonList = departmentBLL.GetBelongingPerson(DID);
            dataGridView3.DataSource = belongingPersonList;
            LT3.Text = "共 " + belongingPersonList.Count().ToString() + " 条记录";
            //查找归属的任务
            var belongingMissionList = departmentBLL.GetBelongMission(DID);
            dataGridView4.DataSource = belongingMissionList;
            LT4.Text = "共 " + belongingMissionList.Count().ToString() + " 条记录";

        }
    }
}
