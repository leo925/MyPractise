namespace Console_candelete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tcourseenroll")]
    public partial class tcourseenroll
    {
        public int id { get; set; }

        public int? courseid { get; set; }

        public int? studentid { get; set; }
    }
}
