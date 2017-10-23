namespace ManagerSys
{
    partial class DepartmentManagment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.departmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDelDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDepartmentInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.departmentNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDelDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.pIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVIPDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isDelDataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pPersonInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.sMIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMSMissionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedOnTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDelDataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isMMSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSMissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.LT2 = new System.Windows.Forms.Label();
            this.LT4 = new System.Windows.Forms.Label();
            this.LT1 = new System.Windows.Forms.Label();
            this.LT3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDepartmentInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPersonInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentNameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.dIDDataGridViewTextBoxColumn,
            this.pDIDDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.isDelDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.pDepartmentInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(301, 608);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // departmentNameDataGridViewTextBoxColumn
            // 
            this.departmentNameDataGridViewTextBoxColumn.DataPropertyName = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.HeaderText = "部门名称";
            this.departmentNameDataGridViewTextBoxColumn.Name = "departmentNameDataGridViewTextBoxColumn";
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            // 
            // dIDDataGridViewTextBoxColumn
            // 
            this.dIDDataGridViewTextBoxColumn.DataPropertyName = "DID";
            this.dIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.dIDDataGridViewTextBoxColumn.Name = "dIDDataGridViewTextBoxColumn";
            // 
            // pDIDDataGridViewTextBoxColumn
            // 
            this.pDIDDataGridViewTextBoxColumn.DataPropertyName = "PDID";
            this.pDIDDataGridViewTextBoxColumn.HeaderText = "父节点ID";
            this.pDIDDataGridViewTextBoxColumn.Name = "pDIDDataGridViewTextBoxColumn";
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "Area";
            this.areaDataGridViewTextBoxColumn.HeaderText = "所属地区";
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            // 
            // isDelDataGridViewCheckBoxColumn
            // 
            this.isDelDataGridViewCheckBoxColumn.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn.HeaderText = "删除标记";
            this.isDelDataGridViewCheckBoxColumn.Name = "isDelDataGridViewCheckBoxColumn";
            // 
            // pDepartmentInfoBindingSource
            // 
            this.pDepartmentInfoBindingSource.DataSource = typeof(PMS.Model.P_DepartmentInfo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "父节点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "子节点";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "成员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "所属任务";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(391, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 21);
            this.textBox1.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentNameDataGridViewTextBoxColumn1,
            this.remarkDataGridViewTextBoxColumn1,
            this.dIDDataGridViewTextBoxColumn1,
            this.pDIDDataGridViewTextBoxColumn1,
            this.areaDataGridViewTextBoxColumn1,
            this.isDelDataGridViewCheckBoxColumn1});
            this.dataGridView2.DataSource = this.pDepartmentInfoBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(391, 74);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(305, 317);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // departmentNameDataGridViewTextBoxColumn1
            // 
            this.departmentNameDataGridViewTextBoxColumn1.DataPropertyName = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn1.HeaderText = "部门名称";
            this.departmentNameDataGridViewTextBoxColumn1.Name = "departmentNameDataGridViewTextBoxColumn1";
            // 
            // remarkDataGridViewTextBoxColumn1
            // 
            this.remarkDataGridViewTextBoxColumn1.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn1.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn1.Name = "remarkDataGridViewTextBoxColumn1";
            // 
            // dIDDataGridViewTextBoxColumn1
            // 
            this.dIDDataGridViewTextBoxColumn1.DataPropertyName = "DID";
            this.dIDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dIDDataGridViewTextBoxColumn1.Name = "dIDDataGridViewTextBoxColumn1";
            // 
            // pDIDDataGridViewTextBoxColumn1
            // 
            this.pDIDDataGridViewTextBoxColumn1.DataPropertyName = "PDID";
            this.pDIDDataGridViewTextBoxColumn1.HeaderText = "父节点ID";
            this.pDIDDataGridViewTextBoxColumn1.Name = "pDIDDataGridViewTextBoxColumn1";
            // 
            // areaDataGridViewTextBoxColumn1
            // 
            this.areaDataGridViewTextBoxColumn1.DataPropertyName = "Area";
            this.areaDataGridViewTextBoxColumn1.HeaderText = "所属地区";
            this.areaDataGridViewTextBoxColumn1.Name = "areaDataGridViewTextBoxColumn1";
            // 
            // isDelDataGridViewCheckBoxColumn1
            // 
            this.isDelDataGridViewCheckBoxColumn1.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn1.HeaderText = "删除标记";
            this.isDelDataGridViewCheckBoxColumn1.Name = "isDelDataGridViewCheckBoxColumn1";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pIDDataGridViewTextBoxColumn1,
            this.pNameDataGridViewTextBoxColumn1,
            this.phoneNumDataGridViewTextBoxColumn1,
            this.remarkDataGridViewTextBoxColumn3,
            this.isVIPDataGridViewCheckBoxColumn1,
            this.isDelDataGridViewCheckBoxColumn3});
            this.dataGridView3.DataSource = this.pPersonInfoBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(749, 44);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(350, 598);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // pIDDataGridViewTextBoxColumn1
            // 
            this.pIDDataGridViewTextBoxColumn1.DataPropertyName = "PID";
            this.pIDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.pIDDataGridViewTextBoxColumn1.Name = "pIDDataGridViewTextBoxColumn1";
            this.pIDDataGridViewTextBoxColumn1.Width = 50;
            // 
            // pNameDataGridViewTextBoxColumn1
            // 
            this.pNameDataGridViewTextBoxColumn1.DataPropertyName = "PName";
            this.pNameDataGridViewTextBoxColumn1.HeaderText = "姓名";
            this.pNameDataGridViewTextBoxColumn1.Name = "pNameDataGridViewTextBoxColumn1";
            // 
            // phoneNumDataGridViewTextBoxColumn1
            // 
            this.phoneNumDataGridViewTextBoxColumn1.DataPropertyName = "PhoneNum";
            this.phoneNumDataGridViewTextBoxColumn1.HeaderText = "号码";
            this.phoneNumDataGridViewTextBoxColumn1.Name = "phoneNumDataGridViewTextBoxColumn1";
            // 
            // remarkDataGridViewTextBoxColumn3
            // 
            this.remarkDataGridViewTextBoxColumn3.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn3.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn3.Name = "remarkDataGridViewTextBoxColumn3";
            // 
            // isVIPDataGridViewCheckBoxColumn1
            // 
            this.isVIPDataGridViewCheckBoxColumn1.DataPropertyName = "isVIP";
            this.isVIPDataGridViewCheckBoxColumn1.HeaderText = "VIP";
            this.isVIPDataGridViewCheckBoxColumn1.Name = "isVIPDataGridViewCheckBoxColumn1";
            // 
            // isDelDataGridViewCheckBoxColumn3
            // 
            this.isDelDataGridViewCheckBoxColumn3.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn3.HeaderText = "删除标记";
            this.isDelDataGridViewCheckBoxColumn3.Name = "isDelDataGridViewCheckBoxColumn3";
            // 
            // pPersonInfoBindingSource
            // 
            this.pPersonInfoBindingSource.DataSource = typeof(PMS.Model.P_PersonInfo);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMIDDataGridViewTextBoxColumn,
            this.sMSMissionNameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn2,
            this.subTimeDataGridViewTextBoxColumn,
            this.modifiedOnTimeDataGridViewTextBoxColumn,
            this.isDelDataGridViewCheckBoxColumn2,
            this.isMMSDataGridViewCheckBoxColumn,
            this.sortDataGridViewTextBoxColumn});
            this.dataGridView4.DataSource = this.sSMSMissionBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(391, 445);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 23;
            this.dataGridView4.Size = new System.Drawing.Size(305, 197);
            this.dataGridView4.TabIndex = 0;
            this.dataGridView4.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // sMIDDataGridViewTextBoxColumn
            // 
            this.sMIDDataGridViewTextBoxColumn.DataPropertyName = "SMID";
            this.sMIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.sMIDDataGridViewTextBoxColumn.Name = "sMIDDataGridViewTextBoxColumn";
            this.sMIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // sMSMissionNameDataGridViewTextBoxColumn
            // 
            this.sMSMissionNameDataGridViewTextBoxColumn.DataPropertyName = "SMSMissionName";
            this.sMSMissionNameDataGridViewTextBoxColumn.HeaderText = "任务名";
            this.sMSMissionNameDataGridViewTextBoxColumn.Name = "sMSMissionNameDataGridViewTextBoxColumn";
            // 
            // remarkDataGridViewTextBoxColumn2
            // 
            this.remarkDataGridViewTextBoxColumn2.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn2.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn2.Name = "remarkDataGridViewTextBoxColumn2";
            // 
            // subTimeDataGridViewTextBoxColumn
            // 
            this.subTimeDataGridViewTextBoxColumn.DataPropertyName = "SubTime";
            this.subTimeDataGridViewTextBoxColumn.HeaderText = "SubTime";
            this.subTimeDataGridViewTextBoxColumn.Name = "subTimeDataGridViewTextBoxColumn";
            // 
            // modifiedOnTimeDataGridViewTextBoxColumn
            // 
            this.modifiedOnTimeDataGridViewTextBoxColumn.DataPropertyName = "ModifiedOnTime";
            this.modifiedOnTimeDataGridViewTextBoxColumn.HeaderText = "ModifiedOnTime";
            this.modifiedOnTimeDataGridViewTextBoxColumn.Name = "modifiedOnTimeDataGridViewTextBoxColumn";
            // 
            // isDelDataGridViewCheckBoxColumn2
            // 
            this.isDelDataGridViewCheckBoxColumn2.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn2.HeaderText = "isDel";
            this.isDelDataGridViewCheckBoxColumn2.Name = "isDelDataGridViewCheckBoxColumn2";
            // 
            // isMMSDataGridViewCheckBoxColumn
            // 
            this.isMMSDataGridViewCheckBoxColumn.DataPropertyName = "isMMS";
            this.isMMSDataGridViewCheckBoxColumn.HeaderText = "isMMS";
            this.isMMSDataGridViewCheckBoxColumn.Name = "isMMSDataGridViewCheckBoxColumn";
            // 
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "Sort";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            // 
            // sSMSMissionBindingSource
            // 
            this.sSMSMissionBindingSource.DataSource = typeof(PMS.Model.S_SMSMission);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 745);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "所属任务";
            // 
            // LT2
            // 
            this.LT2.AutoSize = true;
            this.LT2.Location = new System.Drawing.Point(389, 403);
            this.LT2.Name = "LT2";
            this.LT2.Size = new System.Drawing.Size(17, 12);
            this.LT2.TabIndex = 1;
            this.LT2.Text = "条";
            // 
            // LT4
            // 
            this.LT4.AutoSize = true;
            this.LT4.Location = new System.Drawing.Point(389, 646);
            this.LT4.Name = "LT4";
            this.LT4.Size = new System.Drawing.Size(17, 12);
            this.LT4.TabIndex = 1;
            this.LT4.Text = "条";
            // 
            // LT1
            // 
            this.LT1.AutoSize = true;
            this.LT1.Location = new System.Drawing.Point(12, 646);
            this.LT1.Name = "LT1";
            this.LT1.Size = new System.Drawing.Size(17, 12);
            this.LT1.TabIndex = 1;
            this.LT1.Text = "条";
            // 
            // LT3
            // 
            this.LT3.AutoSize = true;
            this.LT3.Location = new System.Drawing.Point(747, 646);
            this.LT3.Name = "LT3";
            this.LT3.Size = new System.Drawing.Size(17, 12);
            this.LT3.TabIndex = 1;
            this.LT3.Text = "条";
            // 
            // DepartmentManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 667);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LT1);
            this.Controls.Add(this.LT3);
            this.Controls.Add(this.LT4);
            this.Controls.Add(this.LT2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DepartmentManagment";
            this.Text = "部门查询工具";
            this.Load += new System.EventHandler(this.DepartmentManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDepartmentInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPersonInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource pDepartmentInfoBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource pPersonInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isVIPDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMSMissionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedOnTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMMSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sSMSMissionBindingSource;
        private System.Windows.Forms.Label LT2;
        private System.Windows.Forms.Label LT4;
        private System.Windows.Forms.Label LT1;
        private System.Windows.Forms.Label LT3;
    }
}