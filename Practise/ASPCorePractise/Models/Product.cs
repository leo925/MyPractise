using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Product
    {
        [Key]
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Comments { get; set; }
    }
}
