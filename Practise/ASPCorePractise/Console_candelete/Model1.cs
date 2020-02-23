namespace Console_candelete
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<ReaderDetails> ReaderDetails { get; set; }
        public virtual DbSet<ReaderModels> ReaderModels { get; set; }
        public virtual DbSet<ReaderReviewModels> ReaderReviewModels { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<tcourse> tcourse { get; set; }
        public virtual DbSet<tcourseenroll> tcourseenroll { get; set; }
        public virtual DbSet<TStudent> TStudent { get; set; }
        public virtual DbSet<XEvents> XEvents { get; set; }
        public virtual DbSet<ReaderModels2> ReaderModels2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participants>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Participants)
                .HasForeignKey(e => e.ParticipantId);

            modelBuilder.Entity<ReaderModels>()
                .HasMany(e => e.ReaderDetails)
                .WithRequired(e => e.ReaderModels)
                .HasForeignKey(e => e.ReaderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReaderModels>()
                .HasMany(e => e.ReaderReviewModels)
                .WithRequired(e => e.ReaderModels)
                .HasForeignKey(e => e.ReaderId);

            modelBuilder.Entity<XEvents>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.XEvents)
                .HasForeignKey(e => e.EventId);
        }
    }
}
