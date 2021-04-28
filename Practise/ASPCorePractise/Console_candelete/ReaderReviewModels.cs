namespace Console_candelete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReaderReviewModels
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        [StringLength(1024)]
        public string Content { get; set; }

        public int ReaderId { get; set; }

        public virtual ReaderModels ReaderModels { get; set; }
    }
}
