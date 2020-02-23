namespace Console_candelete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TStudent")]
    public partial class TStudent
    {
        public int id { get; set; }

        [StringLength(10)]
        public string name { get; set; }

        public int? gender { get; set; }

        public int? phone { get; set; }
    }
}
