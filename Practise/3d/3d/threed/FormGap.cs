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
    public partial class FormGap : Form
    {
        public FormGap()
        {
            InitializeComponent();
        }
        DataTable dtGap = null;
        DataTable dtThreed = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string gap1, gap2, sqlWhere = ""; ;
            gap1 = txtGap1.Text.Trim();
            gap2 = txtGap2.Text.Trim();
            IDbConnection con = DataHelper.GetCon();
            DataSet ds = null;
            if (gap2.Length >= 1 || gap1.Length >= 1)
            {
                if (gap1.Length > 0)
                {
                    sqlWhere += " and gap1='" + gap1 + "'";
                }
                if (gap2.Length > 0)
                {
                    sqlWhere += " and gap2='" + gap2 + "'";
                }
            }
            string sql = @" select gap1,gap2,count(*) count, 0 as maxleftout,0 as nowleftout,0 as maxleftout_nowleftout ,'' as allleftout 
            from threed  where 1=1 {0} group by gap1,gap2 order by count(*)desc  ";
            sql = string.Format(sql, sqlWhere);
            ds = DataHelper.ExecuteDataSet(con, sql, CommandType.Text);
            dataGridView1.DataSource = ds.Tables[0];
            this.label1.Text = ds.Tables[0].Rows.Count.ToString();
            dtGap = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtGap == null || dtGap.Rows.Count <= 0)
            {
                MessageBox.Show("pls query gap first!");
            }
            string sql = " select a,b,c,version from threed order by version asc ";
            IDbConnection con = DataHelper.GetCon();
            dtThreed = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
            if (dtThreed == null || dtThreed.Rows.Count <= 0) { return; }
            List<int> allLeftoutList = new List<int>();
            if (chkCompound.Checked)
            {
                CalculateCompound();
            }
            else
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)//(DataRow tableRow in dtThreed.Rows)
                {
                    allLeftoutList = new List<int>();
                    if (dr.IsNewRow) return;
                    if (dr.Cells["gap1"].Value == null) return;
                    int maxLeftover = 0;
                    int leftOverTemp = 0;

                    int gap11 = int.Parse(dr.Cells["gap1"].Value.ToString());
                    int gap22 = int.Parse(dr.Cells["gap2"].Value.ToString());
                    foreach (DataRow tableRow in dtThreed.Rows)//(DataGridViewRow dr in dataGridView1 .Rows )
                    {
                        leftOverTemp++;
                        string a = tableRow["a"].ToString().Trim();
                        string b = tableRow["b"].ToString().Trim();
                        string c = tableRow["c"].ToString().Trim();
                        int gap1 = int.Parse(b) - int.Parse(a);
                        int gap2 = int.Parse(c) - int.Parse(b);
                        if (gap1 == gap11 && gap2 == gap22)//equal
                        {
                            if (leftOverTemp > maxLeftover)
                            {
                                maxLeftover = leftOverTemp;
                            }

                            allLeftoutList.Add(leftOverTemp);
                            leftOverTemp = 0;
                        }
                    }
                    dr.Cells["maxleftout"].Value = maxLeftover.ToString();
                    dr.Cells["nowleftout"].Value = leftOverTemp;
                    if (gap11 == 0 && gap22 == 3)
                    {

                    }
                    if (int.Parse(dr.Cells["count"].Value.ToString()) > 6)
                    {
                        dr.Cells["maxleftout_nowleftout"].Value = (maxLeftover - leftOverTemp).ToString();
                    }
                    allLeftoutList.Sort();
                    allLeftoutList.Reverse();
                    string allLeftOut = "";
                    foreach (int lo in allLeftoutList)
                    {
                        allLeftOut += lo.ToString() + ",";
                    }
                    if (allLeftOut.EndsWith(","))
                    {
                        allLeftOut = allLeftOut.Substring(0, allLeftOut.Length - 1);
                    }
                    dr.Cells["allleftout"].Value = allLeftOut.ToString();
                }
            }
        }

        private void CalculateCompound()
        {
            List<int> allLeftoutList = new List<int>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)//(DataRow tableRow in dtThreed.Rows)
            {

                allLeftoutList = new List<int>();
                if (dr.IsNewRow) return;
                if (dr.Cells["gap1"].Value == null) return;
                int maxLeftover = 0;
                int leftOverTemp = 0;

                int gap11 = int.Parse(dr.Cells["gap1"].Value.ToString());
                int gap22 = int.Parse(dr.Cells["gap2"].Value.ToString());
                //get all number by gaps
                foreach (DataRow tableRow in dtThreed.Rows)//(DataGridViewRow dr in dataGridView1 .Rows )
                {
                    leftOverTemp++;
                    string a = tableRow["a"].ToString().Trim();
                    string b = tableRow["b"].ToString().Trim();
                    string c = tableRow["c"].ToString().Trim();
                    List<string> numbers = GetNumbersByGakps(gap11, gap22);
                    bool contain = ContainCurrentNumber(numbers, int.Parse(a), int.Parse(b), int.Parse(c));
                    if (contain)//the current award number is in the gap-number-group
                    {
                        if (leftOverTemp > maxLeftover)
                        {
                            maxLeftover = leftOverTemp;
                        }

                        allLeftoutList.Add(leftOverTemp);
                        leftOverTemp = 0;
                    }
                }

                dr.Cells["maxleftout"].Value = maxLeftover.ToString();
                dr.Cells["nowleftout"].Value = leftOverTemp;

                if (int.Parse(dr.Cells["count"].Value.ToString()) > 3)
                {
                    dr.Cells["maxleftout_nowleftout"].Value = (maxLeftover - leftOverTemp).ToString();
                }
                allLeftoutList.Sort();
                allLeftoutList.Reverse();
                string allLeftOut = "";
                foreach (int lo in allLeftoutList)
                {
                    allLeftOut += lo.ToString() + ",";
                }
                if (allLeftOut.EndsWith(","))
                {
                    allLeftOut = allLeftOut.Substring(0, allLeftOut.Length - 1);
                }
                dr.Cells["allleftout"].Value = allLeftOut.ToString();
                dr.Cells["count"].Value = allLeftOut.Length.ToString();
            }
        }
        List<string> GetNumbersByGakps(int gap1, int gap2)
        {
            List<string> numbers = new List<string>();
            for (int a = 0; a <= 9; a++)
            {
                int b = a + gap1;
                int c = gap2 + b;
                if (b <= 9 && b >= 0 && c <= 9 && c >= 0)
                {
                    numbers.Add(a.ToString() + b.ToString() + c.ToString());
                }
            }
            return numbers;
        }
        bool ContainCurrentNumber(List<string> numbers, int a, int b, int c)
        {
            foreach (string number in numbers)
            { 
                int aa=int.Parse (number [0].ToString ())  ;
                  int bb=int.Parse (number [1].ToString ())  ;
                  int cc=int.Parse (number [2].ToString ())  ;
                  if (number.Contains(a.ToString()) && number.Contains(b.ToString()) && number.Contains(c.ToString()) &&
                      a + b + c == aa + bb + cc)
                  {
                      return true; 
                  } 
            }
            return false;
        }
    }
}
