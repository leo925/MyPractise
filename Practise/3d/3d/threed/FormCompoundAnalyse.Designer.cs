namespace threed
{
    partial class FormCompoundAnalyse
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnanalyse = new System.Windows.Forms.Button();
            this.checkSix = new System.Windows.Forms.CheckBox();
            this.btnGetMost = new System.Windows.Forms.Button();
            this.txtCom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 24);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(112, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "generate data";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(758, 520);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnanalyse
            // 
            this.btnanalyse.Location = new System.Drawing.Point(150, 24);
            this.btnanalyse.Name = "btnanalyse";
            this.btnanalyse.Size = new System.Drawing.Size(112, 23);
            this.btnanalyse.TabIndex = 2;
            this.btnanalyse.Text = "analyse data";
            this.btnanalyse.UseVisualStyleBackColor = true;
            this.btnanalyse.Click += new System.EventHandler(this.btnanalyse_Click);
            // 
            // checkSix
            // 
            this.checkSix.AutoSize = true;
            this.checkSix.Location = new System.Drawing.Point(290, 30);
            this.checkSix.Name = "checkSix";
            this.checkSix.Size = new System.Drawing.Size(78, 16);
            this.checkSix.TabIndex = 3;
            this.checkSix.Text = "checkBox1";
            this.checkSix.UseVisualStyleBackColor = true;
            // 
            // btnGetMost
            // 
            this.btnGetMost.Location = new System.Drawing.Point(911, 38);
            this.btnGetMost.Name = "btnGetMost";
            this.btnGetMost.Size = new System.Drawing.Size(75, 23);
            this.btnGetMost.TabIndex = 4;
            this.btnGetMost.Text = "GetMost";
            this.btnGetMost.UseVisualStyleBackColor = true;
            this.btnGetMost.Click += new System.EventHandler(this.btnGetMost_Click);
            // 
            // txtCom
            // 
            this.txtCom.Location = new System.Drawing.Point(776, 67);
            this.txtCom.Multiline = true;
            this.txtCom.Name = "txtCom";
            this.txtCom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCom.Size = new System.Drawing.Size(210, 293);
            this.txtCom.TabIndex = 5;
            // 
            // FormCompoundAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 599);
            this.Controls.Add(this.txtCom);
            this.Controls.Add(this.btnGetMost);
            this.Controls.Add(this.checkSix);
            this.Controls.Add(this.btnanalyse);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "FormCompoundAnalyse";
            this.Text = "FormCompoundAnalyse";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnanalyse;
        private System.Windows.Forms.CheckBox checkSix;
        private System.Windows.Forms.Button btnGetMost;
        private System.Windows.Forms.TextBox txtCom;
    }
}