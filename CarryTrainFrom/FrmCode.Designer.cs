namespace CarryTrainFrom
{
    partial class FrmCode
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCode = new System.Windows.Forms.Button();
            this.ChangeCode = new System.Windows.Forms.LinkLabel();
            this.picCode = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(23, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCode
            // 
            this.btnCode.BackColor = System.Drawing.Color.Transparent;
            this.btnCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCode.ForeColor = System.Drawing.Color.Black;
            this.btnCode.Location = new System.Drawing.Point(208, 220);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(110, 40);
            this.btnCode.TabIndex = 6;
            this.btnCode.Text = "确  定";
            this.btnCode.UseVisualStyleBackColor = false;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // ChangeCode
            // 
            this.ChangeCode.AutoSize = true;
            this.ChangeCode.BackColor = System.Drawing.Color.Transparent;
            this.ChangeCode.DisabledLinkColor = System.Drawing.Color.Transparent;
            this.ChangeCode.ForeColor = System.Drawing.Color.Transparent;
            this.ChangeCode.LinkColor = System.Drawing.Color.Gray;
            this.ChangeCode.Location = new System.Drawing.Point(227, 33);
            this.ChangeCode.Name = "ChangeCode";
            this.ChangeCode.Size = new System.Drawing.Size(77, 12);
            this.ChangeCode.TabIndex = 5;
            this.ChangeCode.TabStop = true;
            this.ChangeCode.Text = "眼瞎！换一张";
            this.ChangeCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeCode_LinkClicked);
            // 
            // picCode
            // 
            this.picCode.BackColor = System.Drawing.Color.Transparent;
            this.picCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCode.Location = new System.Drawing.Point(23, 22);
            this.picCode.Name = "picCode";
            this.picCode.Size = new System.Drawing.Size(295, 192);
            this.picCode.TabIndex = 4;
            this.picCode.TabStop = false;
            this.picCode.Click += new System.EventHandler(this.picCode_Click);
            this.picCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCode_MouseClick);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(338, 272);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCode);
            this.Controls.Add(this.ChangeCode);
            this.Controls.Add(this.picCode);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCode";
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCode;
        private System.Windows.Forms.LinkLabel ChangeCode;
        private System.Windows.Forms.PictureBox picCode;
        private System.Windows.Forms.Timer timer;
    }
}