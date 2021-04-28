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
    public partial class FormCustomGroup : Form
    {
        public FormCustomGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nowLeftout = int.Parse (txt .Text .Trim() );
            string sql = string.Format(" select a,b,c ,count(*) as _count from threed   group by a,b,c order by count(*) desc  ");
            IDbConnection con = DataHelper.GetCon();
            DataTable dtTopHotNumber = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
            sql = "select a,b,c from threed order by version desc ";
            con = DataHelper.GetCon();
            DataTable dtAllHisNumber = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
            string a, b, c;


            DataTable dt = new DataTable();
            dt.Columns.Add("index", typeof(int));
            dt.Columns.Add("a", typeof(int));
            dt.Columns.Add("b", typeof(int));
            dt.Columns.Add("c", typeof(int));
            dt.Columns.Add("count", typeof(int));
            dt.Columns.Add("nowleftout", typeof(string));
            dt.Columns.Add("gap1", typeof(int));
            dt.Columns.Add("gap2", typeof(int));
            dt.Columns.Add("sum", typeof(int));
            dt.Columns.Add("selected");
          //  return dt;

           
            int index = 0;
            foreach (DataRow dr in dtTopHotNumber.Rows )
            {
                a = dr["a"].ToString();
                b = dr["b"].ToString();
                c = dr["c"].ToString();
                int leftout = 0;
                foreach (DataRow dr1 in dtAllHisNumber.Rows )
                {
                    leftout++;
                    if (a + b + b == dr1["a"].ToString() + dr1["b"].ToString() + dr1["c"].ToString())
                    {
                        //leftout = 0;
                        if (leftout >= nowLeftout)
                        {

                            index++;
                            dt.LoadDataRow(new object[] {index,a,b,c,dr["_count"].ToString (),leftout,
                                int.Parse (b)-int.Parse (a) ,int.Parse (c)-int.Parse (b),int.Parse (a)+int.Parse (b)+int.Parse (c),"" }, true);
                            leftout = 0;
                            break;
                        }
                        break;
                    }
                    else
                    {
                       
                    }
                }
            }

            this.dataGridView1.DataSource = dt;















            return;
            Random r = new Random();
            List<string> groupList = new List<string>();
            List<string[]> allgroupsList = new List<string[]>();
            List<string> allNumberLIst = new List<string>();
            int count = 0;
            while (true)
            {
                int value = r.Next(0, 1000);
                if (!allNumberLIst.Contains(value.ToString("000"))) 
                {
                    allNumberLIst.Add(value.ToString("000"));
                    count++;
                    if (count == 20)
                    {
                        groupList.Clear();
                        count = 0;
                        //allgroupsList .Add (
                    }
                }
            }
        }
    }
}
