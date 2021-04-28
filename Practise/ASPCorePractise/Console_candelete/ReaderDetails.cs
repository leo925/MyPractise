namespace Console_candelete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReaderDetails
    {
        public int Id { get; set; }

        public int Owner { get; set; }

        public string Des { get; set; }

        public int ReaderId { get; set; }

        public virtual ReaderModels ReaderModels { get; set; }
    }
}
