namespace Console_candelete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tcourse")]
    public partial class tcourse
    {
        [Key]
        public int courseid { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
