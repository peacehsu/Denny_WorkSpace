namespace MQTest
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MQChannel = new System.Windows.Forms.TextBox();
            this.MQPort = new System.Windows.Forms.TextBox();
            this.MQIP = new System.Windows.Forms.TextBox();
            this.MQName = new System.Windows.Forms.TextBox();
            this.MQManage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MQCNT = new System.Windows.Forms.Label();
            this.MQCount = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PutQ = new System.Windows.Forms.Button();
            this.PutItem = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.GetQ = new System.Windows.Forms.Button();
            this.GetItem = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MQChannel);
            this.groupBox1.Controls.Add(this.MQPort);
            this.groupBox1.Controls.Add(this.MQIP);
            this.groupBox1.Controls.Add(this.MQName);
            this.groupBox1.Controls.Add(this.MQManage);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MQ設定";
            // 
            // MQChannel
            // 
            this.MQChannel.Location = new System.Drawing.Point(461, 64);
            this.MQChannel.Name = "MQChannel";
            this.MQChannel.Size = new System.Drawing.Size(160, 25);
            this.MQChannel.TabIndex = 9;
            this.MQChannel.Text = "NCLM_SIT.CHANNEL";
            // 
            // MQPort
            // 
            this.MQPort.Location = new System.Drawing.Point(461, 33);
            this.MQPort.Name = "MQPort";
            this.MQPort.Size = new System.Drawing.Size(160, 25);
            this.MQPort.TabIndex = 8;
            this.MQPort.Text = "1535";
            // 
            // MQIP
            // 
            this.MQIP.Location = new System.Drawing.Point(166, 98);
            this.MQIP.Name = "MQIP";
            this.MQIP.Size = new System.Drawing.Size(160, 25);
            this.MQIP.TabIndex = 7;
            this.MQIP.Text = "172.16.241.20";
            // 
            // MQName
            // 
            this.MQName.Location = new System.Drawing.Point(166, 64);
            this.MQName.Name = "MQName";
            this.MQName.Size = new System.Drawing.Size(160, 25);
            this.MQName.TabIndex = 6;
            this.MQName.Text = "SIT.QCARD.SUPDOCCHK.TOP";
            // 
            // MQManage
            // 
            this.MQManage.Location = new System.Drawing.Point(166, 35);
            this.MQManage.Name = "MQManage";
            this.MQManage.Size = new System.Drawing.Size(160, 25);
            this.MQManage.TabIndex = 5;
            this.MQManage.Text = "NCLM_SIT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "CHANNEL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "佇列名稱:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "PORT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "佇列管理程式名稱:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MQCNT);
            this.groupBox2.Controls.Add(this.MQCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 101);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MQ資訊";
            // 
            // MQCNT
            // 
            this.MQCNT.BackColor = System.Drawing.SystemColors.Control;
            this.MQCNT.Location = new System.Drawing.Point(83, 45);
            this.MQCNT.Name = "MQCNT";
            this.MQCNT.Size = new System.Drawing.Size(108, 20);
            this.MQCNT.TabIndex = 12;
            // 
            // MQCount
            // 
            this.MQCount.BackColor = System.Drawing.SystemColors.Control;
            this.MQCount.Location = new System.Drawing.Point(211, 45);
            this.MQCount.Name = "MQCount";
            this.MQCount.Size = new System.Drawing.Size(77, 32);
            this.MQCount.TabIndex = 11;
            this.MQCount.Text = "計算";
            this.MQCount.UseVisualStyleBackColor = false;
            this.MQCount.Click += new System.EventHandler(this.MQCount_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "佇列數量:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PutQ);
            this.groupBox3.Controls.Add(this.PutItem);
            this.groupBox3.Location = new System.Drawing.Point(13, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(621, 124);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PutQueue";
            // 
            // PutQ
            // 
            this.PutQ.BackColor = System.Drawing.SystemColors.Control;
            this.PutQ.Location = new System.Drawing.Point(530, 84);
            this.PutQ.Name = "PutQ";
            this.PutQ.Size = new System.Drawing.Size(85, 34);
            this.PutQ.TabIndex = 13;
            this.PutQ.Text = "傳送";
            this.PutQ.UseVisualStyleBackColor = false;
            this.PutQ.Click += new System.EventHandler(this.PutQ_Click);
            // 
            // PutItem
            // 
            this.PutItem.Location = new System.Drawing.Point(9, 25);
            this.PutItem.Multiline = true;
            this.PutItem.Name = "PutItem";
            this.PutItem.Size = new System.Drawing.Size(461, 82);
            this.PutItem.TabIndex = 0;
            this.PutItem.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GetQ);
            this.groupBox4.Controls.Add(this.GetItem);
            this.groupBox4.Location = new System.Drawing.Point(12, 439);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(622, 124);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GetQueue";
            // 
            // GetQ
            // 
            this.GetQ.BackColor = System.Drawing.SystemColors.Control;
            this.GetQ.Location = new System.Drawing.Point(531, 83);
            this.GetQ.Name = "GetQ";
            this.GetQ.Size = new System.Drawing.Size(85, 35);
            this.GetQ.TabIndex = 14;
            this.GetQ.Text = "取得";
            this.GetQ.UseVisualStyleBackColor = false;
            this.GetQ.Click += new System.EventHandler(this.GetQ_Click);
            // 
            // GetItem
            // 
            this.GetItem.Location = new System.Drawing.Point(10, 24);
            this.GetItem.Multiline = true;
            this.GetItem.Name = "GetItem";
            this.GetItem.Size = new System.Drawing.Size(461, 82);
            this.GetItem.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 684);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MQ測試介面";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MQChannel;
        private System.Windows.Forms.TextBox MQPort;
        private System.Windows.Forms.TextBox MQIP;
        private System.Windows.Forms.TextBox MQName;
        private System.Windows.Forms.TextBox MQManage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label MQCNT;
        private System.Windows.Forms.Button MQCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox PutItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button PutQ;
        private System.Windows.Forms.Button GetQ;
        private System.Windows.Forms.TextBox GetItem;
    }
}

