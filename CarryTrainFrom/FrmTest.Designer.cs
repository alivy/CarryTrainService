namespace CarryTrainFrom
{
    partial class FrmTest
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
            this.CheckOrderBtn = new System.Windows.Forms.Button();
            this.GetQueuebtn = new System.Windows.Forms.Button();
            this.ConfirmGoForQueueBtn = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.TextBox();
            this.QueryOrderWaitTimeBtn = new System.Windows.Forms.Button();
            this.ResultOrderForWcQueueBtn = new System.Windows.Forms.Button();
            this.SubmitOrderRequestBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckOrderBtn
            // 
            this.CheckOrderBtn.Location = new System.Drawing.Point(59, 88);
            this.CheckOrderBtn.Name = "CheckOrderBtn";
            this.CheckOrderBtn.Size = new System.Drawing.Size(124, 46);
            this.CheckOrderBtn.TabIndex = 0;
            this.CheckOrderBtn.Text = "CheckOrderInfo";
            this.CheckOrderBtn.UseVisualStyleBackColor = true;
            this.CheckOrderBtn.Click += new System.EventHandler(this.CheckOrderBtn_Click);
            // 
            // GetQueuebtn
            // 
            this.GetQueuebtn.Location = new System.Drawing.Point(59, 165);
            this.GetQueuebtn.Name = "GetQueuebtn";
            this.GetQueuebtn.Size = new System.Drawing.Size(124, 46);
            this.GetQueuebtn.TabIndex = 1;
            this.GetQueuebtn.Text = "GetQueueCount";
            this.GetQueuebtn.UseVisualStyleBackColor = true;
            this.GetQueuebtn.Click += new System.EventHandler(this.GetQueuebtn_Click);
            // 
            // ConfirmGoForQueueBtn
            // 
            this.ConfirmGoForQueueBtn.Location = new System.Drawing.Point(59, 241);
            this.ConfirmGoForQueueBtn.Name = "ConfirmGoForQueueBtn";
            this.ConfirmGoForQueueBtn.Size = new System.Drawing.Size(124, 46);
            this.ConfirmGoForQueueBtn.TabIndex = 2;
            this.ConfirmGoForQueueBtn.Text = "ConfirmGoForQueue";
            this.ConfirmGoForQueueBtn.UseVisualStyleBackColor = true;
            this.ConfirmGoForQueueBtn.Click += new System.EventHandler(this.ConfirmGoForQueueBtn_Click);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(231, 12);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(526, 442);
            this.txt.TabIndex = 3;
            // 
            // QueryOrderWaitTimeBtn
            // 
            this.QueryOrderWaitTimeBtn.Location = new System.Drawing.Point(59, 314);
            this.QueryOrderWaitTimeBtn.Name = "QueryOrderWaitTimeBtn";
            this.QueryOrderWaitTimeBtn.Size = new System.Drawing.Size(124, 46);
            this.QueryOrderWaitTimeBtn.TabIndex = 4;
            this.QueryOrderWaitTimeBtn.Text = "QueryOrderWaitTime";
            this.QueryOrderWaitTimeBtn.UseVisualStyleBackColor = true;
            this.QueryOrderWaitTimeBtn.Click += new System.EventHandler(this.QueryOrderWaitTimeBtn_Click);
            // 
            // ResultOrderForWcQueueBtn
            // 
            this.ResultOrderForWcQueueBtn.Location = new System.Drawing.Point(59, 392);
            this.ResultOrderForWcQueueBtn.Name = "ResultOrderForWcQueueBtn";
            this.ResultOrderForWcQueueBtn.Size = new System.Drawing.Size(124, 46);
            this.ResultOrderForWcQueueBtn.TabIndex = 5;
            this.ResultOrderForWcQueueBtn.Text = "ResultOrderForWcQueue";
            this.ResultOrderForWcQueueBtn.UseVisualStyleBackColor = true;
            this.ResultOrderForWcQueueBtn.Click += new System.EventHandler(this.ResultOrderForWcQueueBtn_Click);
            // 
            // SubmitOrderRequestBtn
            // 
            this.SubmitOrderRequestBtn.Location = new System.Drawing.Point(59, 12);
            this.SubmitOrderRequestBtn.Name = "SubmitOrderRequestBtn";
            this.SubmitOrderRequestBtn.Size = new System.Drawing.Size(124, 46);
            this.SubmitOrderRequestBtn.TabIndex = 6;
            this.SubmitOrderRequestBtn.Text = "SubmitOrderRequest";
            this.SubmitOrderRequestBtn.UseVisualStyleBackColor = true;
            this.SubmitOrderRequestBtn.Click += new System.EventHandler(this.SubmitOrderRequest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 630);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "获取验证码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 703);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SubmitOrderRequestBtn);
            this.Controls.Add(this.ResultOrderForWcQueueBtn);
            this.Controls.Add(this.QueryOrderWaitTimeBtn);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.ConfirmGoForQueueBtn);
            this.Controls.Add(this.GetQueuebtn);
            this.Controls.Add(this.CheckOrderBtn);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckOrderBtn;
        private System.Windows.Forms.Button GetQueuebtn;
        private System.Windows.Forms.Button ConfirmGoForQueueBtn;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button QueryOrderWaitTimeBtn;
        private System.Windows.Forms.Button ResultOrderForWcQueueBtn;
        private System.Windows.Forms.Button SubmitOrderRequestBtn;
        private System.Windows.Forms.Button button1;
    }
}