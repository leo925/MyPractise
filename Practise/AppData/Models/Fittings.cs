using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Fittings
    {
        public Fittings()
        {
            Shoes = new HashSet<Shoes>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Shoes> Shoes { get; set; }
    }
}
