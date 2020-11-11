namespace WaterMarkTool
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
        private System.Windows.Forms.GroupBox groupBox3;
        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FileFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrintWM = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FileTo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Direction = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Scaling = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PageSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SelFrom = new System.Windows.Forms.Button();
            this.SelTo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.MarkText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // FileFrom
            // 
            this.FileFrom.Location = new System.Drawing.Point(114, 67);
            this.FileFrom.Name = "FileFrom";
            this.FileFrom.Size = new System.Drawing.Size(301, 25);
            this.FileFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "來源檔案:";
            // 
            // PrintWM
            // 
            this.PrintWM.Location = new System.Drawing.Point(647, 55);
            this.PrintWM.Name = "PrintWM";
            this.PrintWM.Size = new System.Drawing.Size(109, 45);
            this.PrintWM.TabIndex = 2;
            this.PrintWM.Text = "套浮水印";
            this.PrintWM.UseVisualStyleBackColor = true;
            this.PrintWM.Click += new System.EventHandler(this.PrintWM_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "存放路徑:";
            // 
            // FileTo
            // 
            this.FileTo.Location = new System.Drawing.Point(114, 131);
            this.FileTo.Name = "FileTo";
            this.FileTo.Size = new System.Drawing.Size(301, 25);
            this.FileTo.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MarkText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Direction);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Scaling);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PageSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(40, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 231);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "浮水印屬性";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "(Landscape,Portrait)";
            // 
            // Direction
            // 
            this.Direction.Location = new System.Drawing.Point(94, 105);
            this.Direction.Name = "Direction";
            this.Direction.Size = new System.Drawing.Size(71, 25);
            this.Direction.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "DIRECTION:";
            // 
            // Scaling
            // 
            this.Scaling.Location = new System.Drawing.Point(94, 68);
            this.Scaling.Name = "Scaling";
            this.Scaling.Size = new System.Drawing.Size(71, 25);
            this.Scaling.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "SCALING:";
            // 
            // PageSize
            // 
            this.PageSize.Location = new System.Drawing.Point(94, 37);
            this.PageSize.Name = "PageSize";
            this.PageSize.Size = new System.Drawing.Size(71, 25);
            this.PageSize.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "PAGE_SIZE:";
            // 
            // SelFrom
            // 
            this.SelFrom.Location = new System.Drawing.Point(421, 67);
            this.SelFrom.Name = "SelFrom";
            this.SelFrom.Size = new System.Drawing.Size(83, 25);
            this.SelFrom.TabIndex = 6;
            this.SelFrom.Text = "選擇檔案";
            this.SelFrom.UseVisualStyleBackColor = true;
            this.SelFrom.Click += new System.EventHandler(this.SelFrom_Click);
            // 
            // SelTo
            // 
            this.SelTo.Location = new System.Drawing.Point(421, 130);
            this.SelTo.Name = "SelTo";
            this.SelTo.Size = new System.Drawing.Size(83, 26);
            this.SelTo.TabIndex = 7;
            this.SelTo.Text = "選擇路徑";
            this.SelTo.UseVisualStyleBackColor = true;
            this.SelTo.Click += new System.EventHandler(this.SelTo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "套印內容:";
            // 
            // MarkText
            // 
            this.MarkText.Location = new System.Drawing.Point(94, 142);
            this.MarkText.Name = "MarkText";
            this.MarkText.Size = new System.Drawing.Size(71, 25);
            this.MarkText.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelTo);
            this.Controls.Add(this.SelFrom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FileTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PrintWM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileFrom);
            this.Name = "Form1";
            this.Text = "WaterMarkTool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrintWM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Direction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Scaling;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PageSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelFrom;
        private System.Windows.Forms.Button SelTo;
        private System.Windows.Forms.TextBox MarkText;
        private System.Windows.Forms.Label label7;
    }
}

