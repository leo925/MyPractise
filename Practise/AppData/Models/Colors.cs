﻿using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Colors
    {
        public Colors()
        {
            Shoes = new HashSet<Shoes>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string MainColor { get; set; }
        public string HighlightColor { get; set; }

        public ICollection<Shoes> Shoes { get; set; }
    }
}
