namespace threed
{
    partial class FormDisplayData
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtgap = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt2number = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txt2numberAmount = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txtCom = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(652, 496);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(670, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "根据gap过滤：";
            // 
            // txtgap
            // 
            this.txtgap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtgap.Location = new System.Drawing.Point(670, 28);
            this.txtgap.MaxLength = 10000000;
            this.txtgap.Multiline = true;
            this.txtgap.Name = "txtgap";
            this.txtgap.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtgap.Size = new System.Drawing.Size(336, 190);
            this.txtgap.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "filter by gap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt2number
            // 
            this.txt2number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2number.Location = new System.Drawing.Point(672, 263);
            this.txt2number.MaxLength = 10000000;
            this.txt2number.Multiline = true;
            this.txt2number.Name = "txt2number";
            this.txt2number.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt2number.Size = new System.Drawing.Size(336, 111);
            this.txt2number.TabIndex = 5;
            this.txt2number.Text = "inpup number";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(670, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "filter by 2number";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt2numberAmount
            // 
            this.txt2numberAmount.Location = new System.Drawing.Point(819, 381);
            this.txt2numberAmount.Name = "txt2numberAmount";
            this.txt2numberAmount.Size = new System.Drawing.Size(100, 21);
            this.txt2numberAmount.TabIndex = 7;
            this.txt2numberAmount.Text = "6";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(810, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "select by gap";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "input gaps";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(687, 540);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "filter by composite";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtCom
            // 
            this.txtCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCom.Location = new System.Drawing.Point(687, 408);
            this.txtCom.MaxLength = 10000000;
            this.txtCom.Multiline = true;
            this.txtCom.Name = "txtCom";
            this.txtCom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCom.Size = new System.Drawing.Size(301, 116);
            this.txtCom.TabIndex = 11;
            this.txtCom.Text = "inpup number";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(27, 531);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "refresh";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormDisplayData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 627);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtCom);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txt2numberAmount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt2number);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtgap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDisplayData";
            this.Text = "FormDisplayData";
            this.Load += new System.EventHandler(this.FormDisplayData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtgap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt2number;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt2numberAmount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtCom;
        private System.Windows.Forms.Button button5;
    }
}