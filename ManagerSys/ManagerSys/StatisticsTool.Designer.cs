namespace ManagerSys
{
    partial class StatisticsTool
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
            this.sMIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMSMissionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMSMissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.TOutput = new System.Windows.Forms.TextBox();
            this.TS1 = new System.Windows.Forms.RichTextBox();
            this.TS2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMIDDataGridViewTextBoxColumn,
            this.sMSMissionNameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sSMSMissionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(404, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(298, 666);
            this.dataGridView1.TabIndex = 0;
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
            // sSMSMissionBindingSource
            // 
            this.sSMSMissionBindingSource.DataSource = typeof(PMS.Model.S_SMSMission);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 26);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(240, 26);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 2;
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "引入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDo
            // 
            this.buttonDo.Location = new System.Drawing.Point(18, 622);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(122, 52);
            this.buttonDo.TabIndex = 3;
            this.buttonDo.Text = "警报统计";
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Click += new System.EventHandler(this.buttonDo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.monthCalendar2);
            this.groupBox1.Location = new System.Drawing.Point(728, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 229);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择时间段";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "201风暴潮红色警报任务";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(189, 21);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "202风暴潮橙色警报任务";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 80);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(189, 21);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "203风暴潮黄色警报任务";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 107);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(189, 21);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "204风暴潮蓝色警报任务";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 134);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(189, 21);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "205风暴潮解除警报任务";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 161);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(189, 21);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = "206风暴潮消息任务";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(6, 188);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(189, 21);
            this.textBox7.TabIndex = 5;
            this.textBox7.Text = "207风暴潮预判任务";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(6, 215);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(189, 21);
            this.textBox8.TabIndex = 5;
            this.textBox8.Text = "301海浪红色警报任务";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(6, 242);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(189, 21);
            this.textBox9.TabIndex = 5;
            this.textBox9.Text = "302海浪橙色警报任务";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(6, 269);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(189, 21);
            this.textBox10.TabIndex = 5;
            this.textBox10.Text = "303海浪黄色警报任务";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(6, 296);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(189, 21);
            this.textBox11.TabIndex = 5;
            this.textBox11.Text = "304海浪蓝色警报任务";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(6, 323);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(189, 21);
            this.textBox12.TabIndex = 5;
            this.textBox12.Text = "305海浪解除警报任务";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(6, 350);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(189, 21);
            this.textBox13.TabIndex = 5;
            this.textBox13.Text = "306海浪消息任务";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(6, 377);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(189, 21);
            this.textBox14.TabIndex = 5;
            this.textBox14.Text = "307海浪预判任务";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(6, 404);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(189, 21);
            this.textBox15.TabIndex = 5;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(6, 431);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(189, 21);
            this.textBox16.TabIndex = 5;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(6, 458);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(189, 21);
            this.textBox17.TabIndex = 5;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(6, 485);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(189, 21);
            this.textBox18.TabIndex = 5;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(6, 512);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(189, 21);
            this.textBox19.TabIndex = 5;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(6, 539);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(189, 21);
            this.textBox20.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton20);
            this.groupBox2.Controls.Add(this.radioButton19);
            this.groupBox2.Controls.Add(this.radioButton18);
            this.groupBox2.Controls.Add(this.radioButton17);
            this.groupBox2.Controls.Add(this.radioButton16);
            this.groupBox2.Controls.Add(this.radioButton15);
            this.groupBox2.Controls.Add(this.radioButton14);
            this.groupBox2.Controls.Add(this.radioButton13);
            this.groupBox2.Controls.Add(this.radioButton12);
            this.groupBox2.Controls.Add(this.radioButton11);
            this.groupBox2.Controls.Add(this.radioButton10);
            this.groupBox2.Controls.Add(this.radioButton9);
            this.groupBox2.Controls.Add(this.radioButton8);
            this.groupBox2.Controls.Add(this.radioButton7);
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.textBox20);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox19);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox18);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox17);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox16);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Location = new System.Drawing.Point(12, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 575);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "警报任务列表";
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.Location = new System.Drawing.Point(201, 540);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(71, 16);
            this.radioButton20.TabIndex = 6;
            this.radioButton20.TabStop = true;
            this.radioButton20.Text = "选择载入";
            this.radioButton20.UseVisualStyleBackColor = true;
            // 
            // radioButton19
            // 
            this.radioButton19.AutoSize = true;
            this.radioButton19.Location = new System.Drawing.Point(201, 513);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Size = new System.Drawing.Size(71, 16);
            this.radioButton19.TabIndex = 6;
            this.radioButton19.TabStop = true;
            this.radioButton19.Text = "选择载入";
            this.radioButton19.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.Location = new System.Drawing.Point(201, 486);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(71, 16);
            this.radioButton18.TabIndex = 6;
            this.radioButton18.TabStop = true;
            this.radioButton18.Text = "选择载入";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(201, 459);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(71, 16);
            this.radioButton17.TabIndex = 6;
            this.radioButton17.TabStop = true;
            this.radioButton17.Text = "选择载入";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(201, 432);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(71, 16);
            this.radioButton16.TabIndex = 6;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "选择载入";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(201, 405);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(71, 16);
            this.radioButton15.TabIndex = 6;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "选择载入";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(201, 378);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(71, 16);
            this.radioButton14.TabIndex = 6;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "选择载入";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(201, 351);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(71, 16);
            this.radioButton13.TabIndex = 6;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "选择载入";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(201, 324);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(71, 16);
            this.radioButton12.TabIndex = 6;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "选择载入";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(201, 297);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(71, 16);
            this.radioButton11.TabIndex = 6;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "选择载入";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(201, 270);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(71, 16);
            this.radioButton10.TabIndex = 6;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "选择载入";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(201, 243);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(71, 16);
            this.radioButton9.TabIndex = 6;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "选择载入";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(201, 216);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(71, 16);
            this.radioButton8.TabIndex = 6;
            this.radioButton8.Text = "选择载入";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(201, 189);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(71, 16);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "选择载入";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(201, 162);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(71, 16);
            this.radioButton6.TabIndex = 6;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "选择载入";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(201, 135);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(71, 16);
            this.radioButton5.TabIndex = 6;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "选择载入";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(201, 108);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(71, 16);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "选择载入";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(201, 81);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 16);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "选择载入";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(201, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "选择载入";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(201, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "选择载入";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // TOutput
            // 
            this.TOutput.Location = new System.Drawing.Point(169, 639);
            this.TOutput.Name = "TOutput";
            this.TOutput.Size = new System.Drawing.Size(189, 21);
            this.TOutput.TabIndex = 5;
            this.TOutput.Text = "D:\\";
            // 
            // TS1
            // 
            this.TS1.Location = new System.Drawing.Point(728, 266);
            this.TS1.Name = "TS1";
            this.TS1.Size = new System.Drawing.Size(500, 204);
            this.TS1.TabIndex = 8;
            this.TS1.Text = "";
            this.TS1.WordWrap = false;
            // 
            // TS2
            // 
            this.TS2.Location = new System.Drawing.Point(728, 482);
            this.TS2.Name = "TS2";
            this.TS2.Size = new System.Drawing.Size(500, 208);
            this.TS2.TabIndex = 9;
            this.TS2.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StatisticsTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 702);
            this.Controls.Add(this.TS2);
            this.Controls.Add(this.TS1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TOutput);
            this.Name = "StatisticsTool";
            this.Text = "StatisticsTool";
            this.Load += new System.EventHandler(this.StatisticsTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSMSMissionBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMSMissionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sSMSMissionBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton20;
        private System.Windows.Forms.RadioButton radioButton19;
        private System.Windows.Forms.RadioButton radioButton18;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox TOutput;
        private System.Windows.Forms.RichTextBox TS1;
        private System.Windows.Forms.RichTextBox TS2;
        private System.Windows.Forms.Button button2;
    }
}