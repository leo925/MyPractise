namespace Console_candelete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registrations
    {
        public int Id { get; set; }

        public int ParticipantId { get; set; }

        public int EventId { get; set; }

        public virtual Participants Participants { get; set; }

        public virtual XEvents XEvents { get; set; }
    }
}
