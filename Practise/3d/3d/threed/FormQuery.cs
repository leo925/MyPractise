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
    public partial class FormQuery : Form
    {
        public FormQuery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @" select [id]
      ,[version]
      ,[a]
      ,[b]
      ,[c]
      ,[date]
      ,[gap1]
      ,[gap2]
      ,[sum] from threed";
            IDbConnection con = DataHelper.GetCon();
            DataSet ds = DataHelper.ExecuteDataSet(con, sql, CommandType.Text);
            ds.Tables[0].Columns.Add("currentleftout_whenwin");
            
            //calualate each wining number's leftout when it wins
            int loopCounter = 0;
            for (int i = ds.Tables[0].Rows.Count-1; i>=0; i--)
            {
                loopCounter++;
                int a = int.Parse(ds.Tables[0].Rows[i]["a"].ToString());
                int b = int.Parse(ds.Tables[0].Rows[i]["b"].ToString());
                int c = int.Parse(ds.Tables[0].Rows[i]["c"].ToString());
                int winningNumber = (a * 100 + b * 10 + c);
                int findCounter = 0;
                for (int j = ds.Tables[0].Rows.Count - 1 - loopCounter; j >= 0; j--)
                {
                    findCounter++;
                    int a2 = int.Parse(ds.Tables[0].Rows[j]["a"].ToString());
                    int b2 = int.Parse(ds.Tables[0].Rows[j]["b"].ToString());
                    int c2 = int.Parse(ds.Tables[0].Rows[j]["c"].ToString());
                    int winningNumberFound = (a2 * 100 + b2 * 10 + c2);
                    if (winningNumberFound == winningNumber)
                    {
                        break;
                    }
                }

                ds.Tables[0].Rows[i]["currentleftout_whenwin"] = findCounter;

            }

            //calculate the number's corrunt left over
            DataTable dtLeftOver = new DataTable();
            dtLeftOver.Columns.Add("index");
            dtLeftOver.Columns.Add("number", typeof(int));
            dtLeftOver.Columns.Add("currentLeftOver",typeof(int));
            int dtLeftOverIndex=0;
            for (int q = 0; q <= 1000; q++)
            {
                int currentnumber = q;
                loopCounter = 0;
                for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    loopCounter++;
                    int a = int.Parse(ds.Tables[0].Rows[i]["a"].ToString());
                    int b = int.Parse(ds.Tables[0].Rows[i]["b"].ToString());
                    int c = int.Parse(ds.Tables[0].Rows[i]["c"].ToString());
                    int winningNumber = (a * 100 + b * 10 + c);
                    if (winningNumber == currentnumber)
                    {
                        dtLeftOverIndex++;
                        dtLeftOver.Rows.Add(dtLeftOverIndex,currentnumber, loopCounter);
                        break;//to get the all left over, I don't break 
                    }
                }
            }
            dataGridViewLeftOver.DataSource = dtLeftOver;


            dataGridView1.DataSource = ds.Tables[0];
            label1.Text = ds.Tables[0].Rows.Count.ToString();

            //calculate the left out for each number
            Dictionary<int, int> numberLeftoutsTemp = new Dictionary<int, int>();
            Dictionary<int, List<int>> numberAllLeftouts = new Dictionary<int, List<int>>();
            for (int i = 0; i < 1000; i++)
            {
                numberLeftoutsTemp.Add(i, 0);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int a = int.Parse(ds.Tables[0].Rows[i]["a"].ToString());
                int b = int.Parse(ds.Tables[0].Rows[i]["b"].ToString());
                int c = int.Parse(ds.Tables[0].Rows[i]["c"].ToString());
                int currentNumber =  (a*100 + b*10 + c);
                for (int j = 0; j < 1000; j++)
                {
                    if (j == currentNumber)
                    {
                        int tempLeftOut= numberLeftoutsTemp[j] ;
                        if (numberAllLeftouts.Keys.Contains(j))
                        {
                            List<int> list = numberAllLeftouts[currentNumber];
                            list.Add(tempLeftOut);
                            list = list.OrderBy(u => u).ToList();
                            numberAllLeftouts[currentNumber] = list;

                        }
                        else
                        {
                            List<int> list = new List<int>();
                            list.Add(tempLeftOut);
                            numberAllLeftouts.Add(currentNumber, list);
                        }
                        numberLeftoutsTemp[j] = 0;
                    }
                    else
                    {
                        numberLeftoutsTemp[j] = numberLeftoutsTemp[j] + 1;
                    }
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string versionAccount = txtVersionAccountForGap.Text.Trim();
            try
            {

            }
            catch
            {
                MessageBox.Show("input number");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int checkAccount = int.Parse (txtFor2number.Text);
            List<string> twoNumberList1 = new List<string>();
            List<string> twoNumberList2 = new List<string>();
          //  List<string> twoNumberList3 = new List<string>();
            for (int i = 0; i < checkAccount; i++)
            {
                DataGridViewRow dr = dataGridView1.Rows[i];
                string a = dr.Cells["a"].Value.ToString();
                string b = dr.Cells["b"].Value.ToString();
                string c = dr.Cells["c"].Value.ToString();
                twoNumberList1.Add(a + b);
                twoNumberList2.Add(b + c);
               // twoNumberList3.Add(a + c);
            }
            int leftAmount = dataGridView1.Rows.Count - checkAccount;
            if (leftAmount > 0)
            {
                for (int i = checkAccount; i < leftAmount; i++)
                {
                    DataGridViewRow dr = dataGridView1.Rows[i];
                    string a = dr.Cells["a"].Value.ToString();
                    string b = dr.Cells["b"].Value.ToString();
                    string c = dr.Cells["c"].Value.ToString();
                    if (twoNumberList1.Contains(a + b) ||
                twoNumberList2.Contains(b + c)   )// twoNumberList3.Contains(a + c)
                    {//include 
                        dr.DefaultCellStyle.BackColor = Color.Aqua;
                    }
                    else
                    {
                        dr.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
    }
}
