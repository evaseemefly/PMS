namespace ManagerSys
{
    partial class MissionManagement
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
            this.sSMSMissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMSMissionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedOnTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDelDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isMMSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMIDDataGridViewTextBoxColumn,
            this.sMSMissionNameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.subTimeDataGridViewTextBoxColumn,
            this.modifiedOnTimeDataGridViewTextBoxColumn,
            this.isDelDataGridViewCheckBoxColumn,
            this.isMMSDataGridViewCheckBoxColumn,
            this.sortDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sSMSMissionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(291, 473);
            this.dataGridView1.TabIndex = 0;
            // 
            // sSMSMissionBindingSource
            // 
            this.sSMSMissionBindingSource.DataSource = typeof(PMS.Model.S_SMSMission);
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
            this.sMSMissionNameDataGridViewTextBoxColumn.HeaderText = "任务名称";
            this.sMSMissionNameDataGridViewTextBoxColumn.Name = "sMSMissionNameDataGridViewTextBoxColumn";
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
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
            // isDelDataGridViewCheckBoxColumn
            // 
            this.isDelDataGridViewCheckBoxColumn.DataPropertyName = "isDel";
            this.isDelDataGridViewCheckBoxColumn.HeaderText = "isDel";
            this.isDelDataGridViewCheckBoxColumn.Name = "isDelDataGridViewCheckBoxColumn";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // MissionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 616);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MissionManagement";
            this.Text = "MissionManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMSMissionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedOnTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDelDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMMSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sSMSMissionBindingSource;
        private System.Windows.Forms.Label label1;
    }
}