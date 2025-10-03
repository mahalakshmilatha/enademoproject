using Microsoft.EntityFrameworkCore;
using GrainBroker.API.Models;

namespace GrainBroker.API.Data
{
    public class GrainBrokerContext : DbContext
    {
        public GrainBrokerContext(DbContextOptions<GrainBrokerContext> options)
            : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<GrainRequirement> GrainRequirements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(200);
                entity.Property(e => e.GrainType).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PricePerUnit).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ContactEmail).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ContactPhone).HasMaxLength(50);
            });

            modelBuilder.Entity<GrainRequirement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GrainType).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                
                entity.HasOne(e => e.Customer)
                    .WithMany()
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(e => e.Supplier)
                    .WithMany()
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false);
            });
        }
    }
}
