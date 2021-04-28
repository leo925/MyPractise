using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using threed.Modle;

namespace threed
{
    public class Common
    {

        public static List<MThreed> ConvertThreedModel(DataTable dt)
        {
            List<MThreed> models = new List<Modle.MThreed>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

           
                MThreed model = new Modle.MThreed();
                model.a = dt.Rows[i]["number"].ToString()[0].ToString();
                model.b = dt.Rows[i]["number"].ToString()[1].ToString();
                model.c = dt.Rows[i]["number"].ToString()[2].ToString();
                model.Count = int.Parse(dt.Rows[i]["count"].ToString());
                model.MaxMissing= int.Parse(dt.Rows[i]["maxLeftout"].ToString());
                model.NowMissing = int.Parse(dt.Rows[i]["nowLeftout"].ToString());
                model.AllMissings = new List<int>();
                if (dt.Rows[i]["allleftout"] != null)
                {
                    var allStr = dt.Rows[i]["allLeftout"].ToString();
                    var splites = allStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in splites)
                    {
                        model.AllMissings.Add(int.Parse(s));
                    }
                }

                models.Add(model);
            }

            return models;
        }
    }
}
