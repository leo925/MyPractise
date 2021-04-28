using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace threed
{
    public partial class FormSum : Form
    {
        public FormSum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sum = this.textBox1.Text.Trim();
            IDbConnection con = DataHelper.GetCon();
            DataSet ds = null;
            string sqlWhere = "";
            if (sum.Length >= 1)
            {
                sqlWhere += " and sum='"+sum+"' ";
            }
            string sql = @" select sum,count(*) count, 0 as maxleftout,0 as nowleftout,0 as maxleftout_nowleftout,0 as averageleftout,'' as allleftout
                       from threed  where 1=1 {0} group by sum order by count(*)desc  ";
            sql = string.Format(sql, sqlWhere);
            ds = DataHelper.ExecuteDataSet(con, sql, CommandType.Text);
            dataGridView1.DataSource = ds.Tables[0];
            this.label1.Text = ds.Tables[0].Rows.Count.ToString();
            dtThreed = ds.Tables[0];
        }
        DataTable dtThreed = null;
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = " select a,b,c,version from threed order by version asc ";
            IDbConnection con = DataHelper.GetCon();
            dtThreed = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
            if (dtThreed == null || dtThreed.Rows.Count <= 0) { return; }
            List<int> averageList = new List<int>();
            List<int> allLeftoutList = new List<int>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)//(DataRow tableRow in dtThreed.Rows)
            {
                if (dr.IsNewRow) return;
                if (dr.Cells["sum"].Value == null) return;
                int maxLeftover = 0;
                int leftOverTemp = 0;
                averageList = new List<int>();
                  allLeftoutList = new List<int>();
                int sum = int.Parse(dr.Cells["sum"].Value.ToString());
                //int gap22 = int.Parse(dr.Cells["gap2"].Value.ToString());
                foreach (DataRow tableRow in dtThreed.Rows)//(DataGridViewRow dr in dataGridView1 .Rows )
                {
                    leftOverTemp++;
                    string a = tableRow["a"].ToString().Trim();
                    string b = tableRow["b"].ToString().Trim();
                    string c = tableRow["c"].ToString().Trim();
                    int sum1 = int.Parse(b) + int.Parse(a) + int.Parse(c);
                    if (sum == sum1)
                    {
                        if (leftOverTemp > maxLeftover)
                        {
                            if (maxLeftover != 0)
                            {
                                averageList.Add(maxLeftover);
                            }
                            maxLeftover = leftOverTemp;
                        }
                        if (maxLeftover != 0)
                        {
                            allLeftoutList.Add(leftOverTemp);
                        }
                        leftOverTemp = 0;
                    }
                }
                dr.Cells["maxleftout"].Value = maxLeftover.ToString();
                dr.Cells["nowleftout"].Value = leftOverTemp;
                if (sum == 0)
                {

                }
                dr.Cells["maxleftout_nowleftout"].Value = (maxLeftover - leftOverTemp).ToString();
                int sumsum = 0;
                foreach (int s in averageList)
                {
                    sumsum = sumsum + s;
                }
                if (averageList.Count >= 1)
                { 
                dr.Cells["averageleftout"].Value = sumsum /averageList .Count ;
                }
                allLeftoutList.Sort();
                allLeftoutList.Reverse();
                string allLeftOut="";
                foreach (int lo in allLeftoutList)
                {
                    allLeftOut += lo.ToString()+","; 
                }
                if (allLeftOut.EndsWith(","))
                {
                    allLeftOut = allLeftOut.Substring(0, allLeftOut.Length - 1);
                }
                dr.Cells["allleftout"].Value = allLeftOut.ToString();
            }
        }
    }
}
