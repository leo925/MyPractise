using System;
using System.Collections.Generic;

namespace WebTestDbFirst.Models.Scaffold
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public long? ContactId { get; set; }

        public ContactDetails Contact { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
