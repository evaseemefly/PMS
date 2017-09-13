namespace ManagerSys
{
    partial class GroupManagment
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
            this.gIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDelDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.subTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedOnTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forbidDelDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.sMIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMSMissionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedOnTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDelDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isMMSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sortDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rDepartmentMissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rGroupMissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rUserInfoSMSMissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSRecordHistoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSMsgContentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSContentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSMissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.pIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVIPDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isDelDataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDepartmentInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSRecordCurrentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rUserInfoPersonInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSRecordHistoryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPersonInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LT1 = new System.Windows.Forms.Label();
            this.LT2 = new System.Windows.Forms.Label();
            this.LT3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPersonInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gIDDataGridViewTextBoxColumn,
            this.groupNameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.isDelDataGridViewCheckBoxColumn,
            this.subTimeDataGridViewTextBoxColumn,
            this.modifiedOnTimeDataGridViewTextBoxColumn,
            this.sortDataGridViewTextBoxColumn,
            this.forbidDelDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.pGroupBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(254, 568);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // gIDDataGridViewTextBoxColumn
            // 
            this.gIDDataGridViewTextBoxColumn.DataPropertyName = "GID";
            this.gIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.gIDDataGridViewTextBoxColumn.Name = "gIDDataGridViewTextBoxColumn";
            this.gIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.HeaderText = "群组名";
            this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            // 
            // isDelDataGridViewCheckBoxColumn
            // 
            this.isDelDataGridViewCheckBoxColumn.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn.HeaderText = "删除标记";
            this.isDelDataGridViewCheckBoxColumn.Name = "isDelDataGridViewCheckBoxColumn";
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
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "Sort";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            // 
            // forbidDelDataGridViewCheckBoxColumn
            // 
            this.forbidDelDataGridViewCheckBoxColumn.DataPropertyName = "forbidDel";
            this.forbidDelDataGridViewCheckBoxColumn.HeaderText = "forbidDel";
            this.forbidDelDataGridViewCheckBoxColumn.Name = "forbidDelDataGridViewCheckBoxColumn";
            // 
            // pGroupBindingSource
            // 
            this.pGroupBindingSource.DataSource = typeof(PMS.Model.P_Group);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "所属任务";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "所属联系人";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMIDDataGridViewTextBoxColumn,
            this.sMSMissionNameDataGridViewTextBoxColumn,
            this.subTimeDataGridViewTextBoxColumn1,
            this.modifiedOnTimeDataGridViewTextBoxColumn1,
            this.remarkDataGridViewTextBoxColumn1,
            this.isDelDataGridViewCheckBoxColumn1,
            this.isMMSDataGridViewCheckBoxColumn,
            this.sortDataGridViewTextBoxColumn1,
            this.rDepartmentMissionDataGridViewTextBoxColumn,
            this.rGroupMissionDataGridViewTextBoxColumn,
            this.rUserInfoSMSMissionDataGridViewTextBoxColumn,
            this.sSMSRecordHistoryDataGridViewTextBoxColumn,
            this.sSMSMsgContentDataGridViewTextBoxColumn,
            this.sSMSContentDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.sSMSMissionBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(372, 57);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(254, 568);
            this.dataGridView2.TabIndex = 0;
            // 
            // sMIDDataGridViewTextBoxColumn
            // 
            this.sMIDDataGridViewTextBoxColumn.DataPropertyName = "SMID";
            this.sMIDDataGridViewTextBoxColumn.HeaderText = "SMID";
            this.sMIDDataGridViewTextBoxColumn.Name = "sMIDDataGridViewTextBoxColumn";
            // 
            // sMSMissionNameDataGridViewTextBoxColumn
            // 
            this.sMSMissionNameDataGridViewTextBoxColumn.DataPropertyName = "SMSMissionName";
            this.sMSMissionNameDataGridViewTextBoxColumn.HeaderText = "SMSMissionName";
            this.sMSMissionNameDataGridViewTextBoxColumn.Name = "sMSMissionNameDataGridViewTextBoxColumn";
            // 
            // subTimeDataGridViewTextBoxColumn1
            // 
            this.subTimeDataGridViewTextBoxColumn1.DataPropertyName = "SubTime";
            this.subTimeDataGridViewTextBoxColumn1.HeaderText = "SubTime";
            this.subTimeDataGridViewTextBoxColumn1.Name = "subTimeDataGridViewTextBoxColumn1";
            // 
            // modifiedOnTimeDataGridViewTextBoxColumn1
            // 
            this.modifiedOnTimeDataGridViewTextBoxColumn1.DataPropertyName = "ModifiedOnTime";
            this.modifiedOnTimeDataGridViewTextBoxColumn1.HeaderText = "ModifiedOnTime";
            this.modifiedOnTimeDataGridViewTextBoxColumn1.Name = "modifiedOnTimeDataGridViewTextBoxColumn1";
            // 
            // remarkDataGridViewTextBoxColumn1
            // 
            this.remarkDataGridViewTextBoxColumn1.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn1.HeaderText = "Remark";
            this.remarkDataGridViewTextBoxColumn1.Name = "remarkDataGridViewTextBoxColumn1";
            // 
            // isDelDataGridViewCheckBoxColumn1
            // 
            this.isDelDataGridViewCheckBoxColumn1.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn1.HeaderText = "isDel";
            this.isDelDataGridViewCheckBoxColumn1.Name = "isDelDataGridViewCheckBoxColumn1";
            // 
            // isMMSDataGridViewCheckBoxColumn
            // 
            this.isMMSDataGridViewCheckBoxColumn.DataPropertyName = "isMMS";
            this.isMMSDataGridViewCheckBoxColumn.HeaderText = "isMMS";
            this.isMMSDataGridViewCheckBoxColumn.Name = "isMMSDataGridViewCheckBoxColumn";
            // 
            // sortDataGridViewTextBoxColumn1
            // 
            this.sortDataGridViewTextBoxColumn1.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn1.HeaderText = "Sort";
            this.sortDataGridViewTextBoxColumn1.Name = "sortDataGridViewTextBoxColumn1";
            // 
            // rDepartmentMissionDataGridViewTextBoxColumn
            // 
            this.rDepartmentMissionDataGridViewTextBoxColumn.DataPropertyName = "R_Department_Mission";
            this.rDepartmentMissionDataGridViewTextBoxColumn.HeaderText = "R_Department_Mission";
            this.rDepartmentMissionDataGridViewTextBoxColumn.Name = "rDepartmentMissionDataGridViewTextBoxColumn";
            // 
            // rGroupMissionDataGridViewTextBoxColumn
            // 
            this.rGroupMissionDataGridViewTextBoxColumn.DataPropertyName = "R_Group_Mission";
            this.rGroupMissionDataGridViewTextBoxColumn.HeaderText = "R_Group_Mission";
            this.rGroupMissionDataGridViewTextBoxColumn.Name = "rGroupMissionDataGridViewTextBoxColumn";
            // 
            // rUserInfoSMSMissionDataGridViewTextBoxColumn
            // 
            this.rUserInfoSMSMissionDataGridViewTextBoxColumn.DataPropertyName = "R_UserInfo_SMSMission";
            this.rUserInfoSMSMissionDataGridViewTextBoxColumn.HeaderText = "R_UserInfo_SMSMission";
            this.rUserInfoSMSMissionDataGridViewTextBoxColumn.Name = "rUserInfoSMSMissionDataGridViewTextBoxColumn";
            // 
            // sSMSRecordHistoryDataGridViewTextBoxColumn
            // 
            this.sSMSRecordHistoryDataGridViewTextBoxColumn.DataPropertyName = "S_SMSRecord_History";
            this.sSMSRecordHistoryDataGridViewTextBoxColumn.HeaderText = "S_SMSRecord_History";
            this.sSMSRecordHistoryDataGridViewTextBoxColumn.Name = "sSMSRecordHistoryDataGridViewTextBoxColumn";
            // 
            // sSMSMsgContentDataGridViewTextBoxColumn
            // 
            this.sSMSMsgContentDataGridViewTextBoxColumn.DataPropertyName = "S_SMSMsgContent";
            this.sSMSMsgContentDataGridViewTextBoxColumn.HeaderText = "S_SMSMsgContent";
            this.sSMSMsgContentDataGridViewTextBoxColumn.Name = "sSMSMsgContentDataGridViewTextBoxColumn";
            // 
            // sSMSContentDataGridViewTextBoxColumn
            // 
            this.sSMSContentDataGridViewTextBoxColumn.DataPropertyName = "S_SMSContent";
            this.sSMSContentDataGridViewTextBoxColumn.HeaderText = "S_SMSContent";
            this.sSMSContentDataGridViewTextBoxColumn.Name = "sSMSContentDataGridViewTextBoxColumn";
            // 
            // sSMSMissionBindingSource
            // 
            this.sSMSMissionBindingSource.DataSource = typeof(PMS.Model.S_SMSMission);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pIDDataGridViewTextBoxColumn,
            this.pNameDataGridViewTextBoxColumn,
            this.phoneNumDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn2,
            this.isVIPDataGridViewCheckBoxColumn,
            this.isDelDataGridViewCheckBoxColumn2,
            this.pDepartmentInfoDataGridViewTextBoxColumn,
            this.pGroupDataGridViewTextBoxColumn,
            this.sSMSRecordCurrentDataGridViewTextBoxColumn,
            this.rUserInfoPersonInfoDataGridViewTextBoxColumn,
            this.sSMSRecordHistoryDataGridViewTextBoxColumn1});
            this.dataGridView3.DataSource = this.pPersonInfoBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(696, 57);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(254, 568);
            this.dataGridView3.TabIndex = 0;
            // 
            // pIDDataGridViewTextBoxColumn
            // 
            this.pIDDataGridViewTextBoxColumn.DataPropertyName = "PID";
            this.pIDDataGridViewTextBoxColumn.HeaderText = "PID";
            this.pIDDataGridViewTextBoxColumn.Name = "pIDDataGridViewTextBoxColumn";
            // 
            // pNameDataGridViewTextBoxColumn
            // 
            this.pNameDataGridViewTextBoxColumn.DataPropertyName = "PName";
            this.pNameDataGridViewTextBoxColumn.HeaderText = "PName";
            this.pNameDataGridViewTextBoxColumn.Name = "pNameDataGridViewTextBoxColumn";
            // 
            // phoneNumDataGridViewTextBoxColumn
            // 
            this.phoneNumDataGridViewTextBoxColumn.DataPropertyName = "PhoneNum";
            this.phoneNumDataGridViewTextBoxColumn.HeaderText = "PhoneNum";
            this.phoneNumDataGridViewTextBoxColumn.Name = "phoneNumDataGridViewTextBoxColumn";
            // 
            // remarkDataGridViewTextBoxColumn2
            // 
            this.remarkDataGridViewTextBoxColumn2.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn2.HeaderText = "Remark";
            this.remarkDataGridViewTextBoxColumn2.Name = "remarkDataGridViewTextBoxColumn2";
            // 
            // isVIPDataGridViewCheckBoxColumn
            // 
            this.isVIPDataGridViewCheckBoxColumn.DataPropertyName = "isVIP";
            this.isVIPDataGridViewCheckBoxColumn.HeaderText = "isVIP";
            this.isVIPDataGridViewCheckBoxColumn.Name = "isVIPDataGridViewCheckBoxColumn";
            // 
            // isDelDataGridViewCheckBoxColumn2
            // 
            this.isDelDataGridViewCheckBoxColumn2.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn2.HeaderText = "isDel";
            this.isDelDataGridViewCheckBoxColumn2.Name = "isDelDataGridViewCheckBoxColumn2";
            // 
            // pDepartmentInfoDataGridViewTextBoxColumn
            // 
            this.pDepartmentInfoDataGridViewTextBoxColumn.DataPropertyName = "P_DepartmentInfo";
            this.pDepartmentInfoDataGridViewTextBoxColumn.HeaderText = "P_DepartmentInfo";
            this.pDepartmentInfoDataGridViewTextBoxColumn.Name = "pDepartmentInfoDataGridViewTextBoxColumn";
            // 
            // pGroupDataGridViewTextBoxColumn
            // 
            this.pGroupDataGridViewTextBoxColumn.DataPropertyName = "P_Group";
            this.pGroupDataGridViewTextBoxColumn.HeaderText = "P_Group";
            this.pGroupDataGridViewTextBoxColumn.Name = "pGroupDataGridViewTextBoxColumn";
            // 
            // sSMSRecordCurrentDataGridViewTextBoxColumn
            // 
            this.sSMSRecordCurrentDataGridViewTextBoxColumn.DataPropertyName = "S_SMSRecord_Current";
            this.sSMSRecordCurrentDataGridViewTextBoxColumn.HeaderText = "S_SMSRecord_Current";
            this.sSMSRecordCurrentDataGridViewTextBoxColumn.Name = "sSMSRecordCurrentDataGridViewTextBoxColumn";
            // 
            // rUserInfoPersonInfoDataGridViewTextBoxColumn
            // 
            this.rUserInfoPersonInfoDataGridViewTextBoxColumn.DataPropertyName = "R_UserInfo_PersonInfo";
            this.rUserInfoPersonInfoDataGridViewTextBoxColumn.HeaderText = "R_UserInfo_PersonInfo";
            this.rUserInfoPersonInfoDataGridViewTextBoxColumn.Name = "rUserInfoPersonInfoDataGridViewTextBoxColumn";
            // 
            // sSMSRecordHistoryDataGridViewTextBoxColumn1
            // 
            this.sSMSRecordHistoryDataGridViewTextBoxColumn1.DataPropertyName = "S_SMSRecord_History";
            this.sSMSRecordHistoryDataGridViewTextBoxColumn1.HeaderText = "S_SMSRecord_History";
            this.sSMSRecordHistoryDataGridViewTextBoxColumn1.Name = "sSMSRecordHistoryDataGridViewTextBoxColumn1";
            // 
            // pPersonInfoBindingSource
            // 
            this.pPersonInfoBindingSource.DataSource = typeof(PMS.Model.P_PersonInfo);
            // 
            // LT1
            // 
            this.LT1.AutoSize = true;
            this.LT1.Location = new System.Drawing.Point(12, 628);
            this.LT1.Name = "LT1";
            this.LT1.Size = new System.Drawing.Size(17, 12);
            this.LT1.TabIndex = 1;
            this.LT1.Text = "条";
            // 
            // LT2
            // 
            this.LT2.AutoSize = true;
            this.LT2.Location = new System.Drawing.Point(370, 628);
            this.LT2.Name = "LT2";
            this.LT2.Size = new System.Drawing.Size(17, 12);
            this.LT2.TabIndex = 1;
            this.LT2.Text = "条";
            // 
            // LT3
            // 
            this.LT3.AutoSize = true;
            this.LT3.Location = new System.Drawing.Point(694, 628);
            this.LT3.Name = "LT3";
            this.LT3.Size = new System.Drawing.Size(17, 12);
            this.LT3.TabIndex = 1;
            this.LT3.Text = "条";
            // 
            // GroupManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 649);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LT3);
            this.Controls.Add(this.LT2);
            this.Controls.Add(this.LT1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GroupManagment";
            this.Text = "GroupManagment";
            this.Load += new System.EventHandler(this.GroupManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPersonInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedOnTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn forbidDelDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource pGroupBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMSMissionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedOnTimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMMSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rDepartmentMissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rGroupMissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rUserInfoSMSMissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSMSRecordHistoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSMSMsgContentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSMSContentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sSMSMissionBindingSource;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isVIPDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDepartmentInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSMSRecordCurrentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rUserInfoPersonInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSMSRecordHistoryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource pPersonInfoBindingSource;
        private System.Windows.Forms.Label LT1;
        private System.Windows.Forms.Label LT2;
        private System.Windows.Forms.Label LT3;
    }
}