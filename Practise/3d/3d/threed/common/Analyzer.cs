using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace threed
{
    public class Analyzer
    {
        public static DataTable getDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("index", typeof(int));
            dt.Columns.Add("number");
            dt.Columns.Add("count", typeof(int));

            dt.Columns.Add("maxLeftout", typeof(int));
            dt.Columns.Add("nowLeftout", typeof(int));
            dt.Columns.Add("max-nowLeftout", typeof(int));
            dt.Columns.Add("allLeftout");
            return dt;
        }

        public void M()
        {



            DataTable dt = getDT();

            List<string> allNumberLIst = new List<string>();
            Random r = new Random();
            while (true)
            {
                int value = r.Next(0, 1000);

                if (!allNumberLIst.Contains(value.ToString("000")))
                {
                    allNumberLIst.Add(value.ToString("000"));

                    if (1000 == allNumberLIst.Count)
                    {
                        break;
                    }
                }
            }
            string sql = " select a,b,c,version from threed order by version asc ";
            IDbConnection con = DataHelper.GetCon();
            DataTable dtThreed = DataHelper.ExecuteDataSet(con, sql, CommandType.Text).Tables[0];
            int nowLeftOut = 0;
            List<int> allLeftOut = new List<int>();
            int maxLeftou = 0;
            int index = 0;
            int count = 0;
            int hundredPlaceLeftout = 0;
            Dictionary<int, int> hundredLeftouts = new Dictionary<int, int>();
            foreach (string number in allNumberLIst)
            {
                count = 0;
                index++;
                allLeftOut = new List<int>(); maxLeftou = 0; nowLeftOut = 0; allNumberLIst = new List<string>();
                foreach (DataRow dr in dtThreed.Rows)
                {
                    nowLeftOut++;

                    if (dr["a"].ToString() + dr["b"].ToString() + dr["c"].ToString() == number)
                    {
                        count++;
                        allLeftOut.Add(nowLeftOut);


                        hundredPlaceLeftout = nowLeftOut / 100;
                        if (hundredLeftouts.Keys.Contains(hundredPlaceLeftout))
                        {
                            int val = hundredLeftouts[hundredPlaceLeftout];
                            val++;
                            hundredLeftouts[hundredPlaceLeftout] = val;
                        }
                        else
                        {
                            hundredLeftouts.Add(hundredPlaceLeftout, 1);
                        }


                        if (nowLeftOut > maxLeftou)
                        {
                            maxLeftou = nowLeftOut;
                        }
                        nowLeftOut = 0;
                    }
                }
                string allLeftoutStr = "";
                //sort  
                allLeftOut.Sort();
                foreach (int lo in allLeftOut)
                {
                    allLeftoutStr += lo.ToString() + ",";
                }

                dt.LoadDataRow(new object[] { index, number, count, maxLeftou, nowLeftOut, maxLeftou - nowLeftOut, allLeftoutStr }, true);
            }

           // this.dataGridView1.DataSource = dt;

            var sortedHundredLeftouts = hundredLeftouts.OrderBy(h => h.Value).ToList();
            Console.Write(hundredLeftouts.Count);



        }

        //exceelLevel：1: largest missing  2 means second largest missing
        public void CalculateNumbers(int exceedLevel,int groupNumber)
        {
            DataTable dt = new DataTable();

            

        }

        


    }
}
