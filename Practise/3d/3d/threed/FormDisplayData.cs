using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace threed
{
    public partial class FormDisplayData : Form
    {
        DataTable dtSource = null;
        public FormDisplayData()
        {
            InitializeComponent();
        }
        public FormDisplayData(DataTable dt)
        {
            InitializeComponent();
            this.dtSource = dt;
        }

        private void FormDisplayData_Load(object sender, EventArgs e)
        {
            this.label1.Text = dtSource.Rows.Count.ToString();
            this.dataGridView1.DataSource = dtSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string twoNumber = this.txt2numberAmount.Text ;
            if (twoNumber.Length <= 0)
            {
                MessageBox.Show("pls input how many latest versions to compare!");
                return;
            }
            string sql = string.Format(" select top {0} * from threed order by version desc ", twoNumber.ToString());
            IDbConnection con = DataHelper.GetCon();
            DataSet ds = DataHelper.ExecuteDataSet(con, sql, CommandType.Text);
            if (ds.Tables[0].Rows.Count >= 1)
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string gapInput = this.txtgap.Text.Trim()+Environment .NewLine ;
            if (gapInput.Length <= 0)
            {
                MessageBox.Show("pls input gaps !");
                return;
            }
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                dr.DefaultCellStyle.BackColor = Color.White;
                dr.Cells["selected"].Value = "";
            }
            Regex re = new Regex("(?<gap1>[-|0-9]+)[^-|0-9]+(?<gap2>[-|0-9]+).*" + Environment.NewLine);
            Match m = re.Match(gapInput);
                while (m.Success)
                {
                    int a = 0, b = 0, c = 0;
                    int gap1 = int.Parse(m.Groups["gap1"].Value.ToString());
                    int gap2 = int.Parse(m.Groups["gap2"].Value.ToString());
                    if (gap1 == -4 && gap2 == 5) { }
                    foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                    {
                        if (dr.Cells["a"].Value == null) break;
                        a = int.Parse(dr.Cells["a"].Value.ToString());
                        b = int.Parse(dr.Cells["b"].Value.ToString());
                        c = int.Parse(dr.Cells["c"].Value.ToString());
                        if (gap1 == b - a && gap2 == c - b)
                        {
                            dr.DefaultCellStyle.BackColor = Color.LightGreen;
                            dr.Cells["selected"].Value = "y";
                        }
                    }
                    m = m.NextMatch(); ;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = this.txtCom.Text.Trim() + Environment.NewLine;
            if (input.Length  <= 0)
            {
                MessageBox.Show("pls input ");
                return;
            }

            Regex re = new Regex("(?<number>.*)" + Environment.NewLine);
            Match m = re.Match(input);
            List<string> allComposite = new List<string>();
            while (m.Success)
            {
                string number = m.Groups["number"].Value.ToString();
                allComposite.Add(number);
                m = m.NextMatch(); ;
            }
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (dr.Cells["a"].Value == null) break;
                string a = dr.Cells["a"].Value.ToString();
                string b = dr.Cells["b"].Value.ToString();
                string c = dr.Cells["c"].Value.ToString();
                foreach (string strNumber in allComposite)
                {
                    if (strNumber.Contains(a) && strNumber.Contains(b) && strNumber.Contains(c))
                    {
                        dr.Cells["selected"].Value = "y";
                    }
                }
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (dr.Cells["a"].Value == null) break;
                dr.Cells["selected"].Value = "";
            }
        }
        
    }
}
