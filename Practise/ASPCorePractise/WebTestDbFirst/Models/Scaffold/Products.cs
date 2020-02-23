using System;
using System.Collections.Generic;

namespace WebTestDbFirst.Models.Scaffold
{
    public partial class Products
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Color { get; set; }
        public bool InStock { get; set; }
        public long SupplierId { get; set; }

        public Suppliers Supplier { get; set; }
    }
}
