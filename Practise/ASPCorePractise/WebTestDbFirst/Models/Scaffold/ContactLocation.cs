using System;
using System.Collections.Generic;

namespace WebTestDbFirst.Models.Scaffold
{
    public partial class ContactLocation
    {
        public ContactLocation()
        {
            ContactDetails = new HashSet<ContactDetails>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public string LocationName { get; set; }

        public ICollection<ContactDetails> ContactDetails { get; set; }
    }
}
