namespace CarryTrainFrom
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataUserInfoView = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataContactInfoView = new System.Windows.Forms.DataGridView();
            this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.btnDelContact = new System.Windows.Forms.Button();
            this.btnRefContact = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnQueryContact = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelTask = new System.Windows.Forms.Button();
            this.btnStopTask = new System.Windows.Forms.Button();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserInfoView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContactInfoView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataUserInfoView
            // 
            this.dataUserInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUserInfoView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.UserPwd,
            this.State,
            this.ContactNum});
            this.dataUserInfoView.Location = new System.Drawing.Point(8, 50);
            this.dataUserInfoView.Name = "dataUserInfoView";
            this.dataUserInfoView.RowTemplate.Height = 23;
            this.dataUserInfoView.Size = new System.Drawing.Size(365, 268);
            this.dataUserInfoView.TabIndex = 0;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UserName.DefaultCellStyle = dataGridViewCellStyle1;
            this.UserName.HeaderText = "账号";
            this.UserName.Name = "UserName";
            this.UserName.Width = 85;
            // 
            // UserPwd
            // 
            this.UserPwd.DataPropertyName = "UserPwd";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UserPwd.DefaultCellStyle = dataGridViewCellStyle2;
            this.UserPwd.HeaderText = "密码";
            this.UserPwd.Name = "UserPwd";
            this.UserPwd.Width = 85;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.State.DefaultCellStyle = dataGridViewCellStyle3;
            this.State.HeaderText = "状态";
            this.State.Name = "State";
            this.State.Width = 60;
            // 
            // ContactNum
            // 
            this.ContactNum.DataPropertyName = "ContactNum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ContactNum.DefaultCellStyle = dataGridViewCellStyle4;
            this.ContactNum.HeaderText = "联系人数量";
            this.ContactNum.Name = "ContactNum";
            this.ContactNum.Width = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataContactInfoView);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.btnDelContact);
            this.groupBox1.Controls.Add(this.btnRefContact);
            this.groupBox1.Controls.Add(this.btnAddContact);
            this.groupBox1.Controls.Add(this.btnQueryContact);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnAddUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataUserInfoView);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 705);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "账号管理";
            // 
            // dataContactInfoView
            // 
            this.dataContactInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataContactInfoView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContactName,
            this.CardNo});
            this.dataContactInfoView.Location = new System.Drawing.Point(10, 425);
            this.dataContactInfoView.Name = "dataContactInfoView";
            this.dataContactInfoView.RowTemplate.Height = 23;
            this.dataContactInfoView.Size = new System.Drawing.Size(365, 263);
            this.dataContactInfoView.TabIndex = 12;
            // 
            // ContactName
            // 
            this.ContactName.DataPropertyName = "ContactName";
            this.ContactName.HeaderText = "用户名";
            this.ContactName.Name = "ContactName";
            this.ContactName.Width = 121;
            // 
            // CardNo
            // 
            this.CardNo.DataPropertyName = "CardNo";
            this.CardNo.HeaderText = "身份证账号";
            this.CardNo.Name = "CardNo";
            this.CardNo.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "操作：";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(250, 379);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "批量添加";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // btnDelContact
            // 
            this.btnDelContact.Location = new System.Drawing.Point(154, 379);
            this.btnDelContact.Name = "btnDelContact";
            this.btnDelContact.Size = new System.Drawing.Size(75, 23);
            this.btnDelContact.TabIndex = 9;
            this.btnDelContact.Text = "删除联系人";
            this.btnDelContact.UseVisualStyleBackColor = true;
            // 
            // btnRefContact
            // 
            this.btnRefContact.Location = new System.Drawing.Point(58, 379);
            this.btnRefContact.Name = "btnRefContact";
            this.btnRefContact.Size = new System.Drawing.Size(75, 23);
            this.btnRefContact.TabIndex = 8;
            this.btnRefContact.Text = "刷新联系人";
            this.btnRefContact.UseVisualStyleBackColor = true;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(250, 334);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(75, 23);
            this.btnAddContact.TabIndex = 7;
            this.btnAddContact.Text = "新增联系人";
            this.btnAddContact.UseVisualStyleBackColor = true;
            // 
            // btnQueryContact
            // 
            this.btnQueryContact.Location = new System.Drawing.Point(164, 333);
            this.btnQueryContact.Name = "btnQueryContact";
            this.btnQueryContact.Size = new System.Drawing.Size(75, 23);
            this.btnQueryContact.TabIndex = 6;
            this.btnQueryContact.Text = "查询";
            this.btnQueryContact.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 334);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "批量添加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(133, 18);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "添加账号";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "账号列表：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1399, 752);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1391, 726);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "任务管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(393, 388);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(992, 323);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志输出";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 43);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(980, 263);
            this.textBox2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelTask);
            this.groupBox2.Controls.Add(this.btnStopTask);
            this.groupBox2.Controls.Add(this.btnStartTask);
            this.groupBox2.Controls.Add(this.btnAddTask);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(393, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(992, 369);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务管理";
            // 
            // btnDelTask
            // 
            this.btnDelTask.Location = new System.Drawing.Point(445, 20);
            this.btnDelTask.Name = "btnDelTask";
            this.btnDelTask.Size = new System.Drawing.Size(129, 39);
            this.btnDelTask.TabIndex = 4;
            this.btnDelTask.Text = "删除任务";
            this.btnDelTask.UseVisualStyleBackColor = true;
            // 
            // btnStopTask
            // 
            this.btnStopTask.Location = new System.Drawing.Point(298, 20);
            this.btnStopTask.Name = "btnStopTask";
            this.btnStopTask.Size = new System.Drawing.Size(129, 39);
            this.btnStopTask.TabIndex = 3;
            this.btnStopTask.Text = "停止任务";
            this.btnStopTask.UseVisualStyleBackColor = true;
            // 
            // btnStartTask
            // 
            this.btnStartTask.Location = new System.Drawing.Point(151, 20);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(129, 39);
            this.btnStartTask.TabIndex = 2;
            this.btnStartTask.Text = "启动任务";
            this.btnStartTask.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(6, 20);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(129, 39);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "添加任务";
            this.btnAddTask.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(980, 295);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1391, 726);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "常用设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1391, 726);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "工具选项";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1391, 726);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "订单页";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 776);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "小严购票(首页)";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUserInfoView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContactInfoView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataUserInfoView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataContactInfoView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnDelContact;
        private System.Windows.Forms.Button btnRefContact;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnQueryContact;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelTask;
        private System.Windows.Forms.Button btnStopTask;
        private System.Windows.Forms.Button btnStartTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

