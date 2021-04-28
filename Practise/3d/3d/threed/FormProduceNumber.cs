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
    public partial class FormProduceNumber : Form
    {
        public FormProduceNumber()
        {
            InitializeComponent();
        }
        private DataTable GetDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("index",typeof (int));
            dt.Columns.Add("a", typeof(int));
            dt.Columns.Add("b", typeof(int));
            dt.Columns.Add("c", typeof(int));
            dt.Columns.Add("gap1", typeof(int));
            dt.Columns.Add("gap2", typeof(int));
            dt.Columns.Add("sum", typeof(int));
            dt.Columns.Add("selected" );
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtNumber = GetDT();
            int index = 0;
            if (checkSum.Checked)//by sum
            {
                List<int> sumList = new List<int>();
                string sumStr = this.textBox1.Text.Trim() + Environment.NewLine;
                sumStr = System.Text.RegularExpressions.Regex.Replace(sumStr, "[^0-9]", ",");
                string[] sumArray = sumStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string str in sumArray)
                {
                    sumList.Add(int.Parse(str));
                }

                for (int a = 0; a < 10; a++)
                {
                    for (int b = 0; b < 10; b++)
                    {
                        for (int c = 0; c < 10; c++)
                        {
                            int sumTemp = a + b + c;
                            if (sumList.Contains(sumTemp))
                            {
                                //equal, get the number
                                index++;
                                dtNumber.LoadDataRow(new object[] {index, a, b, c,b-a,c-b, sumTemp }, true);
                            }
                        }
                    }
                }
            }
            //by gap
            else
            {
                List<int> gapList = new List<int>();
                string gapStr = this.textBox2.Text.Trim() + Environment.NewLine;
                Regex re = new Regex("(?<gap1>[-|0-9]+)[^-|0-9]+(?<gap2>[-|0-9]+).*" + Environment.NewLine);
                Match m = re.Match(gapStr);
                while (m.Success)
                {
                    int a = 0, b = 0, c = 0;
                    int gap1 = int.Parse (m.Groups["gap1"].Value.ToString() ) ;
                    int gap2 = int.Parse ( m.Groups["gap2"].Value.ToString());
                    for (int i = 0; i <= 9; i++)
                    {
                        a = i;
                        b = i + gap1;
                        c = b + gap2;
                        if (a >= 0 && a <= 9 && b >= 0 && b <= 9 && c >= 0 && c <= 9)
                        {
                            index++;
                            dtNumber.LoadDataRow(new object[] {index , a, b, c,b-a,c-b, a+b+c }, true);
                        }
                    }
                    m = m.NextMatch();

                }
            }

            FormDisplayData f = new FormDisplayData(dtNumber);
            f.Show();
        }
    }
}
