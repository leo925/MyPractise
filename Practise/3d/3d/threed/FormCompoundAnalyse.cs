using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace threed
{
    public partial class FormCompoundAnalyse : Form
    {
        public FormCompoundAnalyse()
        {
            InitializeComponent();
        }
        DataTable GetDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("index",typeof (int));
            dt.Columns.Add("compound");
            dt.Columns.Add("count", typeof(int));
            dt.Columns.Add("maxleftout", typeof(int));
            dt.Columns.Add("nowleftout", typeof(int));
            dt.Columns.Add("maxleftout_nowleftout", typeof(int));
            dt.Columns.Add("allleftout");
            return dt;
        }
        DataTable dtAllComposite = null;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (this.checkSix.Checked != true)
            {
                dtAllComposite = GetDT();
                List<string> existingNumbers = new List<string>();
                int index = 0;
                for (int a = 0; a <= 9; a++)
                {
                    for (int b = 1; b <= 9; b++)
                    {
                        for (int c = 2; c <= 9; c++)
                        {

                            for (int d = 3; d <= 9; d++)
                            {
                                for (int ee = 4; ee <= 9; ee++)
                                {
                                    List<string> checkDuplicate = new List<string>();
                                    checkDuplicate.Add(a.ToString());
                                    if (!checkDuplicate.Contains(b.ToString()))
                                    {
                                        checkDuplicate.Add(b.ToString());
                                    }
                                    if (!checkDuplicate.Contains(c.ToString()))
                                    {
                                        checkDuplicate.Add(c.ToString());

                                    }
                                    if (!checkDuplicate.Contains(d.ToString()))
                                    {
                                        checkDuplicate.Add(d.ToString());
                                    }
                                    if (!checkDuplicate.Contains(ee.ToString()))
                                    {
                                        checkDuplicate.Add(ee.ToString());
                                    }
                                    if (checkDuplicate.Count == 5)
                                    {
                                        /* check composite with same number, but different order */
                                        bool IsSameNumber = false;
                                        foreach (string existingNumbersStr in existingNumbers)
                                        {
                                            if (existingNumbersStr.Contains(a.ToString()) && existingNumbersStr.Contains(b.ToString()) && existingNumbersStr.Contains(c.ToString())
                                                && existingNumbersStr.Contains(d.ToString()) && existingNumbersStr.Contains(ee.ToString()))
                                            {
                                                IsSameNumber = true; ;//the number has been in dt
                                            }
                                        }
                                        if (IsSameNumber == false)
                                        {
                                            dtAllComposite.LoadDataRow(new object[] { index++, a.ToString() + "," + b.ToString() + "," + c.ToString() + "," +
                                    d.ToString() + "," + ee.ToString() }, true);

                                            existingNumbers.Add(a.ToString() + "," + b.ToString() + "," + c.ToString() + "," +
                                            d.ToString() + "," + ee.ToString());
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }
                            }
                        }
                    }

                }
                this.dataGridView1.DataSource = dtAllComposite;
            }
            else
            {
                dtAllComposite = GetDT();
                List<string> existingNumbers = new List<string>();
                int index = 0;
                for (int a = 0; a <= 9; a++)
                {
                    for (int b = 1; b <= 9; b++)
                    {
                        for (int c = 2; c <= 9; c++)
                        {

                            for (int d = 3; d <= 9; d++)
                            {
                                for (int ee = 4; ee <= 9; ee++)
                                {
                                    for (int f = 5; f <= 9; f++)
                                    {
                                        List<string> checkDuplicate = new List<string>();
                                        checkDuplicate.Add(a.ToString());
                                        if (!checkDuplicate.Contains(b.ToString()))
                                        {
                                            checkDuplicate.Add(b.ToString());
                                        }
                                        if (!checkDuplicate.Contains(c.ToString()))
                                        {
                                            checkDuplicate.Add(c.ToString());

                                        }
                                        if (!checkDuplicate.Contains(d.ToString()))
                                        {
                                            checkDuplicate.Add(d.ToString());
                                        }
                                        if (!checkDuplicate.Contains(ee.ToString()))
                                        {
                                            checkDuplicate.Add(ee.ToString());
                                        }
                                        if (!checkDuplicate.Contains(f.ToString()))
                                        {
                                            checkDuplicate.Add(f.ToString());
                                        }
                                        if (checkDuplicate.Count == 6)
                                        {
                                            /* check composite with same number, but different order */
                                            bool IsSameNumber = false;
                                            foreach (string existingNumbersStr in existingNumbers)
                                            {
                                                if (existingNumbersStr.Contains(a.ToString()) && existingNumbersStr.Contains(b.ToString()) && existingNumbersStr.Contains(c.ToString())
                                                    && existingNumbersStr.Contains(d.ToString()) && existingNumbersStr.Contains(ee.ToString()) && existingNumbersStr.Contains(f.ToString()))
                                                {
                                                    IsSameNumber = true; ;//the number has been in dt
                                                }
                                            }
                                            if (IsSameNumber == false)
                                            {
                                                dtAllComposite.LoadDataRow(new object[] { index++, a.ToString() + "," + b.ToString() + "," + c.ToString() + "," +
                                    d.ToString() + "," + ee.ToString()+","+f.ToString () }, true);

                                                existingNumbers.Add(a.ToString() + "," + b.ToString() + "," + c.ToString() + "," +
                                                d.ToString() + "," + ee.ToString()+","+f.ToString ());
                                            }
                                        }
                                        else
                                        {
                                            continue;
                                        }

                                    }
                                }
                            }
                        }
                    }

                }
                this.dataGridView1.DataSource = dtAllComposite;
            }
        }
        DataTable dtThreed = null;
        private void btnanalyse_Click(object sender, EventArgs e)
        {
            if (checkSix.Checked)// for six
            {
                string sql = " select a,b,c,version from threed order by version asc ";
                IDbConnection con = DataHelper.GetCon();
                dtThreed = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
                if (dtThreed == null || dtThreed.Rows.Count <= 0) { return; }
                List<int> allLeftoutList = new List<int>();
                int loop = 0;
                foreach (DataGridViewRow dr in dataGridView1.Rows)//(DataRow tableRow in dtThreed.Rows)
                {
                    loop++;//for test, to see how many loops 
                    allLeftoutList = new List<int>();
                    if (dr.IsNewRow) return;
                    if (dr.Cells["compound"].Value == null) return;
                    int maxLeftover = 0;
                    int leftOverTemp = 0;
                    string composite = dr.Cells["compound"].Value.ToString();


                    foreach (DataRow tableRow in dtThreed.Rows)//(DataGridViewRow dr in dataGridView1 .Rows )
                    {
                        leftOverTemp++;
                        string a = tableRow["a"].ToString().Trim();
                        string b = tableRow["b"].ToString().Trim();
                        string c = tableRow["c"].ToString().Trim();
                        if (composite.Contains(a) && composite.Contains(b) && composite.Contains(c))//contains the number
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


                    dr.Cells["count"].Value = allLeftoutList.Count;

                    dr.Cells["maxleftout_nowleftout"].Value = (maxLeftover - leftOverTemp).ToString();

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
            else
            {
                string sql = " select a,b,c,version from threed order by version asc ";
                IDbConnection con = DataHelper.GetCon();
                dtThreed = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
                if (dtThreed == null || dtThreed.Rows.Count <= 0) { return; }
                List<int> allLeftoutList = new List<int>();
                int loop = 0;
                foreach (DataGridViewRow dr in dataGridView1.Rows)//(DataRow tableRow in dtThreed.Rows)
                {
                    loop++;//for test, to see how many loops 
                    allLeftoutList = new List<int>();
                    if (dr.IsNewRow) return;
                    if (dr.Cells["compound"].Value == null) return;
                    int maxLeftover = 0;
                    int leftOverTemp = 0;
                    string composite = dr.Cells["compound"].Value.ToString();


                    foreach (DataRow tableRow in dtThreed.Rows)//(DataGridViewRow dr in dataGridView1 .Rows )
                    {
                        leftOverTemp++;
                        string a = tableRow["a"].ToString().Trim();
                        string b = tableRow["b"].ToString().Trim();
                        string c = tableRow["c"].ToString().Trim();
                        if (composite.Contains(a) && composite.Contains(b) && composite.Contains(c))//contains the number
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


                    dr.Cells["count"].Value = allLeftoutList.Count;

                    dr.Cells["maxleftout_nowleftout"].Value = (maxLeftover - leftOverTemp).ToString();

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

        private void btnGetMost_Click(object sender, EventArgs e)
        {
            string input = this.txtCom.Text.Trim() + Environment.NewLine;
            if (input.Length <= 0)
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
            Hashtable dt=new Hashtable ();
            for (int i = 0; i <= 9; i++)
            {
                dt.Add(i, 0);
                foreach (string str in allComposite)
                {
                    if (str.Contains(i.ToString()))
                    {
                        if (dt.ContainsKey(i))
                        {
                            int count = int.Parse(dt[i].ToString());
                            dt[i] = count + 1;
                        }
                        else
                        {
                            dt.Add(i, 1);
                        }
                    }

                }
            }
             string strR="";
            for (int i = 0; i <= 9; i++)
            {
                strR += i.ToString() + ":" + dt[i].ToString ()+Environment.NewLine;
            }

            MessageBox.Show(strR);
        }
    }
}
