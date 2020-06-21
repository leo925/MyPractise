using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using threed.Modle;

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

        // IsReadData = false means retrieve data from simulating table
        public DataTable RetrieveNumbers(string datatable=null)
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

            string sql = string.Empty;
            if (string.IsNullOrEmpty(datatable))
            {
                sql = " select a,b,c,version from threed order by version asc ";
            }
            else
            {
                sql = string.Format(" select a,b,c,version from {0} order by version asc ", datatable);
            }
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
            return dt;


        }

        //exceelLevel：1: means exceed largest missing , 2 means exceed second largest missing but not largest missing... etc.
        public void ChooseNumbers(int exceedLevel,int groupNumber)
        {
            DataTable dt = RetrieveNumbers();

            List<MThreed> chosenThreeds = Common.ConvertThreedModel(dt);
            int lowerIndex = 0;
            int upperIndex = 0;
            //filter by exceedLevel
            foreach (var threed in chosenThreeds)
            {
                bool match = true;
               var allMissings= threed.AllMissings;
                if (allMissings.Count < 1)
                {
                    continue;
                }
                var nowMissing = threed.NowMissing;
                lowerIndex = allMissings.Count - exceedLevel -1 ;
                upperIndex = allMissings.Count - exceedLevel ;

                if (lowerIndex < 0 || upperIndex < 0)
                {
                    continue;
                }

                if (lowerIndex + 1 >= allMissings.Count)
                {
                    match = nowMissing >= allMissings[allMissings.Count - 1];
                }
                else
                {
                    match = nowMissing >= allMissings[lowerIndex] && nowMissing <= allMissings[upperIndex];
                }
                if (match)
                {
                    chosenThreeds.Add(threed);
                }

            }

            chosenThreeds = chosenThreeds.OrderByDescending(t => t.Count).Take(groupNumber).ToList();




        }

        


    }
}
