namespace threed
{
    partial class FormCustomGroupByMe
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMaxMinusNowLeftout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkmaxminusnow = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtNumbertofind = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.radioMax_now = new System.Windows.Forms.RadioButton();
            this.radioNowlefout = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGroupAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkcount = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.chkLatest = new System.Windows.Forms.CheckBox();
            this.txtOmitLatest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1111, 517);
            this.dataGridView1.TabIndex = 1;
            // 
            // txtMaxMinusNowLeftout
            // 
            this.txtMaxMinusNowLeftout.Location = new System.Drawing.Point(276, 14);
            this.txtMaxMinusNowLeftout.Name = "txtMaxMinusNowLeftout";
            this.txtMaxMinusNowLeftout.Size = new System.Drawing.Size(100, 21);
            this.txtMaxMinusNowLeftout.TabIndex = 2;
            this.txtMaxMinusNowLeftout.Text = "-9999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "max-now leftout";
            // 
            // chkmaxminusnow
            // 
            this.chkmaxminusnow.AutoSize = true;
            this.chkmaxminusnow.Location = new System.Drawing.Point(951, 19);
            this.chkmaxminusnow.Name = "chkmaxminusnow";
            this.chkmaxminusnow.Size = new System.Drawing.Size(66, 16);
            this.chkmaxminusnow.TabIndex = 4;
            this.chkmaxminusnow.Text = "max-now";
            this.chkmaxminusnow.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "hilightNumber";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtNumbertofind
            // 
            this.txtNumbertofind.Location = new System.Drawing.Point(492, 13);
            this.txtNumbertofind.Name = "txtNumbertofind";
            this.txtNumbertofind.Size = new System.Drawing.Size(100, 21);
            this.txtNumbertofind.TabIndex = 6;
            this.txtNumbertofind.Text = "999";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(12, 584);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioMax_now
            // 
            this.radioMax_now.AutoSize = true;
            this.radioMax_now.Checked = true;
            this.radioMax_now.Location = new System.Drawing.Point(6, 14);
            this.radioMax_now.Name = "radioMax_now";
            this.radioMax_now.Size = new System.Drawing.Size(101, 16);
            this.radioMax_now.TabIndex = 8;
            this.radioMax_now.TabStop = true;
            this.radioMax_now.Text = "max-nowlefout";
            this.radioMax_now.UseVisualStyleBackColor = true;
            // 
            // radioNowlefout
            // 
            this.radioNowlefout.AutoSize = true;
            this.radioNowlefout.Location = new System.Drawing.Point(6, 32);
            this.radioNowlefout.Name = "radioNowlefout";
            this.radioNowlefout.Size = new System.Drawing.Size(83, 16);
            this.radioNowlefout.TabIndex = 9;
            this.radioNowlefout.Text = "nowleftout";
            this.radioNowlefout.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMax_now);
            this.groupBox1.Controls.Add(this.radioNowlefout);
            this.groupBox1.Location = new System.Drawing.Point(610, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 54);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // txtGroupAmount
            // 
            this.txtGroupAmount.Location = new System.Drawing.Point(276, 34);
            this.txtGroupAmount.Name = "txtGroupAmount";
            this.txtGroupAmount.Size = new System.Drawing.Size(100, 21);
            this.txtGroupAmount.TabIndex = 11;
            this.txtGroupAmount.Text = "40";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "how many group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "以下可以不填，就一直找最小的";
            // 
            // txtcount
            // 
            this.txtcount.Location = new System.Drawing.Point(492, 40);
            this.txtcount.Name = "txtcount";
            this.txtcount.Size = new System.Drawing.Size(100, 21);
            this.txtcount.TabIndex = 14;
            this.txtcount.Text = "40";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "count";
            // 
            // chkcount
            // 
            this.chkcount.AutoSize = true;
            this.chkcount.Location = new System.Drawing.Point(749, 11);
            this.chkcount.Name = "chkcount";
            this.chkcount.Size = new System.Drawing.Size(108, 16);
            this.chkcount.TabIndex = 16;
            this.chkcount.Text = "consider count";
            this.chkcount.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(913, 584);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "produce number by allnumbers";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chkLatest
            // 
            this.chkLatest.AutoSize = true;
            this.chkLatest.Location = new System.Drawing.Point(749, 34);
            this.chkLatest.Name = "chkLatest";
            this.chkLatest.Size = new System.Drawing.Size(90, 16);
            this.chkLatest.TabIndex = 18;
            this.chkLatest.Text = "omit latest";
            this.chkLatest.UseVisualStyleBackColor = true;
            // 
            // txtOmitLatest
            // 
            this.txtOmitLatest.Location = new System.Drawing.Point(845, 32);
            this.txtOmitLatest.Name = "txtOmitLatest";
            this.txtOmitLatest.Size = new System.Drawing.Size(100, 21);
            this.txtOmitLatest.TabIndex = 19;
            this.txtOmitLatest.Text = "200";
            // 
            // FormCustomGroupByMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 616);
            this.Controls.Add(this.txtOmitLatest);
            this.Controls.Add(this.chkLatest);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chkcount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtcount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGroupAmount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtNumbertofind);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkmaxminusnow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaxMinusNowLeftout);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "FormCustomGroupByMe";
            this.Text = "Leo CustomGroup";
            this.Load += new System.EventHandler(this.FormCustomGroupByMe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMaxMinusNowLeftout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkmaxminusnow;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtNumbertofind;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioMax_now;
        private System.Windows.Forms.RadioButton radioNowlefout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGroupAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkcount;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox chkLatest;
        private System.Windows.Forms.TextBox txtOmitLatest;
    }
}