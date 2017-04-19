namespace httpmms_xml
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.基本参数 = new System.Windows.Forms.GroupBox();
            this.urlLable = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.pswd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.account = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.requestInput = new System.Windows.Forms.TextBox();
            this.基本参数.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择ZIP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(434, 21);
            this.textBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "选择ZIP";
            this.openFileDialog1.Filter = "ZIP压缩包|*.zip";
            // 
            // 基本参数
            // 
            this.基本参数.Controls.Add(this.urlLable);
            this.基本参数.Controls.Add(this.url);
            this.基本参数.Controls.Add(this.pswd);
            this.基本参数.Controls.Add(this.label5);
            this.基本参数.Controls.Add(this.account);
            this.基本参数.Controls.Add(this.label4);
            this.基本参数.Controls.Add(this.textBox3);
            this.基本参数.Controls.Add(this.label3);
            this.基本参数.Controls.Add(this.textBox2);
            this.基本参数.Controls.Add(this.label2);
            this.基本参数.Controls.Add(this.label1);
            this.基本参数.Controls.Add(this.textBox1);
            this.基本参数.Controls.Add(this.button1);
            this.基本参数.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.基本参数.Location = new System.Drawing.Point(12, 12);
            this.基本参数.Name = "基本参数";
            this.基本参数.Size = new System.Drawing.Size(688, 290);
            this.基本参数.TabIndex = 2;
            this.基本参数.TabStop = false;
            this.基本参数.Text = "基本参数";
            // 
            // urlLable
            // 
            this.urlLable.AutoSize = true;
            this.urlLable.Location = new System.Drawing.Point(19, 68);
            this.urlLable.Name = "urlLable";
            this.urlLable.Size = new System.Drawing.Size(70, 12);
            this.urlLable.TabIndex = 12;
            this.urlLable.Text = "请求地址：";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(124, 63);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(535, 21);
            this.url.TabIndex = 11;
            this.url.Text = "http://mms.3tong.net/http/mms";
            // 
            // pswd
            // 
            this.pswd.Location = new System.Drawing.Point(416, 32);
            this.pswd.Name = "pswd";
            this.pswd.Size = new System.Drawing.Size(243, 21);
            this.pswd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "密  码：";
            // 
            // account
            // 
            this.account.Location = new System.Drawing.Point(124, 29);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(205, 21);
            this.account.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "帐  号：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 181);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(535, 84);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "手机号码:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(535, 21);
            this.textBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "彩信标题:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "彩信路径:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 616);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 32);
            this.button3.TabIndex = 10;
            this.button3.Text = "获取状态";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 616);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "发送彩信";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(15, 474);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 120);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务端返回数据";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 20);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(670, 84);
            this.textBox4.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.requestInput);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(15, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 149);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请求数据：";
            // 
            // requestInput
            // 
            this.requestInput.Location = new System.Drawing.Point(9, 20);
            this.requestInput.Multiline = true;
            this.requestInput.Name = "requestInput";
            this.requestInput.Size = new System.Drawing.Size(667, 113);
            this.requestInput.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 660);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.基本参数);
            this.Name = "Form1";
            this.Text = "Form1";
            this.基本参数.ResumeLayout(false);
            this.基本参数.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox 基本参数;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label urlLable;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.TextBox pswd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox account;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox requestInput;
    }
}

