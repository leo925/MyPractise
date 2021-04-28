using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using threed.Modle;

namespace threed
{
    public partial class 大中小 : Form
    {
        public 大中小()
        {
            InitializeComponent();
        }
        List<string> allRanklist = null;

        DataTable dtOrigin = new DataTable();
        DataTable dtThreed;
        private void 大中小_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = @" select COUNT(*) as amount,hundred,ten,one,
        0 as maxleftout,0 as nowleftout,0 as maxleftout_nowleftout ,'' as allleftout  from [dbo].[threed]
  group by hundred,ten,one order by  count(*) desc";


            IDbConnection con = DataHelper.GetCon();
            DataSet ds = null;
            //bind 

            this.dataGridView1.DataSource = allRanklist;
            //sql = string.Format(sql, sqlWhere);
            ds = DataHelper.ExecuteDataSet(con, sql, CommandType.Text);
            dataGridView1.DataSource = ds.Tables[0];
            //this.label1.Text = ds.Tables[0].Rows.Count.ToString();
            dtOrigin = ds.Tables[0];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = " select a,b,c,version from threed order by version asc ";
            IDbConnection con = DataHelper.GetCon();
            dtThreed = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
            if (dtThreed == null || dtThreed.Rows.Count <= 0) { return; }


            foreach (DataGridViewRow dr in dataGridView1.Rows)//(DataRow tableRow in dtThreed.Rows)
            {
                var allLeftoutList = new List<int>();
                if (dr.IsNewRow) return;
                if (dr.Cells["hundred"].Value == null) return;

                int maxLeftover = 0;
                int leftOverTemp = 0;

                string hundred = dr.Cells["hundred"].Value.ToString();
                string ten = dr.Cells["ten"].Value.ToString();
                string one = dr.Cells["one"].Value.ToString();


                string hundred2="";
                string ten2="";
                string one2 = "";

                foreach (DataRow tableRow in dtThreed.Rows)//(DataGridViewRow dr in dataGridView1 .Rows )
                {
                    leftOverTemp++;
                    string a = tableRow["a"].ToString().Trim();
                    string b = tableRow["b"].ToString().Trim();
                    string c = tableRow["c"].ToString().Trim();
                    hundred2 = GetRank(a);
                    ten2 = GetRank(b);
                    one2 = GetRank(c);

                    if (hundred2 == hundred && ten2 == ten && one2 == one)//equal
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




            }

        }

        private string GetRank(string v)
        {
            if (int.Parse(v) <= 3)
            {
                return "小";
            }
            else if (int.Parse(v) >= 4 && int.Parse(v) <= 6)
            {
                return "中";
            }
            else { return "大"; }
        }
    }
}
