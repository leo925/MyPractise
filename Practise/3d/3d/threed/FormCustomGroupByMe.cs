using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace threed
{
    public partial class FormCustomGroupByMe : Form
    {
        public FormCustomGroupByMe()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            if (t != null)
            {
                t.Abort();
            }
            base.OnClosed(e);
        }
        Thread t = null;
        int g_maxnowLeftOut = 0;
        int g_maxnowminusmaxleftout = 0;
        int g_count = 0;
        DataTable g_dt = null;
        enum EnumConpare { min_maxminusnow, nowmaxleftout }  ;
        private void button1_Click(object sender, EventArgs e)
        {
            bool threadStop = false;
            EnumConpare enumConpare = EnumConpare.min_maxminusnow;
            if (radioMax_now.Checked)
            {
                enumConpare = EnumConpare.min_maxminusnow;
            }
            else if (radioNowlefout.Checked)
            {
                enumConpare = EnumConpare.nowmaxleftout;
            }
            t = new Thread(delegate()
            {
                generate();
                // if (chkmaxminusnow.Checked)
                // {
                int imputNumber = int.Parse(this.txtMaxMinusNowLeftout.Text.Trim());
                while (true)
                {
                    bool found = false;
                    //this.Invoke(new MethodInvoker(delegate
                    //{
                        foreach (DataRow  dr in dt.Rows )
                        {
                            if (dr["max-nowLeftout"] == null) break;
                            int value = int.Parse(dr["max-nowLeftout"].ToString());
                            int max = int.Parse(dr["maxLeftout"].ToString());
                            int now = int.Parse(dr["nowLeftout"].ToString());
                            int count = int.Parse(dr["count"].ToString());
                            int specifyCount = int.Parse (this.txtcount .Text.Trim ()) ;
                           
                            if (max - now < g_maxnowminusmaxleftout && enumConpare == EnumConpare.min_maxminusnow)
                            {
                                if (chkcount.Checked == false || count > g_count)
                                {
                                    count = g_count;
                                    g_maxnowminusmaxleftout = max - now;
                                    g_dt = dt;
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.dataGridView1.DataSource = g_dt;
                                    }));
                                }
                            }
                            if (now > g_maxnowLeftOut && enumConpare == EnumConpare.nowmaxleftout)
                            {
                                if (chkcount.Checked == false || count > g_count)
                                {
                                    count = g_count;
                                    g_maxnowLeftOut = now;
                                    g_dt = dt;
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.dataGridView1.DataSource = g_dt;
                                    }));
                                }
                            }
                            if (imputNumber!=-99999 && value <= imputNumber && count > specifyCount)
                            {
                                found = true;
                            }
                        }
                   // }
               // ));

                    if (threadStop)
                    {
                        break;
                    }
                    if (found == false)
                    {
                        generate();
                    }
                    else
                        break;

                }
                //}
            });
            t.IsBackground = true;
            t.Start();

        }
        DataTable dtAllHisNumber = null;
        DataTable dt = null;
        private void generate()
        {
            int ticketAmount = 1000;
           
            dt = new DataTable();
            dt.Columns.Add("index", typeof(int));
            dt.Columns.Add("group");
            dt.Columns.Add("count", typeof(int));

            dt.Columns.Add("maxLeftout", typeof(int));
            dt.Columns.Add("nowLeftout", typeof(int));
            dt.Columns.Add("max-nowLeftout", typeof(int));
            dt.Columns.Add("allLeftout");
            dt.Columns.Add("numbers");
          
           
            int countIngroup = int.Parse(this.txtGroupAmount.Text.Trim()) ;
            Random r = new Random();
            List<string> groupList = new List<string>();
            List<string[]> allgroupsList = new List<string[]>();
            List<string> allNumberLIst = new List<string>();
            List<string> tempList = new List<string>();
            int count = 0;


            if (dtAllHisNumber == null || dtAllHisNumber.Rows.Count > 1)
            {
                IDbConnection con = DataHelper.GetCon();
                string sql = "select a,b,c from threed order by version asc ";
                con = DataHelper.GetCon();
                dtAllHisNumber = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
            }


            List<string> omitList = new List<string>();
            if (chkLatest.Checked)//omit latest numbers
            {
                ticketAmount = ticketAmount - int.Parse(txtOmitLatest.Text.Trim());
                int omitCount = int.Parse(this.txtOmitLatest.Text.Trim());
                for (int oi = dtAllHisNumber.Rows.Count - 1; oi >= dtAllHisNumber.Rows.Count - omitCount; oi--)
                {
                    string valueOmit = dtAllHisNumber.Rows[oi]["a"].ToString() + dtAllHisNumber.Rows[oi]["b"].ToString() + dtAllHisNumber.Rows[oi]["c"].ToString();
                    omitList.Add(valueOmit);
                }
            }
            while (true)
            {
                int value = r.Next(0, 1000);
                if (omitList.Contains(value.ToString()) == true)
                { continue; }
                if (!allNumberLIst.Contains(value.ToString("000")))
                {
                    allNumberLIst.Add(value.ToString("000"));
                    tempList.Add(value.ToString("000"));
                    count++;
                    if (count ==  countIngroup)
                    {
                        allgroupsList.Add(tempList.ToArray());
                        tempList.Clear();
                        groupList.Clear();
                        count = 0;
                    }
                    if (ticketAmount / countIngroup == allgroupsList.Count)
                    {
                        break;
                    }
                }
            }

            
           
           
            int index = 0;
            int maxLeftOut = 0, nowLeftoutTemp, nowLeftOut = 0;
            List<int> allLeftout =new List<int> ();
            count = 0;
            string allNumbers = "";
            bool passfirst = false ;
            foreach (string[] strs in allgroupsList)
            {
                nowLeftoutTemp = 0; index++; allLeftout = new List<int>(); allNumbers = ""; count = 0; maxLeftOut = 0;
                passfirst = false;
                foreach (string strstr in strs)
                {
                    allNumbers += strstr + ",";
                }
                foreach (DataRow dr in dtAllHisNumber.Rows)
                {
                    nowLeftoutTemp++;

                    string hisNumber = dr["a"].ToString() + dr["b"].ToString() + dr["c"].ToString();
                    foreach (string str in strs)
                    {
                        if (str == hisNumber)
                        {
                            count++;
                            
                            if (nowLeftoutTemp > maxLeftOut)
                            {
                                maxLeftOut = nowLeftoutTemp;
                            }
                            //allLeftout = allLeftout + nowLeftoutTemp.ToString() + ",";
                            allLeftout.Add(nowLeftoutTemp);
                            nowLeftoutTemp = 0;
                            passfirst = true;
                        }
                    }
                }
                nowLeftOut = nowLeftoutTemp;
                //if (allLeftout.EndsWith(","))
                //{
                //    allLeftout = allLeftout.Substring(0, allLeftout.Length - 1);
                //}
                allLeftout.Sort();
                allLeftout.Reverse();
                string allLeftStr = "";
                foreach (int lstr in allLeftout)
                {
                    allLeftStr += lstr.ToString() + ",";
                }
                allLeftStr = allLeftStr.Substring(0, allLeftStr.Length - 1);
                dt.LoadDataRow(new object[] { index, "group" + index.ToString(), count, maxLeftOut, nowLeftOut,(maxLeftOut -nowLeftOut ) ,allLeftStr, allNumbers }, true);
            }
            this.Invoke(new MethodInvoker(delegate() {
               // this.dataGridView1.DataSource = dt;
            }));
           
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> numberLIst = new List<string>();
            string number = txtNumbertofind.Text.Trim();
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (dr.Cells["numbers"].Value == null) break;
                string value = dr.Cells["numbers"].Value.ToString();
                string[] strs = value.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string temp in strs)
                {
                    if (!numberLIst.Contains(temp))
                    {
                        numberLIst.Add(temp);
                    }
                }
                if(value .Contains (number+","))
                {
                    dr.DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (t != null && t.ThreadState == ThreadState.Background || t.ThreadState ==ThreadState .Running )
            {
                t.Abort();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a, b, c;
            int index = 0;
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            DataTable dt2 = getDt();
            foreach (DataGridViewRow dr in rows)
            {
                string numberStr = dr.Cells["numbers"].Value.ToString();
                string[] numbers = numberStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string number in numbers)
                {
                    a = int.Parse(number.Substring(0, 1));
                    b = int.Parse(number.Substring(1, 1));
                    c = int.Parse(number.Substring(2, 1));
                    index++;
                    dt2.LoadDataRow(new object[] { index, a, b, c, b - a, c - b, a + b + c, null }, true);
                }
            }
            FormDisplayData f = new FormDisplayData(dt2);
            f.Show();
        }
        private DataTable getDt()
        {
            DataTable  dt2 = new DataTable();
            dt2.Columns.Add("index", typeof(int));
            dt2.Columns.Add("a", typeof(int));
            dt2.Columns.Add("b", typeof(int));
            dt2.Columns.Add("c", typeof(int));
            dt2.Columns.Add("gap1", typeof(int));
            dt2.Columns.Add("gap2", typeof(int));
            dt2.Columns.Add("sum", typeof(int));
            dt2.Columns.Add("selected");
            return dt2;
        }

        private void FormCustomGroupByMe_Load(object sender, EventArgs e)
        {

        }
    }
}
/*
    dt.Columns.Add("index", typeof(int));
            dt.Columns.Add("group", typeof(int));
            dt.Columns.Add("count", typeof(int));
            dt.Columns.Add("numbers", typeof(int));
            dt.Columns.Add("maxLeftout", typeof(int));
            dt.Columns.Add("nowLeftout", typeof(int));
            dt.Columns.Add("allLeftout");
 */