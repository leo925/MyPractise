using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebTestDbFirst.Models.Scaffold
{
    public partial class DataAppDbContext : DbContext
    {
        public DataAppDbContext()
        {
        }

        public DataAppDbContext(DbContextOptions<DataAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactDetails> ContactDetails { get; set; }
        public virtual DbSet<ContactLocation> ContactLocation { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DataAppDb;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactDetails>(entity =>
            {
                entity.HasIndex(e => e.LocationId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ContactDetails)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.SupplierId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasIndex(e => e.ContactId);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.ContactId);
            });
        }
    }
}
