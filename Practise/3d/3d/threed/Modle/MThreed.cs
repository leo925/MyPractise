using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace threed.Modle
{
    public class MThreed
    {
        public int Id { get; set; }
        public string a;
        public string b;
        public string c;
        public string version;
  

        public string MyProperty
        {
            get { return a + b + c; }
        }

        public DateTime dt;

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private int maxMissing;

        public int MaxMissing
        {
            get { return maxMissing; }
            set { maxMissing = value; }
        }

        private int nowMissing;

        public int NowMissing
        {
            get { return nowMissing; }
            set { nowMissing = value; }
        }

        public int MaxMinusNowLeftout { get; set; }

        public List<int> AllMissings { get; set; }


    }
}
