using System;
using System.Collections.Generic;

namespace WebTestDbFirst.Models.Scaffold
{
    public partial class ContactDetails
    {
        public ContactDetails()
        {
            Suppliers = new HashSet<Suppliers>();
        }

        public long Id { get; set; }
        public long? LocationId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public ContactLocation Location { get; set; }
        public ICollection<Suppliers> Suppliers { get; set; }
    }
}
