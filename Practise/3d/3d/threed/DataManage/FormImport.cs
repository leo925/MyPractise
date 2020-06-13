using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using threed.Modle;

namespace threed.DataManage
{
    public partial class FormImport : Form
    {
        public FormImport()
        {
            InitializeComponent();
        }
        //http://tool.cailele.com/zs/1_1.htm?kqi=2011167&endqi=2013196
        private void button1_Click(object sender, EventArgs e)
        {
            //https://www.55128.cn/zs/1_1.htm?startTerm=2018001&endTerm=2019001

            //https://datachart.500.com/sd/history/history.shtml
            //2002001 526 073 0 1 1 3 1 1 1 7 1 1 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 7 1 1 1 1 1 3 1 1 1 1 1 1 10            
            string input = string.Empty;
            input = this.textBox1.Text.Trim() + Environment.NewLine;
          

            string []lines = input.Split(new string []{Environment.NewLine.ToString() }, StringSplitOptions.RemoveEmptyEntries);
            #region
            string a = "", b = "", c = string.Empty;
            string version = "";
            MThreed mThreed = new MThreed();
            List<MThreed> lists = new List<MThreed>();
            #endregion
            if (lines != null)
            {
                foreach (var line in lines)
                {
                    if(string.IsNullOrEmpty(line))continue  ;

                    string delimiter = " ";
                    if (line.Contains("  "))
                    {
                        delimiter = "   ";
                    }
                    else if (line.Contains("\t"))
                    {
                        delimiter = "\t";
                    }
                    else
                    {
                        delimiter = " ";
                    }


                    string[] strs = line.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                    if (strs == null || strs.Length < 1) continue;
                    mThreed = new MThreed();
                    version = strs[0].ToString().Trim();
                    if (version == "2010190")//for test
                    { }
                    string number = int.Parse(strs[2].Trim()).ToString("000");
                    string year = version.Substring(0, 4);
                    int dayCount = int.Parse(version.Substring(4));
                    DateTime dt = new DateTime(int.Parse(year), 1, 1);
                    dt = dt.AddDays(dayCount - 1);
                    a = number[0].ToString();
                    b = number[1].ToString();
                    c = number[2].ToString();;
                    mThreed.a = a;
                    mThreed.b = b;
                    mThreed.c = c;
                    mThreed.dt = dt;
                    mThreed.version = version;

                    lists.Add(mThreed);
                }
            }
            int successCount = 0; int failedCount = 0;
            foreach (MThreed thread in lists)
            {
                try
                {
                    InsertOneRecord(thread);
                    successCount++;
                }
                catch
                {
                    failedCount++;
                }
            }
            if (failedCount >= 1)
            {
                MessageBox.Show("there are " + failedCount + " record fail to import!");
            }
            MessageBox.Show("there are " + successCount + " record succeed to import!");

            button2_Click(null, null);
        }

        private void InsertOneRecord(MThreed m)
        {
            string a = m.a; string b = m.b, c = m.c, version = m.version;
            DateTime dt = m.dt;
            string sql = "insert into threed(a,b,c,version) values('" + a + "','" + b + "','" + c + "','" + version + "')";
            IDbConnection con = DataHelper.GetCon();
            DataHelper.ExecuteNonQuery(con, sql, CommandType.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = " update threed set  gap1=convert(int,b)-convert(int,a), gap2=convert(int,c)-convert(int,b),sum= convert(int,a)+convert(int,b)+convert(int,c)";
            //update 大中小
            string sql2 = @" update threed set hundred=case when a<4 then '小'
    when a>=4 and a<=6 then '中'    when a>6 then '大'
   end,ten=case when b<4 then '小'
    when b>=4 and b<=6 then '中'
    when b>6 then '大'
   end,
   one=case when c<4 then '小'
    when c>=4 and c<=6 then '中'
    when c>6 then '大' end";
            try
            {
                IDbConnection con = DataHelper.GetCon();
                DataHelper.ExecuteNonQuery(con, sql, CommandType.Text);
                MessageBox.Show("seccuss");
            }
            catch
            {
                MessageBox.Show("error");
            }


        }
    }
}
